using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Edu_Hub_Project.Repository;

public class EnrollmentRepository : IEnrollmentService
{
    private readonly AppDbContext _context;


    public EnrollmentRepository(AppDbContext context)
    {
        _context = context;
    }
    public Enrollment CreateEnroll(Enrollment enroll)
    {
        
        _context.Enrollments.Add(enroll);
        _context.SaveChanges();
        return enroll;
    }

    public string? GetEnrolledCourses(int userId)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<EnrollmentCourse> GetEnrollCourse(int id)
        {
            var data = _context.getenrollmentcourse.FromSqlInterpolated($"SP_EnrolleCourses {id}");
            return data;
           
        }
    
    public IEnumerable<Enrollment> GetEnrollmentByUserId(int id)
    {
        return _context.Enrollments.Where(f => f.UserId == id);   
    }
 
}

