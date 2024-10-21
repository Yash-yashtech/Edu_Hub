USE [EduHubDb]
GO

/****** Object:  StoredProcedure [dbo].[SP_GetCoursesByUserId]    Script Date: 10/21/2024 11:11:24 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GetCoursesByUserId] @id int
AS
BEGIN
	Select * from Courses where UserID = @id
END
GO

