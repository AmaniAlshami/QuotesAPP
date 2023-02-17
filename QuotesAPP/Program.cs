using Microsoft.EntityFrameworkCore;
using QuotesAPP.DAL;
using QuotesAPP.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<QuoteContext>(options => options.UseSqlite("Data Source=./QouteDB.db;"));//builder.Configuration.GetConnectionString("QouteDBConnectionString")));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IQuoteService, QuoteService>();



var app = builder.Build();

// setting up the Homepage as the landing page  

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "Quote",
    pattern: "{controller=Quote}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "Author",
    pattern: "{controller=Author}/{action=Index}/{id?}");
app.Run();

