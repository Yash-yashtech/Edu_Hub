
using Edu_Hub_Project.Models;

namespace Edu_Hub_Project.Services;

public interface IUserService
{
    // User CreateUser(User newuser);
    User GetStudent(string username, string password);

    User GetEduactor(string username, string password);
    User CreateUser(User newUser);
    User StudentData(int id);
    User EducatorData(int id);
}