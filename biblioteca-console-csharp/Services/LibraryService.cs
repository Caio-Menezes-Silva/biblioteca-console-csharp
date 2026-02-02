using System;
using System.Collections.Generic;
using System.Linq;
using biblioteca_console_csharp.Models;

namespace biblioteca_console_csharp.Services.Models
{
    public class LibraryService
    {
        // Lista para armazenar todos os livros
        private List<Book> _books;

        // Construtor inicializa a lista vazia
        public LibraryService()
        {
            _books = new List<Book>();
        }

        // Adicionar livro à biblioteca
        public void AdicionarLivro(Book livro)
        {
            _books.Add(livro);
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        // Listar todos os livros
        public void ListarTodosLivros()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE LIVROS ===");
            for (int i = 0; i < _books.Count; i++)
            {
                Console.WriteLine($"\n--- Livro {i + 1} ---");
                Console.WriteLine(_books[i]);
            }
        }

        // Buscar livro por título
        public Book BuscarPorTitulo(string titulo)
        {
            return _books.FirstOrDefault(l => l.Title.ToLower().Contains(titulo.ToLower()));
        }

        // Buscar livro por ISBN
        public Book BuscarPorIsbn(string isbn)
        {
            return _books.FirstOrDefault(l => l.Isbn == isbn);
        }

        // Remover livro
        public bool RemoverLivro(string isbn)
        {
            Book livro = BuscarPorIsbn(isbn);
            if (livro != null)
            {
                _books.Remove(livro);
                Console.WriteLine("Livro removido com sucesso!");
                return true;
            }
            Console.WriteLine("Livro não encontrado.");
            return false;
        }

        // Obter quantidade de livros
        public int ObterTotalLivros()
        {
            return _books.Count;
        }
    }
}