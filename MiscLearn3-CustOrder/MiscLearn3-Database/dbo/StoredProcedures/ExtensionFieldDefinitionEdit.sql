CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionEdit]
	@ExtensionFieldDefinitionId int,
	@Name nvarchar(50),
	@EntityType int,
	@DataType int
AS 
BEGIN
	UPDATE dbo.ExtensionFieldDefinition
	SET Name = @Name,
	EntityType = @EntityType,
	DataType = @DataType
	WHERE ExtensionFieldDefinitionID = @ExtensionFieldDefinitionId;
END
