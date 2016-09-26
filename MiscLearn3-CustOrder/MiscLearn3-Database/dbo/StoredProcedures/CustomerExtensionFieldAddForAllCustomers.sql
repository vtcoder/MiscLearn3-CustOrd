CREATE PROCEDURE [dbo].[CustomerExtensionFieldAddForAllCustomers]
	@ExtensionFieldDefinitionID INT,
	@EntityType INT,
	@DefaultValue NVARCHAR(50) = NULL
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.CustomerExtensionField
	(CustomerID, ExtensionFieldDefinitionID, EntityType, [Value])
	SELECT c.CustomerID, @ExtensionFieldDefinitionID, @EntityType, @DefaultValue
	FROM dbo.Customer AS c;
END
