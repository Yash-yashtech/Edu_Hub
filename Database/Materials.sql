USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Materials]    Script Date: 10/21/2024 11:06:39 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Materials](
	[MaterialId] [int] NOT NULL,
	[CourseId] [int] NULL,
	[Title] [varchar](255) NOT NULL,
	[Description] [text] NULL,
	[URL] [varchar](255) NULL,
	[UploadDate] [datetime] NULL,
	[ContentType] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaterialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Materials] ADD  DEFAULT (getdate()) FOR [UploadDate]
GO

ALTER TABLE [dbo].[Materials]  WITH CHECK ADD FOREIGN KEY([CourseId])
REFERENCES [dbo].[Courses] ([CourseId])
GO

ALTER TABLE [dbo].[Materials]  WITH CHECK ADD CHECK  (([contentType]='other' OR [contentType]='quiz' OR [contentType]='video' OR [contentType]='lecture slides'))
GO

