CREATE PROCEDURE [dbo].[CustomersGetAll]
AS	
BEGIN
	SET NOCOUNT ON;

	SELECT c.CustomerID, c.FirstName, c.LastName
	FROM dbo.Customer c;
END
