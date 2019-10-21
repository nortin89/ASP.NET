CREATE TABLE [dbo].[ProjectPhotos]
(
  [ProjectPhotoId] INT NOT NULL IDENTITY,
  [ProjectId] INT NOT NULL,
  [Order] INT NOT NULL,
  [FileName] NVARCHAR(100) NOT NULL,

  PRIMARY KEY ([ProjectPhotoId]),
  FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId])
)
