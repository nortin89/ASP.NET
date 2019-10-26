CREATE TABLE [dbo].[Projects](
  [ProjectId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ResumeId] [INT] NULL,
	[ProjectName] [varchar] (100) NOT NULL,
	[TechUsed] [varchar] (100) NOT NULL,
	[ProjectDescription] [varchar](500) NULL,
	FOREIGN KEY ([ResumeId]) REFERENCES Resumes ([ResumeId]),

) ;