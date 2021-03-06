USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetDetailByOrder]    Script Date: 03/11/2019 11:06:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_GetDetailByOrder]
	-- Add the parameters for the stored procedure here
	@OrderId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
	 OrderID
	,ProductID
	,UnitPrice
	,Quantity
	,Discount
	FROM OrderDetails
	WHERE OrderID = @OrderId
END
