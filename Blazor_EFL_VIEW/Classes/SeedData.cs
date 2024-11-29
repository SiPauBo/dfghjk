using System;
using System.Collections.Generic;
using System.Linq;
using Blazor_EFL_VIEW.Data;
using Microsoft.EntityFrameworkCore;
using EntityFramework_Library.Classes;

namespace EntityFramework_Library
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
             
                if (context.Books.Any() || context.Authors.Any() || context.Customers.Any() || context.Librarians.Any())
                {
                    return;
                }

                var authors = new List<Author>
                {
                    new Author { FirstName = "Jane", LastName = "Austen", Biography = "English novelist known for her novels on romantic fiction." },
                    new Author { FirstName = "George", LastName = "Orwell", Biography = "English novelist and essayist, journalist, and critic." }
                };
                context.Authors.AddRange(authors);

                var customers = new List<Customer>
                {
                    new Customer { FirstName = "Alice", LastName = "Smith", DateOfBirth = new DateTime(1985, 1, 10) },
                    new Customer { FirstName = "Bob", LastName = "Johnson", DateOfBirth = new DateTime(1992, 5, 23) }
                };
                context.Customers.AddRange(customers);

            
                var librarians = new List<Librarian>
                {
                    new Librarian { FirstName = "Emma", LastName = "Brown", EmployeeId = "LIB123" },
                    new Librarian { FirstName = "John", LastName = "Green", EmployeeId = "LIB124" }
                };
                context.Librarians.AddRange(librarians);

              
                var books = new List<Book>
                {
                    new Book
                    {
                        Title = "Pride and Prejudice",
                        ISBN = "111-222-333",
                        PublishedDate = new DateTime(1813, 1, 28),
                        BookType = "Novel",
                        Author = authors[0],
                        BookDetails = new BookDetails { TotalCopies = 5, BorrowedCopies = 2, AvailableCopies = 3 }
                    },
                    new Book
                    {
                        Title = "1984",
                        ISBN = "444-555-666",
                        PublishedDate = new DateTime(1949, 6, 8),
                        BookType = "ScienceFiction",
                        Author = authors[1],
                        BookDetails = new BookDetails { TotalCopies = 4, BorrowedCopies = 1, AvailableCopies = 3 }
                    }
                };
                context.Books.AddRange(books);

                
                var bookLoans = new List<BookLoan>
                {
                    new BookLoan
                    {
                        Customer = customers[0],
                        Book = books[0],
                        LoanDate = DateTime.Now.AddDays(-10),
                        DueDate = DateTime.Now.AddDays(10),
                        Librarian = librarians[0],
                        ReturnDate = null,
                        ReturnLibrarian = null
                    },
                    new BookLoan
                    {
                        Customer = customers[1],
                        Book = books[1],
                        LoanDate = DateTime.Now.AddDays(-5),
                        DueDate = DateTime.Now.AddDays(15),
                        Librarian = librarians[1],
                        ReturnDate = null,
                        ReturnLibrarian = null
                    }
                };
                context.BookLoans.AddRange(bookLoans);

               
                context.SaveChanges();
            }
        }
    }
}
