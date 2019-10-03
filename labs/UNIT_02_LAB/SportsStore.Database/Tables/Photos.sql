CREATE TABLE [dbo].[Photos]
(
  [PhotoId] INT NOT NULL PRIMARY KEY IDENTITY,
  [ImageName] VARCHAR (100) NULL,
  [ImageData] VARBINARY (MAX) NULL,
  [ImageMimeType] VARCHAR (100) NULL

)
