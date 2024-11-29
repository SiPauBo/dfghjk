using Blazor_EFL_VIEW.Classes;
using Blazor_EFL_VIEW.Components;
using Blazor_EFL_VIEW.Data;
using Domain.Interfaces;
using EntityFramework_Library.Classes;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

var builder = WebApplication.CreateBuilder(args);

// DbContext mit MySQL konfigurieren
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 33)) 
    ));

// Razor Components hinzufügen
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Repositories registrieren
builder.Services.AddTransient<IRepository<Book>, BookRepository>();
builder.Services.AddTransient<IRepository<Author>, AuthorRepository>();

var app = builder.Build();

// Fehlerbehandlung für Produktionsumgebung
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

// Repositories
public class AuthorRepository : Repository<Author>
{
    public AuthorRepository(AppDbContext context) : base(context) { }
}

public class BookRepository : Repository<Book>
{
    public BookRepository(AppDbContext context) : base(context) { }
}