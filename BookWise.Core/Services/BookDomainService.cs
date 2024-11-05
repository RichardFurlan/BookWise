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
        foreach (var authorId in authorIds)
        {
            var author = await _authorRepository.GetByIdAsync(authorId);
            if (author == null)
            {
                throw new KeyNotFoundException($"Autor com ID {authorId} não encontrado."); 
            } 
            
            book.AddAuthor(author);
        }
    }
}