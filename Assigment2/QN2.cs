using System;
using System.Collections.Generic;

public class Book
{
    public string Code { get; set; }
    public string Name { get; set; }

    public Book(string code, string name)
    {
        Code = code;
        Name = name;
    }

    public override string ToString()
    {
        return $"Code: {Code}, Name: {Name}";
    }
}

public class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(string code, string name)
    {
        Book book = new Book(code, name);
        books.Add(book);
        Console.WriteLine($"Book added: {book}");
    }

    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books in the library.");
            return;
        }

        Console.WriteLine("\nBooks in the Library:");
        foreach (Book book in books)
        {
            Console.WriteLine(book);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        string code, name;

        while (true)
        {
            Console.WriteLine("\nEnter book details (or type 'exit' to finish):");
            Console.Write("Book Code: ");
            code = Console.ReadLine();

            if (code.ToLower() == "exit")
                break;

            Console.Write("Book Name: ");
            name = Console.ReadLine();

            library.AddBook(code, name);
        }

        library.DisplayBooks();
    }
}
