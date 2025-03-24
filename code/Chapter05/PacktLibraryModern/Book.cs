using System.Diagnostics.CodeAnalysis;

namespace Packt.Shared;

public class Book
{
    public required string? Isbn; // setting required with nullable, means explicitly declared even if null
    public required string? Title;

    public string? Author;
    public int PageCount;

    // 2 constructors
    public Book(){}

    [SetsRequiredMembers]
    public Book(string? isbn, string? title)
    {
        Isbn = isbn;
        Title = title;
    }
}