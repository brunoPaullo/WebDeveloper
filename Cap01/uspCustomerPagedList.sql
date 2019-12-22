CREATE PROCEDURE uspCustomerPagedList
(
	@starRow INT,
	@endRow INT
)
AS
BEGIN
	SET NOCOUNT ON;

	WITH CustomerResult AS
	(
		SELECT
			CustomerID, 
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
			ROW_NUMBER() OVER (ORDER BY CustomerID) AS Rownum
		FROM [dbo].[Customers]
	)
	SELECT
			CustomerID, 
			CompanyName, 
			ContactName, 
			ContactTitle, 
			[Address], 
			City, 
			Region, 
			PostalCode, 
			Country, 
			Phone, 
			Fax
		FROM CustomerResult
		WHERE Rownum BETWEEN @starRow AND @endRow
END
GO
