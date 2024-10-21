using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;
public class Enquiry
{
    public int EnquiryId { get; set; }
    public int UserId { get; set; }
    public int CourseId { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime EnquiryDate { get; set; }
    public string Status { get; set; }
    public string Response { get; set; }
}