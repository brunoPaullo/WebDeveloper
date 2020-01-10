CREATE PROCEDURE uspSupplierPagedList
(
	@starRow INT,
	@endRow INT
)
AS
BEGIN
	SET NOCOUNT ON;

	WITH SupplierResult AS
	(
		SELECT
			EmployeeID, 
			LastName, 
			FirstName, 
			Title, 
			TitleOfCourtesy, 
			BirthDate, 
			HireDate, 
			[Address], 
			City, 
			Region, 
			PostalCode, 
			Country, 
			HomePhone, 
			Extension, 
			Photo, 
			Notes, 
			ReportsTo, 
			PhotoPath,
			ROW_NUMBER() OVER (ORDER BY EmployeeID) AS Rownum
		FROM [dbo].[Employees]
	)
	SELECT
			EmployeeID, 
			LastName, 
			FirstName, 
			Title, 
			TitleOfCourtesy, 
			BirthDate, 
			HireDate, 
			[Address], 
			City, 
			Region, 
			PostalCode, 
			Country, 
			HomePhone, 
			Extension, 
			Photo, 
			Notes, 
			ReportsTo, 
			PhotoPath
		FROM SupplierResult
		WHERE Rownum BETWEEN @starRow AND @endRow
END
GO
