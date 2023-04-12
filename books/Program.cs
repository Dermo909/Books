using books.Data;
using books.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);


// Set up Cors to allow acess from any origin
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_allowAllOrigins",
    builder =>
    {
        builder
        .AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});
builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            options.JsonSerializerOptions.IgnoreNullValues = true;
            options.JsonSerializerOptions.IncludeFields = true;
        }); 

// Add swagger functionality for testing of API layer
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Read the configuration settings from appsettings.json
builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", false, true)
    .AddEnvironmentVariables();

// Configure services for dependency injection
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IReadingListService, ReadingListService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IGenreService, GenreService>();

// Configure database context and create connection to database from connection string
builder.Services.AddDbContext<BookContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
