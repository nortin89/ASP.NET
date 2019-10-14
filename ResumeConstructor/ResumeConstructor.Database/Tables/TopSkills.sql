CREATE TABLE [dbo].[TopSkills](
  [TopSkills] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ApplicantId] [int] NULL,
	[SkillName] [varchar] (100) NOT NULL,
	[ExpLevelOptionOne] [bit] NULL,
	[ExpLevelOptionTwo] [bit] NULL,
	[ExpLevelOptionThree] [bit] NULL,
	[ExpLevelOptionFour] [bit] NULL,
	[ExpLevelOptionFive][bit] NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes(ApplicantId),
);