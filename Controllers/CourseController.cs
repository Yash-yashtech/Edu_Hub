using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Edu_Hub_Project.Repository;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;



namespace Edu_Hub_Project.Controllers;

public class CourseController : Controller
{

    
    private readonly ICourseService _courseService;
    

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        private readonly AppDbContext _context;

        // public CourseController(AppDbContext context)
        // {
        //     _context = context;
        // }

        
        public IActionResult GetAllCourses()
        {
            return View(_courseService.GetAllCourses());
        }
         public IActionResult CourseList()
        {
            return View(_courseService.GetAllCourses());
        }


        // public IActionResult MyCourse()
        // {
            
        //     var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
        //     var data = _courseService.GetCoursesByID(id);
        //     return View(data);
        // }

        //----------------------------------

        [HttpGet]
    public IActionResult AddCourse()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddCourse(Course newcourse)
    {

        _courseService.CreateCourse(newcourse);
        return RedirectToAction("Index","Home");
    }

[HttpGet]
    public IActionResult MyCourse()
    {
       
            var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var data = _courseService.GetCourseByUserId(id);
            return View(data);
    }
    [HttpGet]
    public IActionResult Course()
    {

       
            var id = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var data = _courseService.GetCourseByUserId(id);
            return View(data);
    }

[HttpGet]
    public IActionResult Edit(int id)
        {
            if(id ==null)
             return View();
            else{
                var data =  _courseService.GetCourseById(id);
                if(data == null)
                    return NotFound();
                return View(data);
            }
        }
        [HttpPost]
        public IActionResult Edit(int id, Course modified)
        {
            if (ModelState.IsValid) // Validate model state
            {
                var data = _courseService.GetCourseById(id);
                if (data == null)
                {
                    return NotFound(); // Return 404 if course not found
                }

                // Update properties from modified object
                data.Title = modified.Title;
                data.Description = modified.Description; // Fixed this line
                data.Category = modified.Category;
                data.Level = modified.Level;

                _courseService.UpdateCourse(data); // Call service to update course

                return RedirectToAction(nameof(MyCourse)); // Redirect after successful edit
            }

            return View(modified); // If model state is invalid, return the same view with errors
        }

        [HttpGet]
        public IActionResult StudentDetails(int id)
        {
            var data = _courseService.GetCourseById(id); // Assuming this method fetches a single course by ID

            if (data == null)
            {
                return NotFound(); 
            }

            return View(data); // Ensure this is a single Course object
        }
        [HttpGet]
        public IActionResult EducatorDetails(int id)
        {
            var data = _courseService.GetCourseById(id); // Assuming this method fetches a single course by ID

            if (data == null)
            {
                return NotFound(); 
            }

            return View(data); // Ensure this is a single Course object
        }

        public IActionResult AddMaterial(int id)
        {
            Course course = _courseService.GetCourseById(id);
            HttpContext.Session.SetString("CourseId", course.CourseId.ToString());
            return RedirectToAction("AddMaterial","Material");
        }
}