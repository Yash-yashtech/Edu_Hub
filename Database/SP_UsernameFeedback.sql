USE [EduHubDb]
GO

/****** Object:  StoredProcedure [dbo].[SP_UsernameFeedback]    Script Date: 10/21/2024 11:12:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
Create PROCEDURE [dbo].[SP_UsernameFeedback]
@courseid int 
AS
BEGIN
SELECT users.username, feedbacks.FeedbackText, feedbacks.date
 
FROM users
 
JOIN feedbacks ON users.userid = feedbacks.userid
 
WHERE feedbacks.courseid = @courseid
END
GO

