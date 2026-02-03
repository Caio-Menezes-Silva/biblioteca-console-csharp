using System;
using System.Collections.Generic;
using System.Linq;


namespace biblioteca_console_csharp.Books_management.Models
{
    public class LibraryService
    {
        private List<Book> _books;
        public LibraryService() { _books = new List<Book>(); }

        public void AddBook(Book livro)
        {
            _books.Add(livro);
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

        public Book FindByTitle(string titulo)
        {
            return _books.FirstOrDefault(l => l.Title.ToLower().Contains(titulo.ToLower()));
        }

        public Book FindByIsbn(string isbn)
        {
            return _books.FirstOrDefault(l => l.Isbn == isbn);
        }

        public bool RemoveBook(string isbn)
        {
            Book livro = FindByIsbn(isbn);
            if (livro != null)
            {
                _books.Remove(livro);
                Console.WriteLine("Book removed from the list!");
                return true;
            }
            Console.WriteLine("Book not found.");
            return false;
        }
        public int ShowBooksAtTotal() { return _books.Count; }

        public List<Book> ObtainAvailableBooks(){ return _books.Where(l => l.EstaDisponivel()).ToList(); }
    }
}