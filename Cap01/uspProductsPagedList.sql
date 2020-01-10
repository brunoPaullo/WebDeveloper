CREATE PROCEDURE uspProductsPagedList
(
	@starRow INT,
	@endRow INT
)
AS
BEGIN
	SET NOCOUNT ON;

	WITH ProductsResult AS
	(
		SELECT
			ProductID, 
			ProductName, 
			SupplierID, 
			CategoryID, 
			QuantityPerUnit, 
			UnitPrice, 
			UnitsInStock, 
			UnitsOnOrder, 
			ReorderLevel, 
			Discontinued,
			ROW_NUMBER() OVER (ORDER BY ProductID) AS Rownum
		FROM [dbo].[Products]
	)
	SELECT
			ProductID, 
			ProductName, 
			SupplierID, 
			CategoryID, 
			QuantityPerUnit, 
			UnitPrice, 
			UnitsInStock, 
			UnitsOnOrder, 
			ReorderLevel, 
			Discontinued
		FROM ProductsResult
		WHERE Rownum BETWEEN @starRow AND @endRow
END
GO
