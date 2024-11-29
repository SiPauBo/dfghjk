namespace EntityFramework_Library.Classes;

public class BookLoan
{
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } 

    public int BookId { get; set; }
    public Book Book { get; set; }

    public DateTime LoanDate { get; set; }
    public DateTime DueDate { get; set; }
    
    public int LibrarianId { get; set; } 
    public Librarian Librarian { get; set; } 

    public DateTime? ReturnDate { get; set; } 
    public int? ReturnLibrarianId { get; set; } 
    public Librarian ReturnLibrarian { get; set; } 
}