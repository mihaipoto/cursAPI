using CursminimalAPI.Data;
using CursminimalAPI.Models;
using CursminimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
{
    var cs = builder.Configuration.GetValue<string>("Database:ConnectionString");
    if (string.IsNullOrEmpty(cs))
        throw new Exception("Nu exista ConnectionString in apsettings");

    return new SqliteConnectionFactory(connectionstring: cs);
});
builder.Services.AddSingleton<DatabaseInitializer>();
builder.Services.AddSingleton<IBookService, BookService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost(
    "books",
    async (Book book, IBookService bookService) =>
    {
        var created = await bookService.CreateAsync(book);
        if (!created)
        {
            return Results.BadRequest(
                error: new { errorMessage = "O carte cu acelasi ISBSN deje exista" }
            );
        }
        return Results.Created($"/books/{book.Isbn}", book);
    }
);

//DB init here
var databaseInitializer = app.Services.GetRequiredService<DatabaseInitializer>();
await databaseInitializer.InitializeAsync();

app.Run();
