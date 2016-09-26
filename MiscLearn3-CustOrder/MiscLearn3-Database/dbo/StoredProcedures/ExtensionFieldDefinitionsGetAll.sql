CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionsGetAll]
AS	
BEGIN
	SET NOCOUNT ON;

	SELECT efd.ExtensionFieldDefinitionID, efd.Name, efd.EntityType, efd.DataType, efd.DefaultValue
	FROM dbo.ExtensionFieldDefinition efd
END

