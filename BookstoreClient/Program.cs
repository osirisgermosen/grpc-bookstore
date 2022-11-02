
using Bookstore;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7231");
var client = new Inventory.InventoryClient(channel);

#region Request GetBookById
var bookId = new BookByIdRequest() { BookId = 1 };
var book = await client.GetBookByIdAsync(bookId);

Console.WriteLine($"Title: {book.Title}");
Console.WriteLine($"Author: {book.Author}");
Console.WriteLine($"ISBN: {book.Isbn}");
Console.WriteLine($"Year: {book.Year}");
Console.ReadKey();
#endregion
