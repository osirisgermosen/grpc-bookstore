using Bookstore;
using BookstoreServer.Data;
using BookstoreServer.Models;
using Grpc.Core;

namespace BookstoreServer.Services
{
    public class InventoryService : Inventory.InventoryBase
    {
        private ILogger<InventoryService> _logger;

        public InventoryService(ILogger<InventoryService> logger)
        {
            _logger = logger;
        }

        public override Task<BookResponse> GetBookById(BookByIdRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request to: GetBookById");

            BookResponse response = new BookResponse();

            using (var db = new InventoyContext())
            {
                var book = db.Books
                    .Where(b => b.Id == request.BookId).FirstOrDefault();

                if (book != null)
                {
                    response.BookId = book.Id;
                    response.Title = book.Title;
                    response.Author = book.Author;
                    response.Isbn = book.Isbn;
                    response.Year = book.Year;
                }                
            }

            return Task.FromResult(response);
        }

        public override Task<BookListResponse> GetBookList(BookListRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request to: GetBookList");

            BookListResponse response = new BookListResponse();

            using (var db = new InventoyContext())
            {
                var bookList = db.Books.ToList();

                if (bookList != null)
                {
                    foreach (var book in bookList)
                    {
                        response.Books.Add(new BookResponse()
                        {
                            BookId = book.Id,
                            Title = book.Title,
                            Author = book.Author,
                            Isbn = book.Isbn,
                            Year = book.Year
                        });
                    }
                }
            }

            return Task.FromResult(response);
        }

        public override Task<BookResponse> AddBook(BookRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request to: AddBook");

            BookResponse bookResponse = new BookResponse();

            using (var db = new InventoyContext())
            {
                var book = new Book()
                {
                    Title = request.Book.Title,
                    Author = request.Book.Author,
                    Isbn = request.Book.Isbn,
                    Year = request.Book.Year,
                };
                          
                db.Books.Add(book);
                db.SaveChanges();

                bookResponse.BookId = book.Id;
                bookResponse.Title = book.Title;
                bookResponse.Author = book.Author;
                bookResponse.Isbn = book.Isbn;
                bookResponse.Year = book.Year;
            }

           return Task.FromResult(bookResponse);
        }
    }
}
