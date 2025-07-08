
using QuantumBookStore.Models;

Console.WriteLine("Running All Tests...");
Console.WriteLine();
Console.WriteLine("Testing Add Duplicate Book...");
BookStoreTesting.TestAddDuplicateBook();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Remove Outdated Books...");
BookStoreTesting.TestRemoveOutDatedBooks();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Buy Quantity Greater Than Book Stock...");
BookStoreTesting.TestBuyQuanitiyGreaterThanBookStock();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Buy Not found Book...");
BookStoreTesting.TestBuyNotFoundBook();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Buy Paper Book...");
BookStoreTesting.TestBuyPaperBook();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Buy EBook...");
BookStoreTesting.TestBuyEBook();
Console.WriteLine("**********************************");
Console.WriteLine("Testing Buy Demo Book...");
BookStoreTesting.TestBuyDemoBook();
Console.WriteLine("**********************************");
Console.WriteLine();
Console.WriteLine("Finished All Tests");

