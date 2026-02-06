using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using biblioteca_console_csharp.Models;

namespace biblioteca_console_csharp.UI
{
    public class UserUI
    {
        public User Registration()
        {
            try
            {
                Console.WriteLine("\n=== USER REGISTRATION ===");

                // Coleta os dados PRIMEIRO
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();

                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();

                Console.Write("Email: ");
                string email = Console.ReadLine();

                Console.Write("Password: ");
                string password = Console.ReadLine();

                Console.Write("Role (Admin/User): ");
                string role = Console.ReadLine();

                // ✅ VALIDA ANTES de criar o usuário
                if (string.IsNullOrWhiteSpace(firstName) ||
                    string.IsNullOrWhiteSpace(lastName) ||
                    string.IsNullOrWhiteSpace(email) ||
                    string.IsNullOrWhiteSpace(password) ||
                    string.IsNullOrWhiteSpace(role))
                {
                    throw new ArgumentException("All fields are required.");
                }

                
                return new User(0, firstName, lastName, email, password, role);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\n❌ Error: {ex.Message}");
                return null;
            }
        }



    }
}
