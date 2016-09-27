CREATE PROCEDURE [dbo].[CustomerExtensionFieldEdit]
	@CustomerId int,
	@ExtensionFieldDefinitionId int,
	@Value NVARCHAR(50) = NULL
AS 
BEGIN
	SET NOCOUNT ON;

	UPDATE dbo.CustomerExtensionField
	SET [Value] = @Value
	WHERE CustomerID = @CustomerId
	AND ExtensionFieldDefinitionID = @ExtensionFieldDefinitionId;
END
