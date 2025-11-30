-- ============================================
-- RBAC Migration Script for Existing tbl_login (Simple Version)
-- ============================================
-- This is a simpler version that you can run step by step
-- If a column already exists, you'll get an error - just skip that step

-- ============================================
-- Step 1: Create Roles Table
-- ============================================
CREATE TABLE IF NOT EXISTS tbl_roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE,
    Description VARCHAR(255),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_rolename (RoleName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- Step 2: Insert Default Roles
-- ============================================
INSERT INTO tbl_roles (RoleName, Description) VALUES 
('Admin', 'Administrator with full access to all features'),
('User', 'Regular user with limited access to BlotterRecords and ResidentInfo only')
ON DUPLICATE KEY UPDATE RoleName=RoleName;

-- ============================================
-- Step 3: Add Columns to tbl_login
-- ============================================
-- Run these one at a time. If you get "Duplicate column name" error, 
-- that column already exists - just continue to the next one.

-- Add RoleID column
ALTER TABLE tbl_login 
ADD COLUMN RoleID INT NULL AFTER password;

-- Add FullName column
ALTER TABLE tbl_login 
ADD COLUMN FullName VARCHAR(255) NULL AFTER RoleID;

-- Add Email column
ALTER TABLE tbl_login 
ADD COLUMN Email VARCHAR(255) NULL AFTER FullName;

-- Add IsActive column
ALTER TABLE tbl_login 
ADD COLUMN IsActive TINYINT(1) DEFAULT 1 AFTER Email;

-- Add CreatedDate column
ALTER TABLE tbl_login 
ADD COLUMN CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP AFTER IsActive;

-- Add LastLoginDate column
ALTER TABLE tbl_login 
ADD COLUMN LastLoginDate DATETIME NULL AFTER CreatedDate;

-- ============================================
-- Step 4: Add Foreign Key and Index
-- ============================================
-- Add foreign key constraint (skip if it already exists)
ALTER TABLE tbl_login 
ADD CONSTRAINT FK_tbl_login_RoleID 
FOREIGN KEY (RoleID) REFERENCES tbl_roles(RoleID) 
ON DELETE RESTRICT;

-- Add index (skip if it already exists)
CREATE INDEX idx_roleid ON tbl_login(RoleID);

-- ============================================
-- Step 5: Update Password Column
-- ============================================
-- Expand password column to support SHA256 hashes (64 characters)
-- Only run this if your password column is still VARCHAR(45)
ALTER TABLE tbl_login 
MODIFY COLUMN password VARCHAR(255) NOT NULL COMMENT 'SHA256 hashed password';

-- Make username NOT NULL (skip if already NOT NULL)
ALTER TABLE tbl_login 
MODIFY COLUMN username VARCHAR(100) NOT NULL;

-- ============================================
-- Step 6: Migrate Existing Users to Admin Role
-- ============================================
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin' LIMIT 1),
    IsActive = COALESCE(IsActive, 1),
    CreatedDate = COALESCE(CreatedDate, NOW())
WHERE id IS NOT NULL 
  AND RoleID IS NULL;

-- ============================================
-- Step 7: Hash Existing Passwords (OPTIONAL)
-- ============================================
-- IMPORTANT: Only run this if your passwords are currently PLAIN TEXT
-- If passwords are already hashed, SKIP THIS STEP!
-- 
-- This will hash plain text passwords using SHA256
-- Uses primary key (id) in WHERE clause to satisfy MySQL safe update mode
-- Uncomment the line below ONLY if passwords are plain text:
-- UPDATE tbl_login SET password = SHA2(password, 256) WHERE id IS NOT NULL AND password IS NOT NULL AND LENGTH(password) < 64;

-- ============================================
-- Step 8: Create/Update Default Admin User
-- ============================================
-- Create admin user if it doesn't exist
INSERT INTO tbl_login (username, password, RoleID, FullName, IsActive) 
SELECT 'admin', 
       SHA2('admin', 256), -- Password: admin
       (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin' LIMIT 1),
       'System Administrator',
       1
WHERE NOT EXISTS (SELECT 1 FROM tbl_login WHERE username = 'admin');

-- Update admin password if user already exists
UPDATE tbl_login 
SET password = SHA2('admin', 256) -- Password: admin
WHERE id IS NOT NULL 
  AND username = 'admin';

-- ============================================
-- Step 9: Create/Update Default User Account
-- ============================================
-- Create user account if it doesn't exist
INSERT INTO tbl_login (username, password, RoleID, FullName, IsActive) 
SELECT 'user',
       SHA2('user', 256), -- Password: user
       (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User' LIMIT 1),
       'Regular User',
       1
WHERE NOT EXISTS (SELECT 1 FROM tbl_login WHERE username = 'user');

-- Update user password if account already exists
UPDATE tbl_login 
SET password = SHA2('user', 256) -- Password: user
WHERE id IS NOT NULL 
  AND username = 'user';

-- ============================================
-- Step 10: Verification
-- ============================================
-- Run these to verify everything worked:

-- Check roles
SELECT * FROM tbl_roles;

-- Check users with roles
SELECT 
    l.id AS UserID,
    l.username,
    l.FullName,
    r.RoleName,
    l.IsActive,
    l.CreatedDate
FROM tbl_login l
LEFT JOIN tbl_roles r ON l.RoleID = r.RoleID
ORDER BY l.id;

-- Check for users without roles (should be none)
SELECT id, username 
FROM tbl_login 
WHERE RoleID IS NULL;

