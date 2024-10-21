
using Edu_Hub_Project.Models;
using Edu_Hub_Project.Services;

namespace Edu_Hub_Project.Repository;

public class UserRepository : IUserService
{
    private readonly AppDbContext _context;
 
    public UserRepository(AppDbContext context)
    {
        _context = context;
    }
 
    public User CreateUser(User newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
        return newUser;
    }

    public User GetEduactor(string username, string password)
    {
        var data = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password&& u.Role=="Educator");
        return data;
    }

    public User GetStudent(string username, string password)
    {
        
        var data = _context.Users.SingleOrDefault(u => u.Username == username && u.Password == password&& u.Role=="Student");
        return data;
    }

    public User StudentData(int id)
    {
        
        var data = _context.Users.FirstOrDefault(u => u.UserId == id);
        return data;
    }

    public User EducatorData(int id)
    {
        var data = _context.Users.FirstOrDefault(e => e.UserId == id);
        return data;
    }

    
    
}