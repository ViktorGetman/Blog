using Blog.DAL;
using Blog.Extansions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews().AddRazorOptions(x =>
{
    x.ViewLocationFormats.Clear();
    x.ViewLocationFormats.Add("/PLL/Views/{1}/{0}.cshtml");
    x.ViewLocationFormats.Add("/PLL/Views/Shared/{0}.cshtml");
    x.ViewLocationFormats.Add("/PLL/Views/{0}.cshtml");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper();
builder.Services.AddBlogServices();
builder.Services.AddDbContextFactory<BlogDbContext>(x => x.UseSqlite(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
    });
builder.Services.AddAuthorization();



var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();

