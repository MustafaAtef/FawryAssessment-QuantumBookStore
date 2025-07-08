using System;
using QuantumBookStore.Services;

namespace QuantumBookStore.Models;

public class PaperBook : Book
{
    public int Stock { get; set; }
    public PaperBook(string ISBN, string title, DateOnly publishedYear, decimal price, int stock) : base(ISBN, title, publishedYear, price)
    {
        Stock = stock;
    }
    public override decimal Buy(int quantity, string email, string address)
    {
        if (quantity > Stock)
        {
            throw new Exception("Not enough stock available.");
        }

        Stock -= quantity;
        return Price * quantity;
    }
}
