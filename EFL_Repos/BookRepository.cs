using System.Linq.Expressions;
using Blazor_EFL_VIEW.Classes;
using Blazor_EFL_VIEW.Components.Pages;
using Blazor_EFL_VIEW.Data;
using EntityFramework_Library.Classes;




using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace EFL_Repos;

public class BookRepository: Repository<Book>
{
    public BookRepository(AppDbContext context) : base(context)
    {

    }
}

public class AuthorRepository: Repository<Author>
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}
