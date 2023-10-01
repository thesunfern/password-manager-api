using System.ComponentModel.DataAnnotations;

namespace password_manager_api.Models
{
    public class UserModel
    {
        [Required]
        public string UserId { get; set; }
        public string Username { get; set; }
        public string? Name { get; set; }
        public string? LoginPassword { get; set; }
    }
}
