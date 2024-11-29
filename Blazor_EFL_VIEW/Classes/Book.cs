namespace EntityFramework_Library.Classes;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ISBN { get; set; }
    public DateTime PublishedDate { get; set; }
    public string BookType { get; set; }

    public int AuthorId { get; set; } 
    public Author Author { get; set; } 

    public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>(); 
    public BookDetails BookDetails { get; set; } 
}

public class BookDetails
{
    public int Id { get; set; } 
    public int TotalCopies { get; set; }
    public int BorrowedCopies { get; set; }
    public int AvailableCopies { get; set; }

    public int BookId { get; set; } 
    public Book Book { get; set; } 
}