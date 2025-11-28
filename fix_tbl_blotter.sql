-- Step 1: Check for NULL values in type_of_incident
SELECT COUNT(*) as null_count 
FROM tbl_blotter 
WHERE type_of_incident IS NULL;

-- Step 2: Update all NULL values to a default value (replace 'Unknown' with appropriate default)
UPDATE tbl_blotter 
SET type_of_incident = 'Unknown' 
WHERE type_of_incident IS NULL;

-- Step 3: Verify no NULL values remain
SELECT COUNT(*) as remaining_nulls 
FROM tbl_blotter 
WHERE type_of_incident IS NULL;
-- This should return 0

-- Step 4: Now you can safely alter the column to NOT NULL
ALTER TABLE tbl_blotter 
MODIFY COLUMN type_of_incident VARCHAR(500) NOT NULL;

-- Step 5: Verify the column structure
DESCRIBE tbl_blotter;

