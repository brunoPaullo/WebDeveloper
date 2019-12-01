CREATE TABLE [User]
(
Email VARCHAR(250) PRIMARY KEY,
FirstName VARCHAR(250) NOT NULL,
LastName VARCHAR(250),
[Password] VARBINARY (250) NOT NULL,
Roles VARCHAR(250)
)
GO

CREATE PROCEDURE uspValidateUser
(
	@email varchar(100),
	@password varchar(100)
)
AS
BEGIN
	SELECT  
		Email,
		FirstName,
		LastName,
		Roles
	FROM [User]
	WHERE Email = @email 
	AND  PWDCOMPARE(@password, [Password]) = 1
END
GO

CREATE PROCEDURE uspCreateUser
(
	@email varchar(100),
	@firstName varchar(250),
	@lastName varchar(250),
	@password varchar(100)
)
AS
BEGIN TRY
	BEGIN TRAN
		INSERT INTO [User] (Email, FirstName, LastName, [Password])
		VALUES(@email, @firstName, @lastName, PWDENCRYPT (@password))		
	COMMIT TRAN
			
		SELECT  
			Email,
			FirstName,
			LastName,
			Roles
		FROM [User]
		WHERE Email = @email 
		AND  PWDCOMPARE(@password, [Password]) = 1
END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO