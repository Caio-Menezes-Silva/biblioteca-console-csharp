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
            return _books.FirstOrDefault(l =>
                l.Title.ToLower().Contains(title.ToLower()));
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

        public bool LoanBook(string isbn)
        {
            Book book = FindByIsbn(isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return false;
            }
            return book.BorrowBook();
        }

        public bool ReturnoBook(string isbn)
        {
            Book book = FindByIsbn(isbn);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return false;
            }
            book.ReturnBook();
            return true;
        }

        public bool UpdateBookStock(string isbn, int newQuantity)
        {
            Book book = FindByIsbn(isbn);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return false;
            }

            try 
            {
                book.UpdateStock(newQuantity);
                Console.WriteLine("Book stock updated successfully!");
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public int GetTotalBooksCount() { return _books.Count; }


        public List<Book> ObtainAvailableBooks() { return _books.Where(l => l.IsAvailable()).ToList(); }
    }
}