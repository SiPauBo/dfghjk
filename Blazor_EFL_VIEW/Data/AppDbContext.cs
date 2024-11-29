using Blazor_EFL_VIEW.Classes;
using EntityFramework_Library.Classes;

namespace Blazor_EFL_VIEW.Data;

using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Librarian> Librarians { get; set; }
    public DbSet<BookLoan> BookLoans { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Item>()
            .HasDiscriminator<string>("ItemType")
            .HasValue<NonFiction>("NonFiction")
            .HasValue<Novel>("Novel")
            .HasValue<Textbook>("Textbook")
            .HasValue<Biography>("Biography")
            .HasValue<ScienceFiction>("ScienceFiction")
            .HasValue<Fantasy>("Fantasy")
            .HasValue<Mystery>("Mystery");

   
        modelBuilder.Entity<Person>()
            .HasDiscriminator<string>("PersonType")
            .HasValue<Author>("Author")
            .HasValue<Customer>("Customer")
            .HasValue<Librarian>("Librarian");

  
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);

     
        modelBuilder.Entity<BookLoan>()
            .HasKey(bl => new { bl.CustomerId, bl.BookId });

     
        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Customer)
            .WithMany(c => c.BookLoans)
            .HasForeignKey(bl => bl.CustomerId);

        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Book)
            .WithMany(b => b.BookLoans)
            .HasForeignKey(bl => bl.BookId);

        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.Librarian)
            .WithMany() 
            .HasForeignKey(bl => bl.LibrarianId);

        modelBuilder.Entity<BookLoan>()
            .HasOne(bl => bl.ReturnLibrarian)
            .WithMany() 
            .HasForeignKey(bl => bl.ReturnLibrarianId)
            .OnDelete(DeleteBehavior.Restrict); 

  
        modelBuilder.Entity<Book>()
            .HasOne(b => b.BookDetails)
            .WithOne(d => d.Book)
            .HasForeignKey<BookDetails>(d => d.BookId);

        base.OnModelCreating(modelBuilder);
    }
}
