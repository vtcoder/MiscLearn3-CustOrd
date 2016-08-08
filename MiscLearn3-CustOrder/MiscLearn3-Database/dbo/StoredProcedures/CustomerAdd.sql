CREATE PROCEDURE [dbo].[CustomerAdd]
	@CustomerId int output,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.Customer
	(FirstName, LastName)
	Values
	(@FirstName, @LastName);

	SET @CustomerId = SCOPE_IDENTITY();
END
