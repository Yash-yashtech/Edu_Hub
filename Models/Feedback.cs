using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;

public class Feedback
{
    public int FeedbackId { get; set; }
    public int CourseId { get; set; }
    public int UserId { get; set; }
    public string FeedbackText { get; set; }
    public DateTime Date { get; set; }



    // Navigation property
}