using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace biblioteca_console_csharp.gestao_livro
{
    public class Book
    {
        private string _title;
        private int _publYear;
        private string _author;
        private int _isbn;
        private int _quantityInStock = 0;

        public Book() { }
        public Book(string title, int publYear, string author, int isbn, int quantityInStock)
        {
            _title = title;
            _publYear = publYear;
            _author = author;
            _isbn = isbn;
            _quantityInStock = quantityInStock;
        }
        public void Registration()
        {
            Console.Write("Type the book's name: ");
            Title = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Type the publication year:");
            PublYear = int.Parse(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Type the author");
            Author = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Type the ISBN number:");
            Isbn = int.Parse(Console.ReadLine());
            Console.WriteLine();
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
        public int Isbn
        {
            get { return _isbn; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("ISBN must be a positive integer");
                _isbn = value;
            }
        }



        public override string ToString()
        {
            return $"Title: {_title},\nPublication Year: {_publYear},\nAuthor: {_author},\nISBN: {_isbn},\nQuantity in Stock: {_quantityInStock}";
        }
    }
}
