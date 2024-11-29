using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.User.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly UserDomainService _userDomainService;

    public UpdateUserHandler(UserDomainService userDomainService, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userDomainService = userDomainService;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return ResultViewModel.Error("Usuário não encontrado");
            
            _userDomainService.UpdateUser(user, request.FullName, request.BirthDate, request.Street, request.City, request.State, request.ZipCode, request.Country);
            _userRepository.Update(user);

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