CREATE PROCEDURE [dbo].[CustomerEdit]
	@CustomerId int,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS 
BEGIN
	UPDATE dbo.Customer
	SET FirstName = @FirstName,
	LastName = @LastName
	WHERE CustomerID = @CustomerId;	
END
