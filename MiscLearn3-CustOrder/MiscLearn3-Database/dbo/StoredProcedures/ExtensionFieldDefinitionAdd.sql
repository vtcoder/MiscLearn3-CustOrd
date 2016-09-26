CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionAdd]
	@ExtensionFieldDefinitionId int output,
	@Name nvarchar(50),
	@EntityType int,
	@DataType int,
	@DefaultValue nvarchar(50) = NULL
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ExtensionFieldDefinition
	(Name, EntityType, DataType, DefaultValue)
	Values
	(@Name, @EntityType, @DataType, @DefaultValue);

	SET @ExtensionFieldDefinitionId = SCOPE_IDENTITY();
END
