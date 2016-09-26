CREATE PROCEDURE [dbo].[CustomerExtensionFieldGetByAllCustomers]
AS	
BEGIN
	SET NOCOUNT ON;

	SELECT cef.CustomerExtensionFieldID, cef.CustomerID, cef.[Value],
	efd.ExtensionFieldDefinitionID, efd.Name, efd.EntityType, efd.DataType
	FROM dbo.CustomerExtensionField cef
	INNER JOIN dbo.ExtensionFieldDefinition efd ON efd.ExtensionFieldDefinitionID = cef.ExtensionFieldDefinitionID;
END
