# QuantumBookStore

Fawry Rise Journey

Full Stack Development Internship Challenge

A C# console application that demonstrates a book store inventory management system with support for different types of books and purchase operations.

## Project Structure

```
QuantumBookStore/
├── Models/
│   ├── Book.cs                 # Abstract base class for all books
│   ├── PaperBook.cs           # Physical book with stock management
│   ├── EBook.cs               # Digital book with file type
│   ├── DemoBook.cs            # Demo book (cannot be purchased)
│   ├── BookStore.cs           # Main bookstore management class
│   └── BookStoreTesting.cs    # Comprehensive test scenarios
├── Services/
│   ├── MailService.cs         # Email delivery service
│   └── ShippingService.cs     # Physical shipping service
├── Enumerations/
│   └── EBookFileType.cs       # E-book file format enumeration
└── Program.cs                 # Main entry point with test execution
```
