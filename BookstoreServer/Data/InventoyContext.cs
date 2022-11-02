using BookstoreServer.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreServer.Data
{
    public class InventoyContext : DbContext
    {
        public DbSet<Book>? Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=<ServerName>;Database=Bookstore;Trusted_Connection=True;");
        }
    }
}
