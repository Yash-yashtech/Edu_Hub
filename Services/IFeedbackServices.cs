
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Repository;

namespace Edu_Hub_Project.Services;

public interface IFeedbackService
{
     IEnumerable<FeedbackUser>  GetFeedback(int courseId);

     IEnumerable<Feedback> GetFeedbackByUserId(int id);
     IEnumerable<Feedback> MyFeedback(int userId);
     Feedback AddFeedback(Feedback feedback);
}
