CREATE TABLE [dbo].[FormalEducation](
  [FormalId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ApplicantId] [int] NULL,
	[SchoolName] [varchar] (100) NOT NULL, 
	[Degree] [varchar](100) NOT NULL,
	[Subject] [varchar](100) NOT NULL,
	[StartDate] [date]  NOT NULL,
	[EndDate] [date] NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes(ApplicantId),

);