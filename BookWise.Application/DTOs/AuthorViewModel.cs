using BookWise.Core.Entities;

namespace BookWise.Application.DTOs;

public record AuthorViewModel(
    int Id,
    string FullName,
    string Biography,
    List<string> Books
)
{
    public static AuthorViewModel FromEntity(Author entity)
        => new(
            entity.Id,
            entity.FullName,
            entity.Biography,
            entity.Books.Select(b => b.Title).ToList()
        );
}