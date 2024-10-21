
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Repository;

namespace Edu_Hub_Project.Services;

public interface IEnquiryService
{
    List<Enquiry> GetAllEnquiry();
    Enquiry GetEnquiryById(int Id);
    List<Enquiry> GetEnquiryByCourseId(int id);
    void UpdateEnquiry(Enquiry enquiry);
    // void ShowEnquiry(int id);
    Enquiry CreateEnquiry(Enquiry enquiry);
    Enquiry GetEnquiryByUserId(int id);
     public List<Enquiry> MyEnquiry(int id);



}