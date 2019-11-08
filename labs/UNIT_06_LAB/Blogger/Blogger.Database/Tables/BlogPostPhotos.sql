CREATE TABLE [dbo].[BlogPostPhotos]
(
  [BlogPostId] INT NOT NULL,
  [PhotoId] INT NOT NULL,

  PRIMARY KEY ([BlogPostId],[PhotoId]),
  FOREIGN KEY ([PhotoId]) REFERENCES [Photos] ([PhotoId])

)
