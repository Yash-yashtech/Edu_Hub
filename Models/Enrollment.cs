using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;


public class Enrollment
    {
        public int EnrollmentId { get; set; }
         public int CourseId { get; set; }

        public int UserId { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public string Status { get; set; }
        
    }