CREATE PROCEDURE [dbo].[CustomerDelete]
	@CustomerId int
AS 
BEGIN
	DELETE FROM dbo.Customer
	WHERE CustomerId = @CustomerId;
END
