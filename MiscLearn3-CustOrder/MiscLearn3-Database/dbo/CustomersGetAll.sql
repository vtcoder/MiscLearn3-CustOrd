CREATE PROCEDURE [dbo].[CustomersGetAll]
AS
	SELECT c.CustomerID, c.FirstName, c.LastName
	FROM dbo.Customer c;
RETURN 0
