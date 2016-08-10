CREATE TABLE [dbo].[CustomerExtensionField] (
    [CustomerExtensionFieldID]   INT           IDENTITY (1, 1) NOT NULL,
    [Value]                      NVARCHAR (50) NULL,
    [ExtensionFieldDefinitionID] INT           NOT NULL,
    [CustomerID]                 INT           NOT NULL,
    [EntityType] INT NOT NULL, 
    CONSTRAINT [PK_CustomerExtensionField] PRIMARY KEY CLUSTERED ([CustomerExtensionFieldID] ASC),
    CONSTRAINT [FK_CustomerExtensionField_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID]),
    CONSTRAINT [FK_CustomerExtensionField_ExtensionFieldDefinition] FOREIGN KEY ([ExtensionFieldDefinitionID], [EntityType]) REFERENCES [dbo].[ExtensionFieldDefinition] ([ExtensionFieldDefinitionID], [EntityType]), 
    CONSTRAINT [CK_CustomerExtensionField_EntityType] CHECK ([EntityType] = 0)
);

