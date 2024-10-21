using System.ComponentModel.DataAnnotations;


namespace Edu_Hub_Project;

public class Login
    {
        [Key]

        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }