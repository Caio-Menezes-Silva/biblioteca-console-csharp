using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_console_csharp.Models;

namespace biblioteca_console_csharp.Services
{
    internal class UserService
    {
        List<User> _users;

        public UserService() { _users = new List<User>(); }

        public void AddUser(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user), "User cannot be null");
            }

            // Gera o próximo ID
            int newId = _users.Count + 1;

            // Cria novo usuário COM ID
            User userWithId = new User(
                newId,
                user.FirstName,
                user.LastName,
                user.Email,
                user.Password,
                user.Role
            );

            // Adiciona à lista
            _users.Add(userWithId);

            Console.WriteLine($"User added to system! ID: {newId}");
        }

        public void ListAllUsers()
        {
            if (_users.Count == 0)
            {
                Console.WriteLine("No users registered yet.");
                return;
            }
            Console.WriteLine("\n=== REGISTERED USERS ===");
            for (int i = 0; i < _users.Count; i++)
            {
                Console.WriteLine($"\n--- User {i + 1} ---");
                Console.WriteLine($"Name: {_users[i].FirstName} {_users[i].LastName}");
                Console.WriteLine($"Email: {_users[i].Email}");
                Console.WriteLine($"Role: {_users[i].Role}");
            }
        }

        public void FindUserByEmail(string email)
        {
            User user = _users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                Console.WriteLine("\n=== USER FOUND ===");
                Console.WriteLine($"Name: {user.FirstName} {user.LastName}");
                Console.WriteLine($"Email: {user.Email}");
                Console.WriteLine($"Role: {user.Role}");
            }
            else
            {
                Console.WriteLine("User not found with the provided email.");
            }
        }

        public bool RemoveUser(string email)
        {
            User user = _users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (user != null)
            {
                _users.Remove(user);
                Console.WriteLine("User removed successfully!");
                return true;
            }
            Console.WriteLine("User not found with the provided email.");
            return false;
        }

        public void IdGenerator()
        {
            int newId = _users.Count + 1;
            Console.WriteLine($"Generated User ID: {newId}");
        }


    }
}

