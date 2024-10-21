USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Enquiries]    Script Date: 10/21/2024 11:04:37 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Enquiries](
	[EnquiryId] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[CourseId] [int] NULL,
	[Subject] [nvarchar](50) NULL,
	[Message] [nvarchar](max) NULL,
	[EnquiryDate] [date] NULL,
	[Status] [nvarchar](20) NULL,
	[Response] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[EnquiryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Enquiries] ADD  DEFAULT ('In Progress') FOR [Status]
GO

ALTER TABLE [dbo].[Enquiries] ADD  DEFAULT ('Pending') FOR [Response]
GO

