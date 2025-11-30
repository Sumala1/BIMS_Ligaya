# RBAC Migration Guide for Existing tbl_login Table

## Overview
This guide helps you migrate your existing `tbl_login` table to support Role-Based Access Control (RBAC) without losing your existing user data.

## Your Current Table Structure
Based on your `tbl_login` table:
- `id` (INT, Primary Key, Auto Increment)
- `username` (VARCHAR(45))
- `password` (VARCHAR(45))

## Migration Steps

### Step 1: Backup Your Data
**IMPORTANT:** Always backup your database before running migration scripts!

```sql
-- Create backup of tbl_login
CREATE TABLE tbl_login_backup AS SELECT * FROM tbl_login;
```

### Step 2: Run the Migration Script
1. Open MySQL Workbench or your MySQL client
2. Select your `capstone` database
3. Run the script: `Database_Schema_RBAC_Migration.sql`

This script will:
- ✅ Create `tbl_roles` table (Admin and User roles)
- ✅ Add new columns to `tbl_login`:
  - `RoleID` (links to tbl_roles)
  - `FullName`
  - `Email`
  - `IsActive`
  - `CreatedDate`
  - `LastLoginDate`
- ✅ Expand `password` column to VARCHAR(255) for SHA256 hashes
- ✅ Make `username` and `password` NOT NULL
- ✅ Migrate all existing users to Admin role
- ✅ Hash existing passwords (if they're plain text)
- ✅ Create default admin and user accounts

### Step 3: Verify Migration
Run these queries to verify:

```sql
-- Check all users with their roles
SELECT 
    l.id AS UserID,
    l.username,
    l.FullName,
    r.RoleName,
    l.IsActive
FROM tbl_login l
LEFT JOIN tbl_roles r ON l.RoleID = r.RoleID;

-- Check for any users without roles (should be none)
SELECT id, username FROM tbl_login WHERE RoleID IS NULL;
```

### Step 4: Update User Roles (Optional)
If you want to change specific users to "User" role:

```sql
-- Change a specific user to User role
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User') 
WHERE username = 'someusername';
```

## What Changed in the Code

The application code has been updated to work with `tbl_login` instead of `tbl_users`:

1. **Form1.vb** - Login query now uses `tbl_login`
2. **UserSession.vb** - Last login update uses `tbl_login`

## Default Accounts Created

After migration, you'll have:
- **Admin**: username=`admin`, password=`admin123` (Role: Admin)
- **User**: username=`user`, password=`user123` (Role: User)

**⚠️ IMPORTANT:** Change these default passwords after first login!

## Managing Users

### Create New User
```sql
INSERT INTO tbl_login (username, password, RoleID, FullName, IsActive) 
VALUES (
    'newuser',
    SHA2('password123', 256),  -- Password will be hashed
    (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User'),
    'New User Name',
    1
);
```

### Change User Password
```sql
UPDATE tbl_login 
SET password = SHA2('newpassword', 256) 
WHERE username = 'someuser';
```

### Change User Role
```sql
-- Make user an Admin
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin') 
WHERE username = 'someuser';

-- Make user a regular User
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User') 
WHERE username = 'someuser';
```

### Deactivate User
```sql
UPDATE tbl_login 
SET IsActive = 0 
WHERE username = 'someuser';
```

### Activate User
```sql
UPDATE tbl_login 
SET IsActive = 1 
WHERE username = 'someuser';
```

## Troubleshooting

### Issue: Migration fails with foreign key error
**Solution:** Make sure `tbl_roles` table is created first and has data.

### Issue: Existing users can't login after migration
**Solution:** 
1. Check if passwords were hashed correctly
2. If passwords were already hashed, the migration script might have double-hashed them
3. Reset password: `UPDATE tbl_login SET password = SHA2('newpassword', 256) WHERE username = 'username';`

### Issue: Users have NULL RoleID
**Solution:** Run this to assign Admin role to users without roles:
```sql
UPDATE tbl_login 
SET RoleID = (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin') 
WHERE RoleID IS NULL;
```

## Testing

1. **Test Admin Login:**
   - Username: `admin`
   - Password: `admin123`
   - Should have full access

2. **Test User Login:**
   - Username: `user`
   - Password: `user123`
   - Should have limited access (no edit, no backup/restore)

3. **Test Existing User:**
   - Try logging in with your existing username/password
   - Should work if password was migrated correctly

## Rollback (If Needed)

If you need to rollback:

```sql
-- Restore from backup
DROP TABLE IF EXISTS tbl_login;
CREATE TABLE tbl_login AS SELECT * FROM tbl_login_backup;

-- Remove added columns (if needed)
ALTER TABLE tbl_login 
DROP COLUMN IF EXISTS RoleID,
DROP COLUMN IF EXISTS FullName,
DROP COLUMN IF EXISTS Email,
DROP COLUMN IF EXISTS IsActive,
DROP COLUMN IF EXISTS CreatedDate,
DROP COLUMN IF EXISTS LastLoginDate;
```

## Next Steps

1. ✅ Run the migration script
2. ✅ Verify all users have roles assigned
3. ✅ Test login with existing and new accounts
4. ✅ Change default passwords
5. ✅ Assign appropriate roles to existing users
6. ✅ Test role-based access restrictions

Your RBAC system is now ready to use with your existing `tbl_login` table!

