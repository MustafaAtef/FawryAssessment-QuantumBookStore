
using QuantumBookStore.Enumerations;
using QuantumBookStore.Services;

namespace QuantumBookStore.Models;

public static class BookStoreTesting
{
    public static void TestAddDuplicateBook()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);

        var book1 = new PaperBook("123", "Test Book", new DateOnly(2021, 1, 1), 10.99m, 5);
        var book2 = new PaperBook("123", "Test Book 2", new DateOnly(2020, 1, 1), 18.99m, 15);

        try
        {
            store.AddBook(book1);
            // adding another book with the same ISBN should throw an exception
            store.AddBook(book2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void TestRemoveOutDatedBooks()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);

        var book1 = new PaperBook("111", "Book 1", new DateOnly(2005, 1, 1), 15.99m, 10);
        var book2 = new PaperBook("222", "Book 2", new DateOnly(2015, 1, 1), 20.99m, 5);
        var book3 = new PaperBook("333", "Book 3", new DateOnly(2013, 1, 1), 25.99m, 2);
        var book4 = new EBook("444", "EBook 1", new DateOnly(2018, 1, 1), 9.99m, EBookFileType.PDF);
        var book5 = new DemoBook("555", "Demo Book 1", new DateOnly(2022, 1, 1), 5.99m);

        store.AddBook(book1);
        store.AddBook(book2);
        store.AddBook(book3);
        store.AddBook(book4);
        store.AddBook(book5);

        var removed = store.RemoveOutDatedBooks(new DateOnly(2016, 1, 1));
        if (removed.Count != 3)
            throw new Exception("TestRemoveOutDatedBooks failed: Expected 2 books to be removed.");
        else
            Console.WriteLine($"{removed.Count} outdated books removed successfully.");
    }

    public static void TestBuyQuanitiyGreaterThanBookStock()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);
        var book = new PaperBook("123", "Test Book", new DateOnly(2021, 1, 1), 10.99m, 3);
        try
        {
            store.AddBook(book);
            // Attempting to buy more than available stock
            store.BuyBook("123", 10, "abc@test.com", "123 Test St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void TestBuyNotFoundBook()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);
        var book = new PaperBook("123", "Test Book", new DateOnly(2021, 1, 1), 10.99m, 3);
        try
        {
            store.AddBook(book);
            // Attempting to buy a book that does not exist in the inventory
            store.BuyBook("456", 10, "abc@test.com", "123 Test St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void TestBuyPaperBook()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);
        var book = new PaperBook("123", "Test Book", new DateOnly(2021, 1, 1), 10.99m, 5);
        try
        {
            store.AddBook(book);
            store.BuyBook("123", 2, "abc@test.com", "123 Test St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }

    public static void TestBuyEBook()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);
        var book = new EBook("123", "Test EBook", new DateOnly(2021, 1, 1), 10.99m, EBookFileType.PDF);
        try
        {
            store.AddBook(book);
            store.BuyBook("123", 1, "abc.test.com", "123 Test St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    public static void TestBuyDemoBook()
    {
        var mailService = new MailService();
        var shippingService = new ShippingService();
        var store = new BookStore(mailService, shippingService);
        var book = new DemoBook("123", "Test Book", new DateOnly(2021, 1, 1), 10.99m);
        try
        {
            store.AddBook(book);
            // Attempting to buy a demo book
            store.BuyBook("123", 1, "abc@test.com", "123 Test St");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
}
