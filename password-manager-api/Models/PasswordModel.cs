namespace password_manager_api.Models
{
    public class PasswordModel
    {
        public int ID { get; set; }
        public string? Password { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
    }
}
