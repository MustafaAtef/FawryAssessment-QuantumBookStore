using System;
using QuantumBookStore.Services;

namespace QuantumBookStore.Models;

public class BookStore
{
    private Dictionary<string, Book> _inventory;
    private readonly MailService _mailService;
    private readonly ShippingService _shippingService;
    public BookStore(MailService mailService, ShippingService shippingService)
    {
        _mailService = mailService;
        _shippingService = shippingService;
        _inventory = new Dictionary<string, Book>();
    }

    public void AddBook(Book book)
    {
        if (_inventory.ContainsKey(book.ISBN))
        {
            throw new Exception("Book with this ISBN already exists.");
        }
        _inventory[book.ISBN] = book;
    }

    public List<Book> RemoveOutDatedBooks(DateOnly thresholdDate)
    {
        var removedBooks = new List<Book>();
        foreach (var book in _inventory.Values)
        {
            if (book.PublishedYear < thresholdDate)
            {
                removedBooks.Add(book);
                _inventory.Remove(book.ISBN);
            }
        }
        return removedBooks;
    }

    public decimal BuyBook(string ISBN, int quantity, string email, string address)
    {
        if (!_inventory.ContainsKey(ISBN))
        {
            throw new Exception("Book not found.");
        }

        var book = _inventory[ISBN];
        var paid = book.Buy(quantity, email, address);
        Console.WriteLine($"Book purchased successfully: {book.Title}, Quantity: {quantity}, Total Price: {paid:C}");
        if (book is PaperBook paperBook)
        {
            _shippingService.ShipBook(paperBook, quantity, address);
        }
        else if (book is EBook eBook)
        {
            _mailService.SendBook(eBook, email);
        }
        return paid;
    }

}
