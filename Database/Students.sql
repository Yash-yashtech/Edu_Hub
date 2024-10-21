USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Students]    Script Date: 10/21/2024 11:09:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Students](
	[StudentId] [int] NOT NULL,
	[Username] [varchar](30) NOT NULL,
	[Email] [varchar](30) NOT NULL,
	[Branch] [varchar](30) NULL,
	[Gender] [varchar](10) NULL,
	[Address] [varchar](150) NULL,
PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD CHECK  (([Branch]='IT' OR [Branch]='Mech' OR [Branch]='ENTC' OR [Branch]='CSE'))
GO

ALTER TABLE [dbo].[Students]  WITH CHECK ADD CHECK  (([Gender]='Female' OR [Gender]='Male'))
GO

