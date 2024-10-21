USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Courses]    Script Date: 10/21/2024 11:04:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Courses](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](100) NULL,
	[Description] [varchar](150) NULL,
	[CourseStartDate] [date] NULL,
	[CourseEndDate] [date] NULL,
	[UserId] [int] NULL,
	[Category] [varchar](50) NULL,
	[Level] [varchar](40) NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Courses]  WITH CHECK ADD CHECK  (([Level]='Advanced' OR [Level]='Intermediate' OR [Level]='Beginner'))
GO

