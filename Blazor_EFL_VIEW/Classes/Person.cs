namespace EntityFramework_Library.Classes;

public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
   
    
    public DateTime DateOfBirth { get; set; }
}

public class Author : Person
{
    
    public string Biography { get; set; }

    public ICollection<Book> Books { get; set; } = new List<Book>(); 
}

public class Customer : Person
{
    public ICollection<BookLoan> BookLoans { get; set; } = new List<BookLoan>(); 
}

public class Librarian : Person
{                                                                                           
    public string EmployeeId { get; set; }

}