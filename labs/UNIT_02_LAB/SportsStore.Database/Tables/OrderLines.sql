CREATE TABLE [OrderLines]
(
  [OrderID] INT NOT NULL,
  [ProductID] INT NOT NULL,
  [Quantity] INT NOT NULL,
  [PricePerUnit] DECIMAL(16,2) NOT NULL,

  /*Validation Check*/
  PRIMARY KEY ([OrderID],[ProductID]),
  FOREIGN KEY ([OrderID]) REFERENCES [Orders] ([OrderID]),
  FOREIGN KEY ([ProductID]) REFERENCES [Products]([ProductID]),
);
