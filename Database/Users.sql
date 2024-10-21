USE [EduHubDb]
GO

/****** Object:  Table [dbo].[Users]    Script Date: 10/21/2024 11:10:06 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Users](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](100) NOT NULL,
	[Password] [varchar](100) NOT NULL,
	[Role] [varchar](15) NULL,
	[Email] [varchar](100) NOT NULL,
	[MobileNo] [varchar](14) NULL,
	[ProfileImage] [varchar](255) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  ((len([Password])>=(8) AND len([Password])<=(30)))
GO

ALTER TABLE [dbo].[Users]  WITH CHECK ADD CHECK  (([Role]='Educator' OR [Role]='Student'))
GO

