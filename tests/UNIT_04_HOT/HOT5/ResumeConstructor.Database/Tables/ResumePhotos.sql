CREATE TABLE [dbo].[ResumePhotos]
(
  [ResumeId] INT NOT NULL,
  [PhotoId] INT NOT NULL,

  PRIMARY KEY ([ResumeId],[PhotoId]),
  FOREIGN KEY ([PhotoId]) REFERENCES [Photos] ([PhotoId])
)
