-- ============================================
-- RBAC Database Schema for BIMS Ligaya
-- ============================================
-- This script creates the necessary tables for Role-Based Access Control
-- Run this script in your MySQL database before implementing RBAC

-- ============================================
-- 1. Create Roles Table
-- ============================================
CREATE TABLE IF NOT EXISTS tbl_roles (
    RoleID INT AUTO_INCREMENT PRIMARY KEY,
    RoleName VARCHAR(50) NOT NULL UNIQUE,
    Description VARCHAR(255),
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    INDEX idx_rolename (RoleName)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- 2. Create Users Table (Modified from tbl_login)
-- ============================================
-- Note: If tbl_login already exists, you may need to alter it or create a new structure
CREATE TABLE IF NOT EXISTS tbl_users (
    UserID INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL UNIQUE,
    PasswordHash VARCHAR(255) NOT NULL, -- Store hashed password, not plain text
    RoleID INT NOT NULL,
    FullName VARCHAR(255),
    Email VARCHAR(255),
    IsActive TINYINT(1) DEFAULT 1,
    CreatedDate DATETIME DEFAULT CURRENT_TIMESTAMP,
    LastLoginDate DATETIME NULL,
    FOREIGN KEY (RoleID) REFERENCES tbl_roles(RoleID) ON DELETE RESTRICT,
    INDEX idx_username (Username),
    INDEX idx_roleid (RoleID)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- ============================================
-- 3. Insert Default Roles
-- ============================================
INSERT INTO tbl_roles (RoleName, Description) VALUES 
('Admin', 'Administrator with full access to all features'),
('User', 'Regular user with limited access to BlotterRecords and ResidentInfo only')
ON DUPLICATE KEY UPDATE RoleName=RoleName;

-- ============================================
-- 4. Create Default Admin User
-- ============================================
-- Password: admin123 (will be hashed in application)
-- IMPORTANT: Change this password after first login!
INSERT INTO tbl_users (Username, PasswordHash, RoleID, FullName, IsActive) 
SELECT 'admin', 
       -- This is a placeholder hash. The application will hash passwords using SHA256
       -- For now, we'll use a simple hash. You should update this after running the app.
       SHA2('admin123', 256),
       (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin' LIMIT 1),
       'System Administrator',
       1
WHERE NOT EXISTS (SELECT 1 FROM tbl_users WHERE Username = 'admin');

-- ============================================
-- 5. Create Default User Account (for testing)
-- ============================================
-- Password: user123 (will be hashed in application)
INSERT INTO tbl_users (Username, PasswordHash, RoleID, FullName, IsActive) 
SELECT 'user',
       SHA2('user123', 256),
       (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User' LIMIT 1),
       'Regular User',
       1
WHERE NOT EXISTS (SELECT 1 FROM tbl_users WHERE Username = 'user');

-- ============================================
-- 6. Migration Script (if tbl_login exists)
-- ============================================
-- If you have existing users in tbl_login, migrate them:
/*
-- Step 1: Create backup
CREATE TABLE tbl_login_backup AS SELECT * FROM tbl_login;

-- Step 2: Migrate existing users to Admin role
INSERT INTO tbl_users (Username, PasswordHash, RoleID, FullName, IsActive)
SELECT 
    username,
    SHA2(password, 256) AS PasswordHash, -- Hash existing plain text passwords
    (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin' LIMIT 1) AS RoleID,
    username AS FullName,
    1 AS IsActive
FROM tbl_login
WHERE NOT EXISTS (SELECT 1 FROM tbl_users WHERE Username = tbl_login.username);
*/

-- ============================================
-- 7. Verification Queries
-- ============================================
-- Run these to verify the setup:

-- Check roles
SELECT * FROM tbl_roles;

-- Check users (without showing password hashes)
SELECT u.UserID, u.Username, u.FullName, r.RoleName, u.IsActive, u.CreatedDate
FROM tbl_users u
INNER JOIN tbl_roles r ON u.RoleID = r.RoleID;

-- ============================================
-- 8. Useful Queries for Management
-- ============================================

-- Get user with role information
SELECT u.Username, u.FullName, r.RoleName, r.Description
FROM tbl_users u
INNER JOIN tbl_roles r ON u.RoleID = r.RoleID
WHERE u.Username = 'admin';

-- Update user password (example)
-- UPDATE tbl_users SET PasswordHash = SHA2('newpassword', 256) WHERE Username = 'admin';

-- Deactivate a user
-- UPDATE tbl_users SET IsActive = 0 WHERE Username = 'username';

-- Activate a user
-- UPDATE tbl_users SET IsActive = 1 WHERE Username = 'username';

-- Change user role
-- UPDATE tbl_users SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User') WHERE Username = 'username';

