using LibraryAPI.Data;
using LibraryAPI.Models;
using LibraryAPI.Repositories;
using Microsoft.EntityFrameworkCore;

var AllowSpecificationOrigins = "_allowSpecificationOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowSpecificationOrigins,
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});


// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LibraryContext>(options => options.UseInMemoryDatabase("LibraryDB"));
builder.Services.AddScoped<IBookRepository, BookRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(AllowSpecificationOrigins);

app.UseHttpsRedirection();

var bookGroup = app.MapGroup("/api/books");

bookGroup.MapGet("/", async (IBookRepository bookRepository) =>
{
    var books = await bookRepository.GetAllBooksAsync();
    return Results.Ok(books);
}).WithOpenApi();

bookGroup.MapPost("/", async (IBookRepository bookRepository, Book book) =>
{
    if (book == null || book.Copies < 1)
    {
        return Results.BadRequest("Invalid book data.");
    }

    book.AvailableCopies = book.Copies;
    await bookRepository.AddBookAsync(book);
    return Results.Created($"/api/books/{book.Id}", book);
}).WithOpenApi();

bookGroup.MapDelete("/{id:int}", async (IBookRepository bookRepository, int id) =>
{
    var book = await bookRepository.GetBookByIdAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }

    await bookRepository.DeleteBookAsync(id);
    return Results.NoContent();
}).WithOpenApi();

bookGroup.MapPost("/{id:int}/lend", async (IBookRepository bookRepository, int id) =>
{
    try
    {
        await bookRepository.LendBookAsync(id);
        return Results.NoContent();
    }
    catch (KeyNotFoundException e)
    {
        return Results.BadRequest(e.Message);
    }
}).WithOpenApi();

bookGroup.MapPost("/{id:int}/return", async (IBookRepository bookRepository, int id) =>
{
    try
    {
        await bookRepository.ReturnBookAsync(id);
        return Results.NoContent();
    }
    catch (KeyNotFoundException e)
    {
        return Results.BadRequest(e.Message);
    }
}).WithOpenApi();

app.Run();
