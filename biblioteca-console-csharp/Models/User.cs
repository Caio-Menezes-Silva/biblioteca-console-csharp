using biblioteca_console_csharp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_console_csharp.Services;

namespace biblioteca_console_csharp.Models
{
    public class User
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _role;

        public User() { }
        public User(int id, string firstName, string lastName, string email, string password, string role)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Role = role;
        }


        public int Id
        {
            get { return _id; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("ID cannot be negative.");
                }
                else if (value == 0)
                {
                    throw new ArgumentException("ID cannot be zero. It will be assigned by the system.");
                }
                else if (value > 0)
                {
                    _id = value;
                }
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value.Length <= 2)
                {
                    throw new ArgumentException("First name must be at least 3 characters long.");
                }
                else if (string.IsNullOrWhiteSpace(value)){ throw new ArgumentNullException("First name cannot be null"); } 
                    _firstName = value;
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }

        public override string ToString()
        {
            return $"ID: {_id}\n" +
                   $"Name: {_firstName} {_lastName}\n" +
                   $"Email: {_email}\n" +
                   $"Role: {_role}";
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        

    }
}
