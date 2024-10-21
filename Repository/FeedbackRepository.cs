using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Edu_Hub_Project.Repository;
public class FeedbackRepository : IFeedbackService
{
    private readonly AppDbContext _context;

    public FeedbackRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<FeedbackUser> GetFeedback(int courseId)
    {
        
        var data = _context.getfeedbackusername.FromSqlInterpolated($"SP_UsernameFeedback {courseId}").ToList();
        return data;
    }

    public IEnumerable<Feedback> GetFeedbackByUserId(int id)
    {
        return _context.Feedbacks.Where(f => f.UserId == id);
    }
    public IEnumerable<Feedback> MyFeedback(int userId)
    {
        return _context.Feedbacks.Where(f => f.UserId == userId);
    }
    public Feedback AddFeedback(Feedback feedback)
    {
        _context.Feedbacks.Add(feedback);
        _context.SaveChanges();
        return feedback;

    }

    public IEnumerable<FeedbackUser> GetFeedback()
    {
        throw new NotImplementedException();
    }
}