using BookWise.Core.Entities;
using BookWise.Core.Repositories;

namespace BookWise.Core.Services;

public class BookDomainService
{
    private readonly IAuthorRepository _authorRepository;

    public BookDomainService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public async Task AddAuthorsAsync(Book book, List<int> authorIds)
    {
        var authors = await _authorRepository.GetByIdsAsync(authorIds);
        if (authors.Count != authorIds.Count)
        {
            var missingIds = authorIds.Except(authors.Select(a => a.Id)).ToList();
            throw new KeyNotFoundException($"Os seguintes autores não foram encontrados: {string.Join(", ", missingIds)}"); 
        }
        
        foreach (var author in authors)
        {
            book.AddAuthor(author);
        }
    }
}