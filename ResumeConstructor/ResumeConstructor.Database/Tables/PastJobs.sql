CREATE TABLE [dbo].[PastJobs](
  [PastJobId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ApplicantId][int] NULL,
	[CompanyName] [varchar](100) NOT NULL,
	[CompanyAddress][varchar](500) NOT NULL,
	[ManagerName] [varchar] (100) NOT NULL,
	[ManagerPhone] [varchar](100) NULL,
	[Position] [varchar](100) NOT NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes (ApplicantId),
);