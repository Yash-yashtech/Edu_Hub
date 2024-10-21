USE [EduHubDb]
GO

/****** Object:  StoredProcedure [dbo].[SP_UpdateCourses]    Script Date: 10/21/2024 11:12:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_UpdateCourses] @id int, @title VARCHAR, @description VARCHAR, @startdate date, @enddate date, @userid int, @category VARCHAR, @level VARCHAR
AS
BEGIN
	UPDATE Courses set Title=@title, Description=@description, CourseStartDate=@startdate, CourseEndDate=@enddate, UserID=@userid, Category=@category, Level=@level where UserId= @id
END
GO

