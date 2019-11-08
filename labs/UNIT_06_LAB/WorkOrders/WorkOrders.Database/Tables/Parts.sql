CREATE TABLE [dbo].[Parts](
	[PartId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] [int] NULL,
	[OrderId] [int] NULL,
  [PartName] VARCHAR(50) NULL,
	[Quantity] [int] NULL,
	[PartNumber] [int] NULL,
	[PartCost] [decimal](8,2) NULL,
  
	FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
) ;