ALTER PROCEDURE uspSupplierPagedList
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
			SupplierID, 
			CompanyName, 
			ContactName, 
			ContactTitle, 
			[Address], 
			City, 
			Region, 
			PostalCode, 
			Country, 
			Phone, 
			Fax, 
			HomePage,
			ROW_NUMBER() OVER (ORDER BY SupplierID) AS Rownum
		FROM [dbo].[Suppliers]
	)
	SELECT
			SupplierID, 
			CompanyName, 
			ContactName, 
			ContactTitle, 
			[Address], 
			City, 
			Region, 
			PostalCode, 
			Country, 
			Phone, 
			Fax, 
			HomePage
		FROM SupplierResult
		WHERE Rownum BETWEEN @starRow AND @endRow
END
GO
