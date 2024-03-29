﻿CREATE TABLE [dbo].[Messages](
    [Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT(NEWID()),
    [User] NVARCHAR(20) NOT NULL,
    [Text] NVARCHAR(140) NOT NULL,
    [Sent] DATETIME NOT NULL DEFAULT(GETDATE())
)