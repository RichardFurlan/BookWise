using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Loan.InsertLoan;

public class InsertLoanHandler : IRequestHandler<InsertLoanCommand, ResultViewModel<int>>
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InsertLoanHandler(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository, IUnitOfWork unitOfWork)
    {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<int>> Handle(InsertLoanCommand request, CancellationToken cancellationToken)
    {
        var userExists = await _userRepository.ExistsByIdAsync(request.UserId);
        var bookExists = await _bookRepository.ExistsByIdAsync(request.BookId);
        if (!bookExists)
        {
            return ResultViewModel<int>.Error("O livro especificado não foi encontrado.");
        }
        if (!userExists)
        {
            return ResultViewModel<int>.Error("O usuario especificado não foi encontrado.");
        }

        var loan = request.ToEntity();

        await _loanRepository.AddAsync(loan);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return ResultViewModel<int>.Success(loan.Id);
    }
}