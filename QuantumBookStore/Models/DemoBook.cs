using System;

namespace QuantumBookStore.Models;

public class DemoBook : Book
{
    public DemoBook(string ISBN, string title, DateOnly publishedYear, decimal price)
        : base(ISBN, title, publishedYear, price)
    {
    }
    public override decimal Buy(int quantity, string email, string address)
    {
        throw new Exception("This is a demo book. Cannot be purchased.");
    }
}
