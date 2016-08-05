CREATE TABLE [dbo].[ExtensionFieldDefinition] (
    [ExtensionFieldDefinitionID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]                       NVARCHAR (50) NOT NULL,
    [DataType]                   INT           NOT NULL,
    CONSTRAINT [PK_ExtensionFieldDefinition] PRIMARY KEY CLUSTERED ([ExtensionFieldDefinitionID] ASC)
);

