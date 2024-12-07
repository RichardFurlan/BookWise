using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.Book.UpdateBook;

public class UpdateBookHandler : IRequestHandler<UpdateBookCommand, ResultViewModel>
{
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly BookDomainService _bookDomainService;

    public UpdateBookHandler(BookDomainService bookDomainService, IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _bookDomainService = bookDomainService;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var book = await _bookRepository.GetByIdAsync(request.Id);
            if (book == null)
                return ResultViewModel.Error("Livro não encontrado");

            _bookDomainService.UpdateBook(book, request.Title, request.Isbn, request.PublicationDate, request.Edition, request.Lenguage, request.NumberOfPage);
            _bookRepository.Update(book);

            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return ResultViewModel.Success();
        }
        catch (DomainException ex)
        {
            return ResultViewModel.Error(ex.Message);
        }
        catch (Exception ex)
        {
            return ResultViewModel.Error("Ocorreu um erro inesperado");
        }
    }
}