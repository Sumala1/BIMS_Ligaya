# Role-Based Access Control (RBAC) Implementation Guide

## Overview
This guide explains how to implement and use the Role-Based Access Control (RBAC) system in your BIMS Ligaya application.

## Files Created/Modified

### New Files Created:
1. **Database_Schema_RBAC.sql** - Database schema for users and roles
2. **UserSession.vb** - Global session management for current user
3. **PasswordHelper.vb** - Password hashing utility
4. **RBAC_Implementation_Guide.md** - This guide

### Modified Files:
1. **Form1.vb** - Updated login form with role-based authentication
2. **dashboard.vb** - Added role-based menu visibility control
3. **blotterrecords.vb** - Added edit button restrictions for User role
4. **residentinfo.vb** - Added edit/update button restrictions for User role

---

## Step 1: Database Setup

### 1.1 Run the SQL Script
1. Open your MySQL database (using MySQL Workbench, phpMyAdmin, or command line)
2. Select your database (e.g., `capstone`)
3. Run the SQL script: `Database_Schema_RBAC.sql`

This will create:
- `tbl_roles` table with Admin and User roles
- `tbl_users` table with user accounts
- Default admin user (username: `admin`, password: `admin123`)
- Default user account (username: `user`, password: `user123`)

### 1.2 Verify Database Setup
Run these queries to verify:

```sql
-- Check roles
SELECT * FROM tbl_roles;

-- Check users (without passwords)
SELECT UserID, Username, FullName, RoleID, IsActive 
FROM tbl_users;

-- Check user with role name
SELECT u.Username, u.FullName, r.RoleName 
FROM tbl_users u
INNER JOIN tbl_roles r ON u.RoleID = r.RoleID;
```

---

## Step 2: Understanding the Roles

### Admin Role
- **Full Access** to all features:
  - Add, Edit, Update, Delete records in all forms
  - Access Backup/Restore functionality
  - Access all forms (BlotterRecords, ResidentInfo, Certificates, Cedula, etc.)

### User Role
- **Limited Access**:
  - ✅ Can Add records (BlotterRecords and ResidentInfo only)
  - ✅ Can Delete records (BlotterRecords and ResidentInfo only)
  - ✅ Can Access BlotterRecords form
  - ✅ Can Access ResidentInfo form
  - ❌ **CANNOT** Edit/Update any records
  - ❌ **CANNOT** Access Backup/Restore
  - ❌ **CANNOT** Access any other forms (Certificates, Cedula, etc.)

---

## Step 3: How It Works

### 3.1 Login Process
1. User enters username and password
2. System hashes the password using SHA256
3. System queries `tbl_users` table to find user
4. System verifies password hash matches stored hash
5. System retrieves user's role from `tbl_roles` table
6. System initializes `UserSession` with user information
7. Dashboard opens with role-based menu items

### 3.2 Session Management
The `UserSession` module stores:
- Current User ID
- Username
- Role Name (Admin or User)
- Role ID
- Full Name
- Login status

### 3.3 Access Control
Forms check permissions using:
- `UserSession.IsAdmin()` - Returns true if user is Admin
- `UserSession.IsUser()` - Returns true if user is User role
- `UserSession.CanEdit()` - Returns true only for Admin
- `UserSession.CanAccessForm(formName)` - Checks if user can access specific form
- `UserSession.CanAccessBackupRestore()` - Returns true only for Admin

---

## Step 4: Testing the Implementation

### 4.1 Test Admin Login
1. Run the application
2. Login with:
   - Username: `admin`
   - Password: `admin123`
3. Verify:
   - ✅ All menu items are visible
   - ✅ Can access all forms
   - ✅ Can edit/update records
   - ✅ Can access Backup/Restore

### 4.2 Test User Login
1. Run the application
2. Login with:
   - Username: `user`
   - Password: `user123`
3. Verify:
   - ✅ Only BlotterRecords and ResidentInfo menu items visible
   - ✅ Can access BlotterRecords and ResidentInfo forms
   - ✅ Can Add records
   - ✅ Can Delete records
   - ❌ Edit column hidden in DataGridView
   - ❌ Edit/Update buttons hidden/disabled
   - ❌ Cannot access Backup/Restore
   - ❌ Cannot access other forms (shows "Access Denied" message)

---

## Step 5: Creating New Users

### 5.1 Using SQL
```sql
-- Create a new Admin user
INSERT INTO tbl_users (Username, PasswordHash, RoleID, FullName, IsActive)
VALUES (
    'newadmin',
    SHA2('password123', 256),  -- Password will be hashed
    (SELECT RoleID FROM tbl_roles WHERE RoleName = 'Admin'),
    'New Administrator',
    1
);

-- Create a new User role account
INSERT INTO tbl_users (Username, PasswordHash, RoleID, FullName, IsActive)
VALUES (
    'newuser',
    SHA2('password123', 256),  -- Password will be hashed
    (SELECT RoleID FROM tbl_roles WHERE RoleName = 'User'),
    'New User',
    1
);
```

### 5.2 Using VB.NET Code (Future Enhancement)
You can create a user management form that uses `PasswordHelper.HashPassword()` to hash passwords before storing.

---

## Step 6: Customizing Permissions

### 6.1 Adding New Roles
1. Add role to `tbl_roles` table:
```sql
INSERT INTO tbl_roles (RoleName, Description) 
VALUES ('Manager', 'Manager with limited admin access');
```

2. Update `UserSession.vb` to add role checking methods:
```vb
Public Function IsManager() As Boolean
    Return _isLoggedIn AndAlso String.Equals(_currentRoleName, "Manager", StringComparison.OrdinalIgnoreCase)
End Function
```

3. Update `CanAccessForm()` method to include new role permissions

### 6.2 Restricting Access to Specific Forms
In the dashboard's navigation click handlers, add permission checks:

```vb
Private Sub navSomeForm_Click(sender As Object, e As EventArgs) Handles navSomeForm.Click
    If Not UserSession.IsAdmin() Then
        MessageBox.Show("Access Denied", "Only Administrators can access this form.")
        Return
    End If
    ' Open form...
End Sub
```

### 6.3 Hiding Menu Items
In `dashboard.vb`, update `ApplyRoleBasedAccess()`:

```vb
If navSomeForm IsNot Nothing Then
    navSomeForm.Visible = UserSession.IsAdmin()
End If
```

---

## Step 7: Security Best Practices

### 7.1 Password Security
- ✅ Passwords are hashed using SHA256 (one-way hash)
- ✅ Never store plain text passwords
- ✅ Use `PasswordHelper.HashPassword()` for new passwords
- ✅ Use `PasswordHelper.VerifyPassword()` to verify login

### 7.2 Session Security
- ✅ Session is cleared on logout
- ✅ Session information is stored in memory (not persisted)
- ✅ Always check `UserSession.IsLoggedIn` before allowing actions

### 7.3 Access Control
- ✅ Check permissions at multiple levels:
  - Menu item visibility (UI level)
  - Form access (navigation level)
  - Button visibility (form level)
  - Action execution (function level)

### 7.4 Database Security
- ✅ Use parameterized queries (already implemented)
- ✅ Validate user input
- ✅ Use transactions for critical operations
- ✅ Implement proper error handling

---

## Step 8: Troubleshooting

### Issue: Login fails even with correct credentials
**Solution:**
1. Check if user exists in `tbl_users` table
2. Verify password hash matches (use `SHA2('password', 256)` in MySQL)
3. Check if `IsActive = 1` for the user
4. Verify database connection

### Issue: User can see menu items but cannot access forms
**Solution:**
1. Check `UserSession.IsLoggedIn` is true
2. Verify `UserSession.CurrentRoleName` is set correctly
3. Check form access permission checks in navigation handlers

### Issue: Edit buttons still visible for User role
**Solution:**
1. Verify `ApplyRoleBasedAccess()` is called in form's `Load` event
2. Check if `UserSession.CanEdit()` returns false for User role
3. Ensure button visibility is set correctly

### Issue: Password hashing not working
**Solution:**
1. Verify `PasswordHelper.vb` is included in project
2. Check that `System.Security.Cryptography` is imported
3. Test password hashing separately:
```vb
Dim hash As String = PasswordHelper.HashPassword("test123")
MessageBox.Show(hash)
```

---

## Step 9: Additional Features (Optional)

### 9.1 User Management Form
Create a form to:
- List all users
- Add new users
- Edit user roles
- Activate/Deactivate users
- Reset passwords

### 9.2 Activity Logging
Log user actions:
- Login/Logout times
- Form access
- Record modifications
- Permission denied attempts

### 9.3 Password Policy
Implement:
- Minimum password length
- Password complexity requirements
- Password expiration
- Password reset functionality

---

## Step 10: Code Examples

### Example 1: Check Permission Before Action
```vb
Private Sub btnSomeAction_Click(sender As Object, e As EventArgs)
    If Not UserSession.CanEdit() Then
        MessageBox.Show("You do not have permission to perform this action.", "Access Denied")
        Return
    End If
    ' Perform action...
End Sub
```

### Example 2: Hide Button Based on Role
```vb
Private Sub SomeForm_Load(sender As Object, e As EventArgs)
    If btnEdit IsNot Nothing Then
        btnEdit.Visible = UserSession.CanEdit()
        btnEdit.Enabled = UserSession.CanEdit()
    End If
End Sub
```

### Example 3: Disable Controls for User Role
```vb
Private Sub ApplyRoleBasedAccess()
    If Not UserSession.CanEdit() Then
        txtSomeField.ReadOnly = True
        txtSomeField.BackColor = Color.FromArgb(240, 240, 240)
        cmbSomeCombo.Enabled = False
    End If
End Sub
```

---

## Support

If you encounter any issues:
1. Check the troubleshooting section above
2. Verify all files are included in your project
3. Ensure database schema is correctly set up
4. Check that `UserSession` is initialized after login

---

## Summary

✅ Database schema created with roles and users
✅ Password hashing implemented
✅ Session management working
✅ Login form updated with role verification
✅ Dashboard menu items hidden based on role
✅ Edit/Update buttons disabled for User role
✅ Form access restricted based on role
✅ Backup/Restore access restricted to Admin only

Your RBAC system is now fully implemented and ready to use!

