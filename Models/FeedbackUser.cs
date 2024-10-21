using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;

public class FeedbackUser
{
    // [Key]
    // public int FeedbackId { get; set; }
    // public int CourseId { get; set; }
    // public int UserId { get; set; }
    [Key]
    public string Username { get; set; }
    public string FeedbackText { get; set; }
    public DateTime Date { get; set; }

    // Navigation property
}