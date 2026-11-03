using GNET71_EFCORE01.Entities;
using Microsoft.EntityFrameworkCore;

namespace GNET71_EFCORE01.Data;

public class BookstoreContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Book> Books => Set<Book>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost,1433;Database=ReadMoreBooks;User Id=sa;Password=ReadMore@Books1;TrustServerCertificate=True");
    }
}
