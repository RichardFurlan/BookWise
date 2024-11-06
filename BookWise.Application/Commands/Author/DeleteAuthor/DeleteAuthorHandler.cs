using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Author.DeleteAuthor;

public class DeleteAuthorHandler : IRequestHandler<DeleteAuthorCommand, ResultViewModel>
{    
    private readonly IAuthorRepository _authorRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAuthorHandler(IAuthorRepository authorRepository, IUnitOfWork unitOfWork)
    {
        _authorRepository = authorRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        var author = await _authorRepository.GetByIdAsync(request.Id);

        if (author is null)
        {
            return ResultViewModel.Error("Autor não encontrado");
        }
        
        author.SetAsDeleted();
        
        _authorRepository.Update(author);

        await _unitOfWork.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}