using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.Author.UpdateAuthor;

public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, ResultViewModel>
{
    private readonly IAuthorRepository _authorRepository;
    private readonly AuthorDomainService _authorDomainService;

    public UpdateAuthorHandler(IAuthorRepository authorRepository, AuthorDomainService authorDomainService)
    {
        _authorRepository = authorRepository;
        _authorDomainService = authorDomainService;
    }

    public async Task<ResultViewModel> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var author = await _authorRepository.GetByIdAsync(request.AuthorId);
            if (author == null)
                return ResultViewModel.Error("Autor não encontrado");

            _authorDomainService.UpdateAuthor(author, request.FullName, request.Biography);
            _authorRepository.Update(author);

            return ResultViewModel.Success();
        }
        catch (DomainException ex)
        {
            return ResultViewModel.Error(ex.Message);
        }
        catch (Exception ex)
        {
            // #TODO: Criar logger
            //_logger.LogError(ex, "Erro ao atualizar autor.");
            return ResultViewModel.Error("Ocorreu um erro inesperado.");
        }

    }
}