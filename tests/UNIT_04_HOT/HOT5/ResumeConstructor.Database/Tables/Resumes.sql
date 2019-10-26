
CREATE TABLE [dbo].[Resumes](
	[ResumeId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
  [PhotoId] INT NULL,
	[FullName] [varchar](100) NOT NULL,
	[PhoneNumber][varchar](100) NOT NULL,
	[EmailAddress][varchar](100) NOT NULL,
  [LinkedIn] VARCHAR(100) NULL,
  [Education] VARCHAR(200) NULL,
  [Jobs] VARCHAR(200) NULL,
  [Projects] VARCHAR (200) NULL,
  [Skills] VARCHAR (200) NULL,
  [LastUpdate] DATETIME DEFAULT(GETDATE()) NOT NULL,


);