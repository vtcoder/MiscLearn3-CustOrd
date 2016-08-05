CREATE TABLE [dbo].[OrderExtensionField] (
    [OrderExtensionFieldID]      INT           IDENTITY (1, 1) NOT NULL,
    [Value]                      NVARCHAR (50) NULL,
    [ExtensionFieldDefinitionID] INT           NOT NULL,
    [OrderID]                    INT           NOT NULL,
    CONSTRAINT [PK_OrderExtensionField] PRIMARY KEY CLUSTERED ([OrderExtensionFieldID] ASC),
    CONSTRAINT [FK_OrderExtensionField_ExtensionFieldDefinition] FOREIGN KEY ([ExtensionFieldDefinitionID]) REFERENCES [dbo].[ExtensionFieldDefinition] ([ExtensionFieldDefinitionID]),
    CONSTRAINT [FK_OrderExtensionField_Order] FOREIGN KEY ([OrderID]) REFERENCES [dbo].[Order] ([OrderID])
);

