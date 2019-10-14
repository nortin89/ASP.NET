
CREATE TABLE [dbo].[Resumes](
	[ApplicantId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FullName] [varchar](100) NOT NULL,
	[PhoneNumber][varchar](100) NOT NULL,
	[EmailAddress][varchar](100) NOT NULL,
  [LastUpdate] DATETIME DEFAULT(GETDATE()) NOT NULL,

);