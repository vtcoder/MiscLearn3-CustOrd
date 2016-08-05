CREATE TABLE [dbo].[Order] (
    [OrderID]     INT           IDENTITY (1, 1) NOT NULL,
    [Description] NVARCHAR (50) NULL,
    [CustomerID]  INT           NOT NULL,
    CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([OrderID] ASC),
    CONSTRAINT [FK_Order_Customer] FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customer] ([CustomerID])
);

