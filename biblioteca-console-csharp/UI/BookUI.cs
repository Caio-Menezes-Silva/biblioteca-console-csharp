using System;
using biblioteca_console_csharp.Models;


namespace biblioteca_console_csharp.UI
{
    public class BookUI
    {
        public bool Registration()
        {
            try
            {
                Book book = new Book();
                Console.Write("Type the book's name: ");
                book.Title = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Type the publication year: ");
                book.PublYear = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Type the author: ");
                book.Author = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Type the ISBN number (13 digits): ");
                book.Isbn = Console.ReadLine();
                Console.WriteLine();

                Console.Write("How many books will be added at stock? ");
                book.QuantityInStock = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("The book has been added to the library");

                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
                return false;
            }
            catch (FormatException)
            {
                Console.WriteLine("\nInvalid input format!");
                return false;
            }
        }

    }
}


