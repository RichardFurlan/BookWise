using BookWise.Core.Entities;
using BookWise.Core.Exceptions;

namespace BookWise.Core.Services;

public class AuthorDomainService
{
    public void UpdateAuthor(Author author, string newFullName, string newBiography)
    {
        if (string.IsNullOrWhiteSpace(newFullName))
            throw new DomainException("Informe o nome do Autor");

        if (string.IsNullOrWhiteSpace(newBiography))
            throw new DomainException("Informe a biografia do Autor");

        author.UpdateFullName(newFullName);
        author.UpdateBiography(newBiography);
    }
}