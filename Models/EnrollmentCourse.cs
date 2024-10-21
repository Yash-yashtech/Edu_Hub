using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;


public class EnrollmentCourse
    {
        [Key]
        public int EnrollmentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
         public int CourseId { get; set; }

        public int UserId { get; set; }

        public string Status { get; set; }
        public string Title { get; set; }
        public string Username { get; set; }
        
    }