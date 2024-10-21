USE [EduHubDb]
GO

/****** Object:  StoredProcedure [dbo].[SP_EnrolleCourses]    Script Date: 10/21/2024 11:10:45 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



create procedure [dbo].[SP_EnrolleCourses]
(@userId int)
as
begin
	
		select e.enrollmentId , e.EnrollmentDate , e.Courseid , e.UserId , e.Status , c.Title, p.Username  
			from Enrollments as e inner join Courses as c on e.Courseid = c.Courseid inner join Users as p on e.UserId = p.userId
		where c.userid = @userId;
		
 
end;


GO

