CREATE TABLE [dbo].[ResumePhotos]
(
  [ApplicantId] INT NOT NULL,
  [PhotoId] INT NOT NULL,

  PRIMARY KEY ([ApplicantId],[PhotoId]),
  FOREIGN KEY ([PhotoId]) REFERENCES [Photos] ([PhotoId])

)
