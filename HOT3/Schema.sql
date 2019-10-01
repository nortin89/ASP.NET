USE Resume

--drop table if exists [Parts];
--drop table if exists [Orders];
--drop table if exists [Customers];
--drop table if exists [Customer];



CREATE TABLE [dbo].[Resumes](
	[ApplicantId] [INT] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[FullName] [varchar](100) NOT NULL,
	[PhoneNumber][varchar](100) NOT NULL,
	[EmailAddress][varchar](100) NOT NULL,

);

CREATE TABLE [dbo].[TopSkills](
	[ApplicantId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[SkillName] [varchar] (100) NOT NULL,
	[ExpLevelOptionOne] [bit] NULL,
	[ExpLevelOptionTwo] [bit] NULL,
	[ExpLevelOptionThree] [bit] NULL,
	[ExpLevelOptionFour] [bit] NULL,
	[ExpLevelOptionFive][bit] NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes(ApplicantId),
);

CREATE TABLE [dbo].[FormalEducation](
	[ApplicantId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[SchoolName] [varchar] (100) NOT NULL, 
	[Degree] [varchar](100) NOT NULL,
	[Subject] [varchar](100) NOT NULL,
	[StartDate] [date]  NOT NULL,
	[EndDate] [date] NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes(ApplicantId),

);

CREATE TABLE [dbo].[ReleventProjects](
	[ApplicantId] [int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[ProjectName] [varchar] (100) NOT NULL,
	[TechUsed] [varchar] (100) NOT NULL,
	[ProjectDescription] [varchar](500) NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes (ApplicantId),

) ;

CREATE TABLE [dbo].[PastJobs](
	[ApplicantId][int] NOT NULL PRIMARY KEY IDENTITY(1,1),
	[CompanyName] [varchar](100) NOT NULL,
	[CompanyAddress][varchar](500) NOT NULL,
	[ManagerName] [varchar] (100) NOT NULL,
	[ManagerPhone] [varchar](100) NULL,
	[Position] [varchar](100) NOT NULL,
	FOREIGN KEY (ApplicantId) REFERENCES Resumes (ApplicantId),
);