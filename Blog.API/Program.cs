using Blog.API.Extensions;
using Blog.BLL.Extansions;
using Blog.DAL;
using Blog.Infrastructure.JwtAuthentication;
using Blog.Infrastructure.JwtAuthentication.Services;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Microsoft.AspNetCore.Authentication.JwtBearer;

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var jwtTokenConfiguration = configuration.GetSection("JwtTokenValidation");
var connectionString = configuration.GetConnectionString("DefaultConnection");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddBlogBllServices();
builder.Services.AddAutoMapper();
builder.Services.AddCors();
builder.Services.AddDbContextFactory<BlogDbContext>(x => x.UseSqlite(connectionString));
builder.Services.AddJwtAuthenticationService(jwtTokenConfiguration);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new JwtTokenFactory(jwtTokenConfiguration).CreateValidationParameters();
    });
builder.Logging.ClearProviders();
builder.Host.UseNLog();
builder.Services.AddDataProtection();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
    var logger = errorApp.ApplicationServices.GetService<ILogger<Program>>();
    errorApp.Run(async context =>
    {
        var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        var error = exceptionHandlerPathFeature?.Error;
        if (error != null)
        {
            logger?.LogError(error, "При обработке запроса произошла непредвиденная ошибка");
        }

        context.Response.StatusCode = 500;
    });
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();