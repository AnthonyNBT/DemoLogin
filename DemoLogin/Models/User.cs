using System.ComponentModel.DataAnnotations;

namespace DemoLogin.Models
{
    public class User
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
