CREATE TABLE [dbo].[Customers](
	[CustomerId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ClientName] [varchar](50) NULL,
	[PhoneNumber] [varchar](20) NULL,
	[StreetAddress] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](30) NOT NULL,
	[Zip] [varchar](10) NOT NULL
);