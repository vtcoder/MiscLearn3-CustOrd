CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionGetById]
	@ExtensionFieldDefinitionId int
AS	
BEGIN
	SET NOCOUNT ON;

	SELECT efd.ExtensionFieldDefinitionID, efd.Name, efd.EntityType, efd.DataType
	FROM dbo.ExtensionFieldDefinition efd
	WHERE efd.ExtensionFieldDefinitionID = @ExtensionFieldDefinitionId;
END
