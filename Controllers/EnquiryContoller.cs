using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;



namespace Edu_Hub_Project.Controllers;

public class EnquiryController : Controller
{
    private readonly IEnquiryService _enquiryService;

    // Constructor to initialize the enquiry service
    public EnquiryController(IEnquiryService enquiryService)
    {
        _enquiryService = enquiryService;

    }
    //GET: Displays all enquiries
    [HttpGet]
    public IActionResult Enquiry()
    {

        return View(_enquiryService.GetAllEnquiry());
    }
    // [HttpGet]
    // public IActionResult Enquiry(int courseId)
    // {
    //     return View(_enquiryService.GetEnquiryByCourseId(courseId));
    // }

    // GET: Displays the edit form for a specific enquiry based on its ID
    [HttpGet]
    public IActionResult Edit(int id)
    {
        // Check if the id is null (not provided)
        if (id == null)
            return View();  // Return empty view if no id is provided
        else
        {
            
            var data = _enquiryService.GetEnquiryById(id);    // Fetch the enquiry data by ID
            if (data == null)   // If no data found, return a 404 Not Found response
                return NotFound();
            return View(data);        // Return the edit view with the enquiry data
        }
    }

    // POST: Handles the submission of the edit form
    [HttpPost]
    public IActionResult Edit(int id, Enquiry modified)
    {
        if (ModelState.IsValid) // Validate model state
        {

            var data = _enquiryService.GetEnquiryById(id);  // Fetch the existing enquiry by ID
            if (data == null)
            {
                return NotFound(); // Return 404 if course not found
            }

            // Update properties from modified object
            data.Subject = modified.Subject;
            data.Message = modified.Message; // Fixed this line
            data.Status = modified.Status;
            data.Response = modified.Response;

            _enquiryService.UpdateEnquiry(data); // Call service to update course

            return RedirectToAction(nameof(Enquiry)); // Redirect after successful edit
        }

        return View(modified); // If model state is invalid, return the same view with errors
    }

    // GET: Displays enquiries for a specific course  
    [HttpGet]
    public IActionResult ShowEnquiry(int id)
    {
        int courseid = id;    // Fetch enquiries related to the specified course ID
        var enquiryCourses = _enquiryService.GetEnquiryByCourseId(courseid);      
        return View(enquiryCourses);       // Return the view with the enquiries for the course
    }

    // GET: Displays the form to add a new enquiry
    [HttpGet]
    public IActionResult AddEnquiry(int id)
    {

        // Create a new enquiry object with default values   
        Enquiry enrollment = new Enquiry()
        {
            CourseId=id,    // Set the course ID
            UserId=Convert.ToInt32(HttpContext.Session.GetString("UserId")), // Get the user ID from session 
            Status="In Progress",   // Default status
            Response="Pending"     // Default response

            };
        return View(enrollment);
    }

    // POST: Handles the submission of the new enquiry form
    [HttpPost]
    public IActionResult AddEnquiry(Enquiry enquiry,int Id)
    {
         enquiry.UserId=Convert.ToInt32(HttpContext.Session.GetString("UserId"));   // Set the user ID and course ID for the enquiry
         enquiry.CourseId=Id;     
        _enquiryService.CreateEnquiry(enquiry);        // Call service to create a new enquiry
        return RedirectToAction("CourseList","Course");    // Redirect to the course list after successful addition
    }
    
    // GET: Displays enquiries made by the current user
    [HttpGet]
    public IActionResult MyEnquiry()
    {
        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Get the user ID from session
    
        var enquiries = _enquiryService.MyEnquiry(id);     // Fetch enquiries made by the user
        return View(enquiries);
    }

    

}