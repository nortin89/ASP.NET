﻿CREATE TABLE [dbo].[Projects]
(
  [ProjectId] INT NOT NULL PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(100) NOT NULL,
  [Description] NVARCHAR(500) NOT NULL
)