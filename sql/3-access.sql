IF NOT EXISTS(SELECT 1 FROM sys.database_principals WHERE principal_id = DATABASE_PRINCIPAL_ID('MovieReader'))
BEGIN
	PRINT 'Create role MovieReader'
	CREATE ROLE MovieReader
END

PRINT 'Grant permissions to role MovieReader'
GRANT SELECT ON dbo.Movie to MovieReader

-- Create SQL USER from your managed identity and grant membership to the MovieReader role.
-- Replace <your Equinor user name> with your actual user name (e.g. nst).
DECLARE @UserName sysname = 'id-edc24-radix-workshop-<your Equinor user name>'
DECLARE @stmt NVARCHAR(MAX)

IF NOT EXISTS(SELECT 1 FROM sys.database_principals WHERE principal_id = DATABASE_PRINCIPAL_ID(@UserName))
BEGIN
	SET @stmt=N'CREATE USER '+QUOTENAME(@UserName)+' FROM EXTERNAL PROVIDER'
	PRINT 'Create user ' + @UserName
	EXEC sys.sp_executesql @stmt
END

SET @stmt=N'ALTER ROLE MovieReader ADD MEMBER '+QUOTENAME(@UserName)
PRINT 'Add user ' + @UserName + ' to role MovieReader'
EXEC sys.sp_executesql @stmt
