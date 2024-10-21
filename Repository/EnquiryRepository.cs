using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Edu_Hub_Project.Repository;

public class EnquiryRepository : IEnquiryService
{
    private readonly AppDbContext _context;


    public EnquiryRepository(AppDbContext context)
    {
        _context = context;
    }

    // Get all enquiries
    public List<Enquiry> GetAllEnquiry()
    {
        List<Enquiry> data = _context.Enquiries.ToList();
  
        return  data;
    }

    // Get a specific enquiry by its ID
    public Enquiry GetEnquiryById(int Id)
    {
        return _context.Enquiries
            .Where(e => e.EnquiryId == Id)
            .FirstOrDefault();
    }

    // Get all enquiries for a specific course
    public List<Enquiry> GetEnquiryByCourseId(int id)
    {
       return _context.Enquiries.Where(s => s.CourseId == id).ToList();
    }

    // Update an existing enquiry
     public void UpdateEnquiry(Enquiry enquiry)
    {
        _context.Enquiries.Update(enquiry); // Mark the entity as modified
        _context.SaveChanges(); // Save changes to the database
    }

    // Create a new enquiry
    public Enquiry CreateEnquiry(Enquiry enquiry)
    {
        
        _context.Enquiries.Add(enquiry);
        _context.SaveChanges();
        return enquiry;
    }

    // Get the first enquiry for a specific user
     public Enquiry GetEnquiryByUserId(int id)
     {
        return _context.Enquiries.FirstOrDefault(s => s.UserId ==id);
     }

    // Get all enquiries for a specific user
    public List<Enquiry> MyEnquiry(int id)
    {
        return _context.Enquiries.Where(e => e.UserId == id).ToList();
    }

  
}