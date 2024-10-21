
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Repository;

namespace Edu_Hub_Project.Services;

public interface IEnrollmentService
{
    Enrollment CreateEnroll(Enrollment enroll);
    string? GetEnrolledCourses(int userId);
    IEnumerable<EnrollmentCourse> GetEnrollCourse(int id);
    IEnumerable<Enrollment> GetEnrollmentByUserId(int id);
}