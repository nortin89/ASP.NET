CREATE TABLE [dbo].[Photos]
(
  [PhotoId] INT NOT NULL PRIMARY KEY IDENTITY,
  [ResumeId] INT NOT NULL,
  [ImageName] VARCHAR (100) NULL,
  [ImageData] VARBINARY (MAX) NULL,
  [ImageMimeType] VARCHAR (100) NULL,

  FOREIGN KEY ([ResumeId]) REFERENCES Resumes ([ResumeId]),
)
