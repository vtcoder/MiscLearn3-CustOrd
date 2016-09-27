CREATE PROCEDURE [dbo].[CustomerExtensionFieldAdd]
	@CustomerExtensionFieldId int output,
	@CustomerId int,
	@ExtensionFieldDefinitionID INT,
	@EntityType INT,
	@Value NVARCHAR(50) = NULL
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.CustomerExtensionField
	(CustomerID, ExtensionFieldDefinitionID, EntityType, [Value])
	Values
	(@CustomerId, @ExtensionFieldDefinitionID, @EntityType, @Value);

	SET @CustomerExtensionFieldId = SCOPE_IDENTITY();
END
