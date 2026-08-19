using System;
using System.Collections.Generic;

public class Book
{
  public string ISBN { get; set; }
  public string Title { get; set; }
  public string Author { get; set; }
  public string Category { get; set; }
  public bool IsCheckedOut { get; set; }

  public override string ToString()
  {
    return $"{Title} by {Author} (ISBN: {ISBN}, Category: {Category})";
  }
}

public class LibrarySystem
{
  private LinkedList<Book> _catalog;
  private Dictionary<string, List<Book>> _booksByCategory;
  private Stack<Book> _reshelveCart;
  
  public LibrarySystem()
  {
     _catalog = new LinkedList<Book>();
     _booksByCategory = new Dictionary<string, List<Book>>();
     _reshelveCart = new Stack<Book>();
     Console.WriteLine("Collections initialized: catalog, booksByCategory and reshelveCart");
  }

  public void AddBook(Book book)
  {
    _catalog.AddLast(book);
    if (!_booksByCategory.ContainsKey(book.Category)){
      _booksByCategory.Add(book.Category, new List<Book> {book});
      Console.WriteLine($"Book: {book.Title} is added to {book.Category} category");
    } 
    else
    {
      _booksByCategory[book.Category].Add(book);
    }
  }

  public void DisplayCatalog()
  {
    int count = 0;

    foreach (Book catal in _catalog)
    {
      Console.WriteLine($"Title: {catal.Title}, Author: {catal.Author}, ISBN: {catal.ISBN}, category: {catal.Category}");
      count++;
    }
    Console.WriteLine($"Total number of books: {count}");
  }

  public void DisplayBooksByCategory(string category)
  {
    if (_booksByCategory.ContainsKey(category))
    {
      foreach (var categ in _booksByCategory.Values)
      {
        foreach (var book in categ)
        {
          if (book.Category == category)
          {
            Console.WriteLine($"In Category: {category} we have:");
            Console.WriteLine($"Book: {book.Title}");
          }
        }
      }
    }
    else
    {
      Console.WriteLine($"Can't find {category} Category");
    }
  }

  public bool CheckoutBook(string isbn)
  {
    foreach (var book in _catalog)
    {
      if (book.ISBN == isbn)
      {
        if (book.IsCheckedOut == false)
        {
          book.IsCheckedOut = true;
          return true;  
        } 
        else
        {
          return false;
        }
      }
    }

    return false;
  }

  public bool ReturnBook(string isbn)
  {
    foreach (Book book in _catalog)
    {
      if (book.ISBN == isbn)
      {
        if (book.IsCheckedOut == true)
        {
          book.IsCheckedOut = false;
          _reshelveCart.Push(book);
          return true;  
        } 
        else
        {
          return false;
        }
      }
    }

    return false;
  }

  public void ProcessReshelveCart()
  {
    while (_reshelveCart.Count > 0)
    {
      Book removedBook = _reshelveCart.Pop();
      Console.WriteLine($"{removedBook.Title} has been reshelved");
    }
  }
}

class Program
{
  static void Main(string[] args)
  {
    Book book1 = new Book { 
      ISBN = "123", 
      Title = "Whispers of the Cosmic Winds", 
      Author = "Elena Starling",
      Category = "Science Fiction" 
    };
    
    Book book2 = new Book { 
      ISBN = "456", 
      Title = "The Last Algorithm", 
      Author = "Marcus Chen",
      Category = "Technology" 
    };

    var library = new LibrarySystem();


    Console.WriteLine("\n=== Add Books to Catalog ===");
    // Test add books here
    library.AddBook(book1);
    library.AddBook(book2);

    Console.WriteLine("\n=== Display Catalog ===");
    // Test catalog display here
    library.DisplayCatalog();

    Console.WriteLine("\n=== Display Books by Category ===");
    // Test category display here
    library.DisplayBooksByCategory("Science Fiction");
    library.DisplayBooksByCategory("Self-Help");

    Console.WriteLine("\n=== Test Book Circulation ===");

    // 1. Check out a book
    bool checkoutResult = library.CheckoutBook("123");
    if (checkoutResult)
        Console.WriteLine("Checkout successful.");
    else
        Console.WriteLine("Checkout failed.");

    // 2. Return the book
    bool returnResult = library.ReturnBook("123");
    if (returnResult)
        Console.WriteLine("Return successful.");
    else
        Console.WriteLine("Return failed.");

    // 3. Process the reshelve cart
    library.ProcessReshelveCart();
    Console.WriteLine("Reshelve cart processed.");

  }
}