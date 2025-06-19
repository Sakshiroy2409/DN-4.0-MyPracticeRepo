using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public int BookId;
    public string Title;
    public string Author;

    public Book(int bookId, string title, string author)
    {
        BookId = bookId;
        Title = title;
        Author = author;
    }

    public void Display()
    {
        Console.WriteLine($"ID: {BookId}, Title: {Title}, Author: {Author}");
    }

    
    public int CompareTo(Book other)
    {
        return this.Title.CompareTo(other.Title);
    }
}

public class Library
{
    private List<Book> books = new List<Book>();

    public void AddBook(Book b)
    {
        books.Add(b);
    }

    
    public void LinearSearchByTitle(string title)
    {
        Console.WriteLine($"Linear Search Results for \"{title}\":");
        bool found = false;
        foreach (Book b in books)
        {
            if (b.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
            {
                b.Display();
                found = true;
            }
        }
        if (!found)
            Console.WriteLine("No book found.");
    }

    public void BinarySearchByTitle(string title)
    {
        Console.WriteLine($"Binary Search Result for \"{title}\":");
        books.Sort(); 
        int low = 0, high = books.Count - 1;
        while (low <= high)
        {
            int mid = (low + high) / 2;
            int cmp = books[mid].Title.CompareTo(title);
            if (cmp == 0)
            {
                books[mid].Display();
                return;
            }
            else if (cmp < 0)
                low = mid + 1;
            else
                high = mid - 1;
        }
        Console.WriteLine("No book found.");
    }

    public void DisplayAllBooks()
    {
        Console.WriteLine("\nAll Books in Library:");
        foreach (Book b in books)
        {
            b.Display();
        }
    }
}

class Program
{
    static void Main()
    {
        Library library = new Library();

        library.AddBook(new Book(101, "C# Programming", "John Doe"));
        library.AddBook(new Book(102, "Data Structures", "Jane Smith"));
        library.AddBook(new Book(103, "Algorithms", "Alan Turing"));
        library.AddBook(new Book(104, "Python Basics", "Guido van Rossum"));

        library.DisplayAllBooks();

        Console.WriteLine();
        library.LinearSearchByTitle("Data Structures");

        Console.WriteLine();
        library.BinarySearchByTitle("Python Basics");
    }
}