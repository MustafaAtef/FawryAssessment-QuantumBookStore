using System;
using QuantumBookStore.Enumerations;
using QuantumBookStore.Services;

namespace QuantumBookStore.Models;

public class EBook : Book
{
    public EBookFileType FileType { get; set; }
    public EBook(string ISBN, string title, DateOnly publishedYear, decimal price, EBookFileType fileType)
        : base(ISBN, title, publishedYear, price)
    {
        FileType = fileType;
    }
    public override decimal Buy(int quantity, string email, string address)
    {
        return Price;
    }
}
