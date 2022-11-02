
using Bookstore;
using Grpc.Net.Client;

var channel = GrpcChannel.ForAddress("https://localhost:7231");
var client = new Inventory.InventoryClient(channel);

#region Add Book
var book = await client.AddBookAsync(new BookRequest()
{
    Book = new BookResponse()
    {
        Title = "Just JavaScript",
        Author = "Mozilla",
        Isbn = "21-8898982395-2",
        Year = 2022
    }
});

Console.WriteLine($"ID: {book.BookId}");
Console.WriteLine($"Title: {book.Title}");
Console.WriteLine($"Author: {book.Author}");
Console.WriteLine($"ISBN: {book.Isbn}");
Console.WriteLine($"Year: {book.Year}");
Console.ReadKey();
#endregion

#region Request GetBookById
//var bookId = new BookByIdRequest() { BookId = 1 };
//var book = await client.GetBookByIdAsync(bookId);

//Console.WriteLine($"Title: {book.Title}");
//Console.WriteLine($"Author: {book.Author}");
//Console.WriteLine($"ISBN: {book.Isbn}");
//Console.WriteLine($"Year: {book.Year}");
//Console.ReadKey();
#endregion

#region Request GetBookList
//var allBooks = new BookListRequest();
//var bookList = await client.GetBookListAsync(allBooks);

//foreach (var book in bookList.Books)
//{
//    Console.WriteLine($"Title: {book.Title}");
//    Console.WriteLine($"Author: {book.Author}");
//    Console.WriteLine($"ISBN: {book.Isbn}");
//    Console.WriteLine($"Year: {book.Year}");
//    Console.WriteLine(new String('*', 35));
//}
//Console.ReadKey();
#endregion
