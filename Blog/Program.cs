using Blog.DAL;
using Blog.Extansions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NLog.Web;
using NLog;
using Microsoft.AspNetCore.Diagnostics;

IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper();
builder.Services.AddBlogServices();
builder.Services.AddDbContextFactory<BlogDbContext>(x => x.UseSqlite(connectionString));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Authorization";

        options.AccessDeniedPath = "/error/403";
    });
builder.Services.AddAuthorization();

builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
///app.UseExceptionHandler("/Error/500");

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseExceptionHandler(errorApp =>
{
    var logger = errorApp.ApplicationServices.GetService<Microsoft.Extensions.Logging.ILogger<Program>>();
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var error = exceptionHandlerPathFeature?.Error;
        if (error != null)
        {
            logger?.LogError(error, "При обработке запроса произошла непредвиденная ошибка");
        }
        context.Response.StatusCode=500;
    });
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();

