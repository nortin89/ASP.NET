﻿CREATE TABLE [dbo].[ProjectTags]
(
  [ProjectTagId] INT NOT NULL PRIMARY KEY IDENTITY,
  [ProjectId] INT NOT NULL,
  [Name] NVARCHAR(100),

  FOREIGN KEY ([ProjectId]) REFERENCES [Projects] ([ProjectId])
)
