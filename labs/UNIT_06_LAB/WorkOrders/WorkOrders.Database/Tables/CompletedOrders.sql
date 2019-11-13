CREATE TABLE [dbo].[CompletedOrders]
(
  [Id] INT NOT NULL PRIMARY KEY IDENTITY,
  [Email] NVARCHAR(200) NOT NULL,
  [IsConfirmed] BIT DEFAULT((0)) NOT NULL,
  [IsSubscribed] BIT DEFAULT((0)) NOT NULL,
  [UnsubscribeUrl] VARCHAR(1024) NULL,

  CONSTRAINT [IX_CompletedOrders_Email] UNIQUE ([Email])

)
