CREATE TABLE [dbo].[Parts](
	[PartId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CustomerId] [int] NOT NULL,
	[OrderId] [int] NOT NULL,
  [PartName] VARCHAR(50) NOT NULL,
	[Quantity] [int] NOT NULL,
	[PartNumber] [int] NOT NULL,
	[PartCost] [decimal](8,2) NOT NULL,
  
	FOREIGN KEY (CustomerId) REFERENCES Customers (CustomerId),
	FOREIGN KEY (OrderId) REFERENCES Orders(OrderId)
) ;