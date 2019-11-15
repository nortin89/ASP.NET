CREATE TABLE [dbo].[Products]
(
-- columns
	[ProductID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	[Description] NVARCHAR(500) NOT NULL,
	[Category] NVARCHAR(50) NOT NULL,
	[Price] DECIMAL(16,2) NOT NULL,
  [Tags] VARCHAR(100) NULL,
  [PhotoId] INT NULL,

  
  -- indexes
  FOREIGN KEY ([PhotoId]) REFERENCES [Photos] ([PhotoId]),
  CONSTRAINT [IX_Products_Name] UNIQUE ([Name]),

)
