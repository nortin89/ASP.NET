CREATE TABLE [dbo].[Customers](
	[CustomerId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ClientName] [varchar](50) NOT NULL,
	[PhoneNumber] [varchar](20) NOT NULL,
	[StreetAddress] [varchar](50) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](30) NULL,
	[Zip] [varchar](10) NULL
);