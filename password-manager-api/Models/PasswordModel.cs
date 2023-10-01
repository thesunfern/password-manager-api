using System.ComponentModel.DataAnnotations;

namespace password_manager_api.Models
{
    public class PasswordModel
    {
        public int ID { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? UserId { get; set; }
    }
}
