﻿CREATE TABLE [dbo].[RosterItems]
(
  [RosterItemId] INT NOT NULL PRIMARY KEY IDENTITY,
  [FirstName] NVARCHAR(100) NOT NULL,
  [LastName] NVARCHAR(100) NOT NULL,
  [Email] NVARCHAR(100) NOT NULL,
)
