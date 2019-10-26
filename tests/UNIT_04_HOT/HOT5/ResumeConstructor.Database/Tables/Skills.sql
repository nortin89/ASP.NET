CREATE TABLE [dbo].[Skills](
  [SkillId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ResumeId] INT NULL,
	[SkillName] varchar (100) NOT NULL,
	[ExperienceLevel] INT NULL,

	FOREIGN KEY ([ResumeId]) REFERENCES Resumes([ResumeId]),
);