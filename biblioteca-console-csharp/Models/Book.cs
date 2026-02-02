using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_console_csharp.Models
{
    public class Book
    {
        private string _title;
        private int _publYear;
        private string _author;
        private string _isbn;
        private int _quantityInStock = 0;
        protected bool validation;

        public Book() { }
        public Book(string title, int publYear, string author, string isbn, int quantityInStock)
        {
            Title = title;
            PublYear = publYear;
            Author = author;
            Isbn = isbn;
        }
        public bool Registration()
        {
            try
            {
                Console.Write("Type the book's name: ");
                Title = Console.ReadLine(); // Property já valida automaticamente!

                Console.Write("Type the publication year: ");
                PublYear = int.Parse(Console.ReadLine()); // Property valida!

                Console.Write("Type the author: ");
                Author = Console.ReadLine(); // Property valida!

                Console.Write("Type the ISBN number (13 digits): ");
                Isbn = Console.ReadLine(); // Property valida!
                Console.WriteLine("The book has been added to the library");

                return true;// Se chegou aqui, tudo foi validado!
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
        public string Title
        {
            get { return _title; }
            set
            {

                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Title cannot be empty");
                _title = value;
            }
        }
        public int PublYear
        {
            get { return _publYear; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Publication year must be a positive integer");
                _publYear = value;
            }
        }
        public string Author
        {
            get { return _author; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Author cannot be empty");
                _author = value;
            }
        }
        public string Isbn
        {
            get { return _isbn; }
            set
            {
                if (value.Length != 13) { throw new ArgumentException("ISBN must have 13 characters"); }
                else
                {
                    _isbn = value;
                    validation = true;
                }

            }
        }

        public int QuantityInStock { get; set; } = 0;



        public override string ToString()
        {
            return $"Title: {Title},\nPublication Year: {PublYear},\nAuthor: {Author},\nISBN: {Isbn},\nQuantity in Stock: {QuantityInStock}";
        }
    }
}
