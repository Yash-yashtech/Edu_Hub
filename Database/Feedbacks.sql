USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Feedbacks]    Script Date: 10/21/2024 11:05:01 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Feedbacks](
	[FeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CourseId] [int] NULL,
	[FeedbackText] [nvarchar](255) NOT NULL,
	[Date] [date] NOT NULL
) ON [PRIMARY]
GO

