CREATE PROCEDURE [dbo].[ExtensionFieldDefinitionAdd]
	@ExtensionFieldDefinitionId int output,
	@Name nvarchar(50),
	@EntityType int,
	@DataType int
AS 
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.ExtensionFieldDefinition
	(Name, EntityType, DataType)
	Values
	(@Name, @EntityType, @DataType);

	SET @ExtensionFieldDefinitionId = SCOPE_IDENTITY();
END
