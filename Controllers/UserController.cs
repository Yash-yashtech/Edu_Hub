using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Edu_Hub_Project.Controllers;

// UserController handles user-related actions in the application
public class UserController : Controller
{
    private readonly AppDbContext _context;    // Database context for accessing the database
    private readonly IUserService _userservice;    // Service for user-related operations
    private readonly IWebHostEnvironment _hostingEnvironment;     // Environment information for file uploads

    // Constructor to initialize the UserController with the required services
    public UserController(IUserService userservice, IWebHostEnvironment hostingEnvironment)
    {
        _userservice = userservice;
        _hostingEnvironment = hostingEnvironment;
    }
    // Action method to display the main user index page
    public IActionResult Index()
    {
        return View();
    }

    // Action method to display the educator-specific index page
    public IActionResult EducatorIndex()
    {
        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));    // Get user ID from session
        var data = _userservice.EducatorData(id);       // Fetch educator data using the user ID
        return View(data);
    }

    // Action method to display the student-specific index page
    public IActionResult StudentIndex()
    {
        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));      // Get user ID from session
        // var data = _context.Users.FirstOrDefault(s => s.UserId == id);
        var data = _userservice.StudentData(id);     // Fetch student data using the user ID
        return View(data);
    }

    // GET action method to display the Add User form
    [HttpGet]
    public IActionResult AddUser()
    {
        // Create a list of user roles for the dropdown selection
        List<SelectListItem> userroles = new List<SelectListItem>()
        {
            new SelectListItem { Text = "Educator", Value = "Educator" },
            new SelectListItem{ Text="Student",Value="student"},
        };
        ViewBag.role = userroles;    // Pass the user roles to the view
        return View();
    }

    // POST action method to handle the submission of the Add User form
    [HttpPost]
    public IActionResult AddUser(UserViewModel model)
    {
      if (ModelState.IsValid)      // Check if the model state is valid
        {
            string uniqueFilename = null;      // Variable to hold the unique filename for the uploaded photo
            if (model.Photo != null)           // Check if a photo has been uploaded
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/");     // Define the uploads folder path
                uniqueFilename = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;             // Generate a unique filename
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);                       // Combine folder and filename to create the full path
                model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));                       // Save the uploaded photo to the server
            }

            // Create a new user object using the data from the model
            User newuser = new User
            {
              Username = model.Username,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role,
                MobileNo = model.MobileNo,
                ProfileImage = uniqueFilename   // Assign the unique filename for the profile image
            };
 
            _userservice.CreateUser(newuser);   // Call the service to create the new user
            
            return RedirectToAction("Index", "Home");     // Redirect to the home page after successful creation
        }
        return View();    // If model state is invalid, return the same view to show validation errors
        // _context.SaveChanges();
    }
    [HttpGet]
    public IActionResult Details()
    {
        var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        var data = _context.Users.FirstOrDefault(s => s.UserId == id);       // Fetch user details from the database   

        return View(data);
    }

    // GET action method to display the details of the logged-in user
    [HttpGet]

    public IActionResult ELogin()
    {

        return View();
    }

    // POST action method to handle the submission of the Educator login form
    [HttpPost]
    public IActionResult ELogin(Login model)
    {
        if (ModelState.IsValid)
        {
            // Attempt to retrieve the educator user based on the provided username and password
            User user = _userservice.GetEduactor(model.Username, model.Password);
            if (user != null)
            {
                // If a user is found, store the UserId in the session and the username in TempData
                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                TempData["Username"] = user.Username;
                return RedirectToAction("EducatorIndex", "User");      // Redirect to the EducatorIndex action of the User controller

            }
            // If no user is found, add an error to the model state
            ModelState.AddModelError("", "Invalid username or password.");
            return RedirectToAction("Index", "Home");
        }
        return View(model);
    }

    // GET action to display the student login page
    [HttpGet]

    public IActionResult SLogin()
    {

        return View();
    }

    // POST action to handle student login
    [HttpPost]
    public IActionResult SLogin(Login model)
    {
        if (ModelState.IsValid)
        {
            // Attempt to retrieve the student user based on the provided username and password
            User user = _userservice.GetStudent(model.Username, model.Password);

            if (user != null)
            {
                // Check the role of the retrieved user
                string userRole = user.Role;
                if (userRole == "Student")
                {   
                    // If the user is a student, store the UserId in the session and username in TempData
                    HttpContext.Session.SetString("UserId", user.UserId.ToString());
                    TempData["Username"] = user.Username;
                    // TempData["UserId"] = user.UserId;
                    return RedirectToAction("StudentIndex", "User");     // Redirect to the StudentIndex action of the User controller
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            // If no user is found, add an error to the model state
            ModelState.AddModelError("", "Invalid username or password.");
        }

        return View(model);        // If the model state is not valid, return the view with the current model
    }

    // Action to handle user logout
    public IActionResult Logout()
    {
         // Clear the session and any temporary data (commented out for now)
         // HttpContext.Session.Remove("User Id");
        // TempData["Username"] ;
        // Redirect to the Index action of the Home controller
        return RedirectToAction("Index", "Home");
    }
}

