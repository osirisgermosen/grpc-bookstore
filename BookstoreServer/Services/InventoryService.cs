using Bookstore;
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

            BookResponse book = new BookResponse();
            book.BookId = 1;
            book.Title = "Just C#";
            book.Author = "Microsoft Learn";
            book.Isbn = "2-859595859-859";
            book.Year = 2022;

            return Task.FromResult(book);
        }

        public override Task<BookListResponse> GetBookList(BookListRequest request, ServerCallContext context)
        {
            _logger.LogInformation("Received request to: GetBookList");

            BookListResponse bookList = new BookListResponse();
            bookList.Books.Add(new BookResponse
            {
                Title = "Just C#",
                Author = "Microsoft Learn",
                Year = 2022
            });

            bookList.Books.Add(new BookResponse
            {
                Title = "EntityFramework.Core C#",
                Author = "Microsoft Learn",
                Year = 2021
            });

            return Task.FromResult(bookList);
        }
    }
}
