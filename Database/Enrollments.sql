USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Enrollments]    Script Date: 10/21/2024 11:04:47 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enrollments](
	[EnrollmentId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CourseId] [int] NULL,
	[EnrollmentDate] [date] NULL,
	[Status] [varchar](50) NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enrollments]  WITH CHECK ADD CHECK  (([status]='Pending' OR [status]='Rejected' OR [status]='Accepted'))
GO

