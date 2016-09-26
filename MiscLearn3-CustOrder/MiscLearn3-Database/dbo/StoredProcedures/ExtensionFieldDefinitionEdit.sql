CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionEdit]
	@ExtensionFieldDefinitionId int,
	@Name nvarchar(50),
	@EntityType int,
	@DataType int,
	@DefaultValue nvarchar(50) = NULL
AS 
BEGIN
	UPDATE dbo.ExtensionFieldDefinition
	SET Name = @Name,
	EntityType = @EntityType,
	DataType = @DataType,
	DefaultValue = @DefaultValue
	WHERE ExtensionFieldDefinitionID = @ExtensionFieldDefinitionId;
END
