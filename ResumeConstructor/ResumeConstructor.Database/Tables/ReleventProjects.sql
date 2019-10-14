CREATE TABLE [dbo].[ReleventProjects](
  [ReleventProjectsId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ApplicantId] [int] NULL,
	[ProjectName] [varchar] (100) NOT NULL,
	[TechUsed] [varchar] (100) NOT NULL,
	[ProjectDescription] [varchar](500) NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes (ApplicantId),

) ;