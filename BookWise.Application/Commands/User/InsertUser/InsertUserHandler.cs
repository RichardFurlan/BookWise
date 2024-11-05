using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using BookWise.Infrastructure.Services;
using MediatR;

namespace BookWise.Application.Commands.User.InsertUser;

public class InsertUserHandler : IRequestHandler<InsertUserCommand, ResultViewModel<int>>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthService _authService;

    public InsertUserHandler(IUserRepository userRepository, IAuthService authService, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _authService = authService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel<int>> Handle(InsertUserCommand request, CancellationToken cancellationToken)
    {
        var validationPassword  = _authService.ValidarSenha(request.Password, request.PasswordConfirm);
        if (!string.IsNullOrWhiteSpace(validationPassword))
            return ResultViewModel<int>.Error(validationPassword);

        var user = request.ToEntity(_authService);

        try
        {
            await _userRepository.AddAsync(user);

            var saveResult = await _unitOfWork.SaveChangesAsync();
            if(saveResult == 0)
                return ResultViewModel<int>.Error("Erro ao salvar o usuário. Nenhuma mudança foi detectada.");
            
            return ResultViewModel<int>.Success(user.Id);
        }
        catch (Exception ex)
        {
            return ResultViewModel<int>.Error($"Erro ao inserir usuário: {ex.Message}");
        }
    }
}