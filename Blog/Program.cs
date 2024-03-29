using Blog.BLL.Extansions;
using Blog.DAL;
using Blog.Extensions;
using AspNetCore.Proxy;
using Blog.Infrastructure.JwtAuthentication.Services;
using Blog.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Microsoft.AspNetCore.Diagnostics;

IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();
var jwtTokenConfiguration = configuration.GetSection("JwtTokenValidation");
var connectionString = configuration.GetConnectionString("DefaultConnection");

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBlogBllServices();
builder.Services.AddAutoMapper();
builder.Services.AddDbContextFactory<BlogDbContext>(x => x.UseSqlite(connectionString));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new JwtTokenFactory(jwtTokenConfiguration).CreateValidationParameters();
    });
builder.Services.AddProxies();
builder.Services.AddAuthorization();
builder.Services.AddSession();
builder.Logging.ClearProviders();
builder.Host.UseNLog();

var app = builder.Build();

app.UseStaticFiles();

app.UseSession();
app.UseMiddleware<JwtMiddleware>();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePagesWithReExecute("/Error/{0}");
app.UseExceptionHandler(errorApp =>
{
    var logger = errorApp.ApplicationServices.GetService<ILogger<Program>>();
    errorApp.Run(context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var error = exceptionHandlerPathFeature?.Error;
        if (error != null)
        {
            logger?.LogError(error, "При обработке запроса произошла непредвиденная ошибка");
        }
        context.Response.StatusCode=500;
        return Task.CompletedTask;
    });
});
app.UseProxies(proxy =>
{
    proxy.Map("/api/{**catch-all}", destination =>
    {
        destination.UseHttp((context, _) =>
            $"https://localhost:7127{context.Request.Path.Value?.Replace("/api", "")}{context.Request.QueryString}");
    });
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();

