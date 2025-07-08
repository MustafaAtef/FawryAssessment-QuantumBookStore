using System;
using QuantumBookStore.Models;

namespace QuantumBookStore.Services;

public class MailService
{

    public void SendBook(EBook eBook, string email)
    {
        // Logic to send an eBook via email
        Console.WriteLine($"Sending eBook '{eBook.Title}.{eBook.FileType}' via email to {email}.");
    }
}
