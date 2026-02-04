using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca_console_csharp.Models;


namespace biblioteca_console_csharp.Books_management.Models.UI
{
    public class LibraryService
    {
        private List<Book> _books;
        public LibraryService() { _books = new List<Book>(); }

        public void AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException("Book cannot be null");
            }
            _books.Add(book);
            Console.WriteLine("Book added successfully!");
        }

        // Listar todos os livros
        public void ListAllBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("No books registered yet.");
                return;
            }

            Console.WriteLine("\n=== LIBRARY BOOKS ===");
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"\n--- Book {i + 1} ---");
                Console.WriteLine(_books[i]);
            }
        }

        public Book FindByTitle(string title)
        {
            return _books.FirstOrDefault(l => l.Title.ToLower().Contains(title.ToLower()));
        }

        public Book FindByIsbn(string isbn)
        {
            return _books.FirstOrDefault(l => l.Isbn == isbn);
        }

        public bool RemoveBook(string isbn)
        {
            Book book = FindByIsbn(isbn);
            if (book != null)
            {
                _books.Remove(book);
                Console.WriteLine("Book removed from the list!");
                return true;
            }
            Console.WriteLine("Book not found.");
            return false;
        }
        public int ShowAllBooks()
        {

            if (_books.Count == 0) { throw new ArgumentNullException("The list is empty"); }
            return _books.Count;
        }

        public bool Loan(Book _books)
        {
            if (_books.QuantityInStock > 0)
            {
                _books.QuantityInStock--;
                return true;
            }
            return false;
        }

        public void Bring(Book _books)
        {
            _books.QuantityInStock++;
        }

        public List<Book> ObtainAvailableBooks() { return _books.Where(l => l.IsAvailable()).ToList(); }
    }
}