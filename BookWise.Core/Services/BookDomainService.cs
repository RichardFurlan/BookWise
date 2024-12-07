using BookWise.Core.Entities;
using BookWise.Core.Enum;
using BookWise.Core.Exceptions;
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
            throw new DomainException($"Os seguintes autores não foram encontrados: {string.Join(", ", missingIds)}"); 
        }
        
        foreach (var author in authors)
        {
            book.AddAuthor(author);
        }
    }

    public void UpdateBook(
        Book book,
        string title,
        string isbn,
        DateTime publicationDate,
        int edition,
        EnumLenguage lenguage,
        int numberOfPage)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new DomainException("O título não pode ser vazio.");
        
        if (edition <= 0)
            throw new DomainException("A edição deve ser maior que zero.");
        
        if (numberOfPage <= 0)
            throw new DomainException("O número de páginas deve ser maior que zero.");

        book.UpdateDetails(title, isbn, edition, publicationDate ,lenguage, numberOfPage);
    }
}