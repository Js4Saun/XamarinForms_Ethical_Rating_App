using System;
using System.Collections.Generic;
using System.Text;

namespace Prototype.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User() 
        {

        }
        public User(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
        
    }
}
