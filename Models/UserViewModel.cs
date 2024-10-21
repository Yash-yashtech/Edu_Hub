using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project.Models;

public class UserViewModel
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "User name required")]
        public string Username { get; set; }
        public string Role { get; set; }
        
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        // public string ProfileImage { get; set; }
        public IFormFile Photo { get; set; }
    }


