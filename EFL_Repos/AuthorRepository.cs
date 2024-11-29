using Blazor_EFL_VIEW.Classes;
using Blazor_EFL_VIEW.Data;
using EntityFramework_Library.Classes;

namespace EFL_Repos;

public partial class AuthorRepository: Repository<Author>
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}