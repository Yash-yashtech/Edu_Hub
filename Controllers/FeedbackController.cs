using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;
using Microsoft.AspNetCore.Http;



namespace Edu_Hub_Project.Controllers;

public class FeedbackController : Controller
{
    // The FeedbackController is responsible for handling feedback-related actions
    private readonly IFeedbackService _FeedbackService;
    public FeedbackController(IFeedbackService feedbackService)       // Constructor that injects the feedback service
    {
        _FeedbackService = feedbackService;

    }

    // GET: FeedbackList - Retrieves a list of feedback for a specific course by its ID
    [HttpGet]
    public IActionResult FeedbackList(int id)
    {
        
        var feedbacks = _FeedbackService.GetFeedback(id);      // Call service to get feedbacks for the course
        return View(feedbacks);        // Return the feedbacks to the view
    }

    // GET: MyFeedback - Retrieves feedback submitted by the current user
    [HttpGet]
    public IActionResult MyFeedback()
    {

        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));   // Get the current user's ID from session
        var feedbacks = _FeedbackService.GetFeedbackByUserId(id);        // Call service to get user's feedbacks
        return View(feedbacks);
    }
    
    // GET: AddFeedback - Prepares to add feedback for a specific course
    [HttpGet]
    public IActionResult AddFeedback(int id)
    {
        // ViewBag.CourseId = courseId;
        
        int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Get the current user's ID from session

        // Create a new Feedback object with the course ID and user ID
        var data=new Feedback()
        {
            CourseId=id,
            UserId = userId
        };
        return View(data);
    }

    // POST: AddFeedback - Handles the submission of new feedback
    [HttpPost]
    public IActionResult AddFeedback(Feedback feedback, int Id)
    {
            feedback.UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Set the UserId and CourseId for the feedback object
            feedback.CourseId = Id;
            _FeedbackService.AddFeedback(feedback);     // Call the service to add the feedback to the database
            return RedirectToAction("CourseList", "Course");
        
    }

}