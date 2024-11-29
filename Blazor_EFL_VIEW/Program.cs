using Blazor_EFL_VIEW.Classes;
using Blazor_EFL_VIEW.Components;
using Blazor_EFL_VIEW.Data;
using Domain.Interfaces;
using EntityFramework_Library.Classes; // Import your DbContext namespace
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Razor Components
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add DbContext with MySQL configuration
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

builder.Services.AddTransient<IRepository<Book>, BookRepository>();
builder.Services.AddTransient<IRepository<Author>, AuthorRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

public class AuthorRepository: Repository<Author>
{
    public AuthorRepository(AppDbContext context) : base(context)
    {
    }
}
public class BookRepository: Repository<Book>
{
    public BookRepository(AppDbContext context) : base(context)
    {

    }
}
