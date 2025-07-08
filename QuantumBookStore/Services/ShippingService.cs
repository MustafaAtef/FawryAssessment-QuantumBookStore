using System;
using QuantumBookStore.Models;

namespace QuantumBookStore.Services;

public class ShippingService
{
    public void ShipBook(PaperBook book, int quantity, string address)
    {
        // Logic to ship a paper book
        Console.WriteLine($"Shipping {quantity} copies of '{book.Title}' to {address}.");
    }

}
