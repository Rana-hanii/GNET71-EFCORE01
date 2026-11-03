using GNET71_EFCORE01.Data;
using GNET71_EFCORE01.Entities;
using Microsoft.EntityFrameworkCore;

namespace GNET71_EFCORE01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var db = new BookstoreContext();

            Console.WriteLine("Creating database...");
            db.Database.EnsureCreated();
            Console.WriteLine("Database is ready.");

            if (!db.Authors.Any())
            {
                var category = new Category
                {
                    Name = "Fiction",
                    Description = "Novels and short stories.",
                    IsActive = true
                };

                var author = new Author
                {
                    FirstName = "George",
                    LastName = "Orwell",
                    Email = "george.orwell@readmore.books",
                    Biography = "English novelist and essayist.",
                    DateOfBirth = new DateTime(1903, 6, 25)
                };

                db.Books.Add(new Book
                {
                    Title = "1984",
                    Isbn = "9780451524935",
                    Price = 12.99m,
                    NumberOfPages = 328,
                    YearPublished = 1949,
                    InStock = true,
                    Author = author,
                    Category = category
                });

                db.SaveChanges();
                Console.WriteLine("Sample data saved.");
            }

            var books = db.Books
                .Include(book => book.Author)
                .Include(book => book.Category)
                .ToList();

            foreach (var book in books)
            {
                Console.WriteLine(
                    $"{book.Title} by {book.Author.FirstName} {book.Author.LastName} " +
                    $"[{book.Category.Name}] - {book.Price:C} - In stock: {book.InStock}");
            }
        }
    }
}
