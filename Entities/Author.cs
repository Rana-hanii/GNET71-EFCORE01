namespace GNET71_EFCORE01.Entities;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Biography { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public List<Book> Books { get; set; } = new();
}
