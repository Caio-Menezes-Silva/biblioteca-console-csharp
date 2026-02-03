using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_console_csharp.Books_management.Models
{
    public class Book
    {
        private string _title;
        private int _publYear;
        private string _author;
        private string _isbn;
        private int _quantityInStock;
        protected bool validation;

        public Book() { }
        public Book(string title, int publYear, string author, string isbn, int quantityInStock)
        {
            Title = title;
            PublYear = publYear;
            Author = author;
            Isbn = isbn;
            QuantityInStock = quantityInStock;
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
                    throw new ArgumentException("Publication year must be a positive");
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
                }

            }
        }
        public int QuantityInStock
        {
            get { return _quantityInStock; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Quantity in stock cannot be negative");
                _quantityInStock = value;

            }
        }

        public bool Registration()
        {
            try
            {

                Console.Write("Type the book's name: ");
                Title = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Type the publication year: ");
                PublYear = int.Parse(Console.ReadLine());
                Console.WriteLine();

                Console.Write("Type the author: ");
                Author = Console.ReadLine();
                Console.WriteLine();

                Console.Write("Type the ISBN number (13 digits): ");
                Isbn = Console.ReadLine();
                Console.WriteLine();

                Console.Write("How many books will be added at stock? ");
                QuantityInStock = int.Parse(Console.ReadLine());
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

        public bool EstaDisponivel()
        {
            return _quantityInStock > 0;
        }
        public bool Emprestar()
        {
            if (_quantityInStock > 0)
            {
                _quantityInStock--;
                return true;
            }
            return false;
        }

        public void Devolver()
        {
            _quantityInStock++;
        }



        public override string ToString()
        {
            return $"Title: {_title}\n" +
                   $"Author: {_author}\n" +
                   $"Year: {_publYear}\n" +
                   $"ISBN: {_isbn}\n" +
                   $"Stock: {_quantityInStock}\n" +
                   $"Available: {(EstaDisponivel() ? "Yes" : "No")}";
        }
    }
}
