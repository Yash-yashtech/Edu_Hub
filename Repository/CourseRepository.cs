
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Microsoft.AspNetCore.Mvc;

namespace Edu_Hub_Project.Repository;

// CourseRepository implements ICourseService to manage Course entities
public class CourseRepository : ICourseService
{
    private readonly AppDbContext _context;     // Database context to interact with the database

      // private readonly List<Course> _courses;
    
    // Constructor to initialize the CourseRepository with a database context
    public CourseRepository(AppDbContext context)
    {
        _context = context;
    }
 
    // Retrieves all courses from the database
    public List<Course> GetAllCourses()
    {
        List<Course> data = _context.Courses.ToList();     // Fetches all Course records from the database and converts them to a list
  
            return  data;
    }

    // public List<Course> GetCoursesByID(int id)
    //     {
    //         List<Course> data = _context.Courses.Where(x => x.UserId == id).ToList();
    //         return  data;
            
    //     }

    // Creates a new course in the database
    public Course CreateCourse(Course newCourse)
    {
        
        _context.Courses.Add(newCourse);      // Adds the new course to the context
        _context.SaveChanges();   // Saves changes to the database
        return newCourse;
    }

    // Retrieves courses associated with a specific user by user ID
    public object GetCourseByUserId(int id)
    {
            // Queries the database for courses where the UserId matches the provided ID
            var data = _context.Courses.Where(x => x.UserId == id).ToList();
            return  data;
    }

    // public object GetCourseByUserId(int id)
    // {
    //         var data = _context.Courses.Where(x => x.UserId == id).ToList();
    //         return  data;
    // }

    // Retrieves a specific course by its ID
    public Course GetCourseById(int id)
    {
        // Searches for a course with the specified CourseId
        return _context.Courses.FirstOrDefault(s => s.CourseId == id);
    }

    // Updates an existing course in the database
    public void UpdateCourse(Course course)
    {
        _context.Courses.Update(course); // Mark the entity as modified
        _context.SaveChanges(); // Save changes to the database
    }

    
}