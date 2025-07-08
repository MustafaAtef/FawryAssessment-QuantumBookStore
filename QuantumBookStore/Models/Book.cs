using System;

namespace QuantumBookStore.Models;

public abstract class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public DateOnly PublishedYear { get; set; }
    public decimal Price { get; set; }
    public Book(string isbn, string title, DateOnly publishedYear, decimal price)
    {
        ISBN = isbn;
        Title = title;
        PublishedYear = publishedYear;
        Price = price;
    }
    public abstract decimal Buy(int quantity, string email, string address);
}
