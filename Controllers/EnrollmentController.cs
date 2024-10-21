
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;



namespace Edu_Hub_Project.Controllers;

// Controller for handling enrollment-related actions
public class EnrollmentController : Controller
{
    // Constructor that accepts an enrollment service to handle enrollment logic
    private readonly IEnrollmentService _enrollmentService;
    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    // GET action to display the enrollment form for a specific course
    [HttpGet]
    public IActionResult AddEnrollment(int id)
    {
        // Create a new Enrollment object with the course ID and user ID from session
        Enrollment enrollment = new Enrollment()
        {
            CourseId=id,
            UserId=Convert.ToInt32(HttpContext.Session.GetString("UserId")),
            Status="Pending"
                    
        };
        return View(enrollment);
    }

    // POST action to handle the submission of the enrollment form
    [HttpPost]
    public IActionResult AddEnrollment(Enrollment enroll,int Id)
    {
        // Set the UserId, Status, and CourseId for the enrollment object
        enroll.UserId=Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        enroll.Status="Pending";
        enroll.CourseId=Id;

        // Call the service to create the enrollment
        _enrollmentService.CreateEnroll(enroll);
        return RedirectToAction("CourseList","Course");       // Redirect to the CourseList action in the Course controller
    }

    // GET action to retrieve and display the courses the user is enrolled in
    [HttpGet]
    public IActionResult EnrolledCourses(int id)
    {
        int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));   // Get the user ID from session
        var enrolledCourses = _enrollmentService.GetEnrolledCourses(userId);     // Retrieve the list of enrolled courses for the user
        return View(enrolledCourses);
    }

    // GET action to get enrollment details for the current user
    [HttpGet]
        public IActionResult GetEnrollCourse()
 
        {
            int id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Get the user ID from session
            var data = _enrollmentService.GetEnrollCourse(id);       // Retrieve enrollment data for the user
            return View(data);
        }

    // GET action to display the user's enrollment feedback
    [HttpGet]
    public IActionResult MyEnrollment()
    {

        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Get the user ID from session
        var feedbacks = _enrollmentService.GetEnrollmentByUserId(id);        // Retrieve feedbacks for the user's enrollments
        return View(feedbacks);
    }

}