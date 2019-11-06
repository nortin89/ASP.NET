CREATE TABLE [dbo].[GuestResponse]
(
  [Email] NVARCHAR(200) NOT NULL PRIMARY KEY,
  [Name] NVARCHAR(200) NOT NULL,
  [Phone] VARCHAR (20) NULL,
  [WillAttend] BIT NOT NULL
)
