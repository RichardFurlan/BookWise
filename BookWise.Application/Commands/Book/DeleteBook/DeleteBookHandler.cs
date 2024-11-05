using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Book.DeleteBook;

public class DeleteBookHandler : IRequestHandler<DeleteBookCommand, ResultViewModel>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBookHandler(IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
        {
            return ResultViewModel.Error("Livro não encontrado");
        }

        book.SetAsDeleted();
        
        _bookRepository.Update(book);

        await _unitOfWork.SaveChangesAsync();
        
        return ResultViewModel.Success();
    }
}