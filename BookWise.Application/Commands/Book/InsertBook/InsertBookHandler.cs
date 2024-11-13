using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.Book.InsertBook;

public class InsertBookHandler : IRequestHandler<InsertBookCommand, ResultViewModel<int>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IPublisherRepository _publisherRepository;
    private readonly BookDomainService _bookDomainService;
    private readonly IUnitOfWork _unitOfWork;

    public InsertBookHandler(IBookRepository bookRepository, IPublisherRepository publisherRepository, BookDomainService bookDomainService, IUnitOfWork unitOfWork)
    {
        _bookRepository = bookRepository;
        _publisherRepository = publisherRepository;
        _bookDomainService = bookDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<int>> Handle(InsertBookCommand request, CancellationToken cancellationToken)
    {
        if (!await _publisherRepository.ExistsByIdAsync(request.PublisherId))
            return ResultViewModel<int>.Error("A editora especificada não foi encontrada.");

        var book = request.ToEntity();

        try
        {
            await _bookDomainService.AddAuthorsAsync(book, request.AuthorsId);
            await _bookRepository.AddAsync(book);
            
            var saveResult = await _unitOfWork.SaveChangesAsync(cancellationToken);
            if (saveResult == 0)
                return ResultViewModel<int>.Error("Erro ao salvar o livro. Nenhuma mudança foi detectada.");
            
            return ResultViewModel<int>.Success(book.Id);
        }
        catch (KeyNotFoundException ex)
        {
            return ResultViewModel<int>.Error(ex.Message);
        }
    }
}