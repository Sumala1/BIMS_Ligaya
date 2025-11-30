-- ============================================
-- RBAC Migration Script for Existing tbl_login
-- ============================================
-- This script migrates your existing tbl_login table to support RBAC
-- It preserves your existing user data and adds role functionality

-- ============================================
-- Step 1: Create Roles Table (if not exists)
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
-- Step 3: Modify Existing tbl_login Table
-- ============================================
-- Add new columns to support RBAC while keeping existing structure
-- Note: MySQL doesn't support IF NOT EXISTS in ALTER TABLE, so we check first

-- Add RoleID column (foreign key to tbl_roles)
-- Check if column exists before adding (MySQL-compatible approach)
SET @dbname = DATABASE();
SET @tablename = 'tbl_login';
SET @columnname = 'RoleID';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1', -- Column exists, do nothing
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' INT NULL AFTER password')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add FullName column
SET @columnname = 'FullName';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1',
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' VARCHAR(255) NULL AFTER RoleID')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add Email column
SET @columnname = 'Email';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1',
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' VARCHAR(255) NULL AFTER FullName')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add IsActive column
SET @columnname = 'IsActive';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1',
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' TINYINT(1) DEFAULT 1 AFTER Email')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add CreatedDate column
SET @columnname = 'CreatedDate';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1',
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' DATETIME DEFAULT CURRENT_TIMESTAMP AFTER IsActive')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add LastLoginDate column
SET @columnname = 'LastLoginDate';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (COLUMN_NAME = @columnname)
  ) > 0,
  'SELECT 1',
  CONCAT('ALTER TABLE ', @tablename, ' ADD COLUMN ', @columnname, ' DATETIME NULL AFTER CreatedDate')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add foreign key constraint for RoleID (only if it doesn't exist)
SET @constraint_name = 'FK_tbl_login_RoleID';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (CONSTRAINT_NAME = @constraint_name)
  ) > 0,
  'SELECT 1', -- Constraint exists, do nothing
  CONCAT('ALTER TABLE ', @tablename, ' ADD CONSTRAINT ', @constraint_name, ' FOREIGN KEY (RoleID) REFERENCES tbl_roles(RoleID) ON DELETE RESTRICT')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- Add index for RoleID (only if it doesn't exist)
SET @index_name = 'idx_roleid';
SET @preparedStatement = (SELECT IF(
  (
    SELECT COUNT(*) FROM INFORMATION_SCHEMA.STATISTICS
    WHERE
      (TABLE_SCHEMA = @dbname)
      AND (TABLE_NAME = @tablename)
      AND (INDEX_NAME = @index_name)
  ) > 0,
  'SELECT 1', -- Index exists, do nothing
  CONCAT('CREATE INDEX ', @index_name, ' ON ', @tablename, '(RoleID)')
));
PREPARE alterIfNotExists FROM @preparedStatement;
EXECUTE alterIfNotExists;
DEALLOCATE PREPARE alterIfNotExists;

-- ============================================
-- Step 4: Update Password Column for Hashing
-- ============================================
-- Change password column to support longer hash values (SHA256 = 64 chars)
-- Also make it NOT NULL for security
ALTER TABLE tbl_login 
MODIFY COLUMN password VARCHAR(255) NOT NULL COMMENT 'SHA256 hashed password';

-- Make username NOT NULL for security
ALTER TABLE tbl_login 
MODIFY COLUMN username VARCHAR(100) NOT NULL;

-- ============================================
-- Step 5: Migrate Existing Users to Admin Role
-- ============================================
-- Set all existing users to Admin role by default
-- You can change specific users to User role later if needed
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin' LIMIT 1),
    IsActive = 1,
    CreatedDate = COALESCE(CreatedDate, NOW())
WHERE RoleID IS NULL;

-- ============================================
-- Step 6: Hash Existing Passwords
-- ============================================
-- IMPORTANT: This assumes your existing passwords are plain text
-- If they're already hashed, skip this step or modify accordingly
-- 
-- Update existing passwords to SHA256 hash
-- Note: This will hash the existing password values
-- If passwords are already hashed, comment out this section
-- 
-- IMPORTANT: This uses the primary key (id) in WHERE clause to satisfy MySQL safe update mode
UPDATE tbl_login 
SET password = SHA2(password, 256)
WHERE id IS NOT NULL 
  AND password IS NOT NULL 
  AND LENGTH(password) < 64; -- Only hash if it looks like plain text (less than 64 chars)

-- ============================================
-- Step 7: Create/Update Default Admin User
-- ============================================
-- Create admin user if it doesn't exist, or update password if it does
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
-- Step 8: Create/Update Default User Account
-- ============================================
-- Create user account if it doesn't exist, or update password if it does
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
-- Step 9: Verification Queries
-- ============================================
-- Run these to verify the migration:

-- Check roles
SELECT * FROM tbl_roles;

-- Check users with their roles
SELECT 
    l.id AS UserID,
    l.username,
    l.FullName,
    r.RoleName,
    l.IsActive,
    l.CreatedDate,
    l.LastLoginDate
FROM tbl_login l
LEFT JOIN tbl_roles r ON l.RoleID = r.RoleID
ORDER BY l.id;

-- Check for users without roles (should be none after migration)
SELECT id, username 
FROM tbl_login 
WHERE RoleID IS NULL;

-- ============================================
-- Step 10: Update Application Code Reference
-- ============================================
-- After running this migration, update Form1.vb to use tbl_login instead of tbl_users
-- The query should be:
-- SELECT l.id, l.username, l.password, l.FullName, r.RoleID, r.RoleName, l.IsActive
-- FROM tbl_login l
-- INNER JOIN tbl_roles r ON l.RoleID = r.RoleID
-- WHERE l.username = @username AND l.IsActive = 1

-- ============================================
-- Notes:
-- ============================================
-- 1. This script preserves your existing tbl_login table structure
-- 2. All existing users are migrated to Admin role by default
-- 3. Passwords are hashed using SHA256 (if they were plain text)
-- 4. You can manually change specific users to User role:
--    UPDATE tbl_login SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User') WHERE username = 'someuser';
-- 5. To deactivate a user: UPDATE tbl_login SET IsActive = 0 WHERE username = 'someuser';
-- 6. To change a password: UPDATE tbl_login SET password = SHA2('newpassword', 256) WHERE username = 'someuser';

