using System;
using System.Collections.Generic;
using System.Globalization;
using biblioteca_console_csharp.Books_management.Models;
using biblioteca_console_csharp.Models;
using biblioteca_console_csharp.Services;
using biblioteca_console_csharp.UI;

namespace biblioteca_console_csharp.Books_management.Models.UI
{
    internal class MainMenu
    {
        static void Main(string[] args)
        {
            BookUI bookUI = new BookUI();
            LibraryService LS = new LibraryService();
            int option = -1;

            Console.WriteLine("||Welcome to the Library Management System!||");
            Console.WriteLine();
            do
            {
                try
                {


                    Console.WriteLine();
                    Console.WriteLine("1 - Register a book;" +
                                    "\n2 - List all books;" +
                                    "\n3 - Find book by title;" +
                                    "\n4 - Find book by ISBN;" +
                                    "\n5 - Show available books;" +
                                    "\n6 - Close app");
                    Console.Write("Select the menu option: ");
                    option = int.Parse(Console.ReadLine());




                    switch (option)
                    {
                        case 1:
                            Book book = bookUI.Registration();

                            if (book != null)
                            {
                                LS.AddBook(book);
                            }

                            break;

                        case 2:
                            LS.ListAllBooks();
                            break;
                    }

                }
                catch (Exception ex) { Console.WriteLine("Invalid option, try again"); }
            } while (option != 6);
        }
    }
}
