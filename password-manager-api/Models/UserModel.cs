﻿namespace password_manager_api.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? LoginPassword { get; set; }
    }
}