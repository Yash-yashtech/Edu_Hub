
using Edu_Hub_Project.Models;

namespace Edu_Hub_Project.Services;

public interface ICourseService
{
   List<Course> GetAllCourses();

   // List<Course> GetCoursesByID(int id);
   //User CreateCourse(Course newcourse);

   Course CreateCourse(Course newcourse);

   object GetCourseByUserId(int id);
   Course GetCourseById(int id);
   void UpdateCourse(Course course);
  
}