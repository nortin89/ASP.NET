CREATE TABLE [dbo].[Suscribers]
(
  [Email] NVARCHAR(200) NOT NULL PRIMARY KEY,
  [Name] NVARCHAR(200) NOT NULL,
  [IsSubscribed] BIT NOT NULL
)
