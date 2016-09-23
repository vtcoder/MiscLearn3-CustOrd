CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionDelete]
	@ExtensionFieldDefinitionId int
AS 
BEGIN
	DELETE FROM dbo.ExtensionFieldDefinition
	WHERE ExtensionFieldDefinitionID = @ExtensionFieldDefinitionId;
END
