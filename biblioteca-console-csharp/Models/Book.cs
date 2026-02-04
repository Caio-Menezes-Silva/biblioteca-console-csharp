using System;


namespace biblioteca_console_csharp.Models
{
    public class Book
    {
      

        private string _title;
        private int _publYear;
        private string _author;
        private string _isbn;
        private int _quantityInStock;


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

        public bool IsAvailable() => QuantityInStock > 0;
        public override string ToString()
        {
            return $"Title: {_title}\n" +
                   $"Author: {_author}\n" +
                   $"Year: {_publYear}\n" +
                   $"ISBN: {_isbn}\n" +
                   $"Stock: {_quantityInStock}\n" +
                   $"Available: {(IsAvailable() ? "Yes" : "No")}";
            

        }
    }

}
