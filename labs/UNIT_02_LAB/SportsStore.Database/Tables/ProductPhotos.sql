CREATE TABLE [dbo].[ProductPhotos]
(
  [ProductID] INT NOT NULL,
  [PhotoId] INT NOT NULL,

  PRIMARY KEY ([ProductID],[PhotoId]),
  FOREIGN KEY ([PhotoId]) REFERENCES [Photos] ([PhotoId])

)
