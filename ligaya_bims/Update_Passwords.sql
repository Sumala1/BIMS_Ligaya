-- ============================================
-- Update Admin and User Passwords
-- ============================================
-- This script updates the passwords for admin and user accounts
-- Passwords will be hashed using SHA256
-- Uses primary key (id) in WHERE clause to satisfy MySQL safe update mode

-- Update admin password to "admin"
UPDATE tbl_login 
SET password = SHA2('admin', 256)
WHERE id IS NOT NULL 
  AND username = 'admin';

-- Update user password to "user"
UPDATE tbl_login 
SET password = SHA2('user', 256)
WHERE id IS NOT NULL 
  AND username = 'user';

-- Verify the updates
SELECT 
    id,
    username,
    LEFT(password, 20) AS PasswordHash_Preview, -- Show first 20 chars of hash
    RoleID,
    FullName,
    IsActive
FROM tbl_login
WHERE username IN ('admin', 'user')
ORDER BY username;

