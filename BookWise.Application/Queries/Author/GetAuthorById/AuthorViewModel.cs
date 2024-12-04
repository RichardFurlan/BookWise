namespace BookWise.Application.Queries.Author.GetAuthorById;

public record AuthorViewModel(
    int Id,
    string FullName,
    string Biography,
    List<string> Books
)
{
    public static AuthorViewModel FromEntity(Core.Entities.Author entity)
        => new(
            entity.Id,
            entity.FullName,
            entity.Biography,
            entity.Books.Select(b => b.Title).ToList()
        );
}