CREATE TABLE [dbo].[OrderExtensionField] (
    [OrderExtensionFieldID]      INT           IDENTITY (1, 1) NOT NULL,
    [Value]                      NVARCHAR (50) NULL,
    [ExtensionFieldDefinitionID] INT           NOT NULL,
    [OrderID]                    INT           NOT NULL,
    [EntityType] INT NOT NULL, 
    CONSTRAINT [PK_OrderExtensionField] PRIMARY KEY CLUSTERED ([OrderExtensionFieldID] ASC),
    CONSTRAINT [FK_OrderExtensionField_ExtensionFieldDefinition] FOREIGN KEY ([ExtensionFieldDefinitionID], [EntityType]) REFERENCES [dbo].[ExtensionFieldDefinition] ([ExtensionFieldDefinitionID], [EntityType]),
    CONSTRAINT [FK_OrderExtensionField_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID]), 
    CONSTRAINT [CK_OrderExtensionField_EntityType] CHECK ([EntityType] = 1)
);

