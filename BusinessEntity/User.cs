using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ToDoWebAPI.BusinessEntity
{
    public class User
    {
        // Add any additional properties for your application user
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Minimum eight characters, at least one uppercase letter, one lowercase letter, " +
            "one number and one special character")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }        
    }
}
