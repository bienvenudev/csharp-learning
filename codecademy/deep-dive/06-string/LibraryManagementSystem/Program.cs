using System;
using System.Collections.Generic;

namespace LibraryManagementSystem{
    class Program {
        static void Main() {
            // Initialize library
            Library library = new Library();

            // Add some sample books
            Book b1 = new () {Title = "1984", Author = "George Orwell"};

            Book b2 = new () {Title = "To Kill a Mockingbird", Author = "Harper Lee"};

            library.AddBook(b1);
            library.AddBook(b2);

            // Search for a book
            List<Book> results = library.SearchBooksByTitle("1984");

            foreach (Book book in results)
            {
                Console.WriteLine(book.Title);
                Console.WriteLine(book.Author);
            }

            // Display all books
            Console.WriteLine("Displaying all books:");
            library.DisplayAllBooks(); 
        }
    }
}