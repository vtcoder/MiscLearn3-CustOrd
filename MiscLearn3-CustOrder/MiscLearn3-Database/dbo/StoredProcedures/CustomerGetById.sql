CREATE PROCEDURE [dbo].[CustomersGetById]
	@CustomerId int
AS	
BEGIN
	SET NOCOUNT ON;

	SELECT c.CustomerID, c.FirstName, c.LastName
	FROM dbo.Customer c
	WHERE c.CustomerID = @CustomerId;
END
