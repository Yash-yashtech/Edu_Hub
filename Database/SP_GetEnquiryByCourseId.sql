USE [EduHubDb]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetEnquiryByCourseId]    Script Date: 10/21/2024 11:11:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_GetEnquiryByCourseId]
    @id int
AS
BEGIN
    SELECT * FROM Enquiries WHERE CourseId = @id
END
GO

