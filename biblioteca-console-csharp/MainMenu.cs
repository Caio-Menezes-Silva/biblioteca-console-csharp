using System;
using System.Collections.Generic;
using System.Globalization;
using biblioteca_console_csharp.Books_management.Models;
using biblioteca_console_csharp.Models;
using biblioteca_console_csharp.Services;

namespace MyApp
{
    internal class MainMenu
    {
        static void Main(string[] args)
        {
            Book newBook = new Book();
            newBook.Registration();
        }


        


    }
}
