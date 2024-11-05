using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using BookWise.Infrastructure.Services;
using MediatR;

namespace BookWise.Application.Commands.User.LoginUser;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, ResultViewModel<LoginUserViewModel>>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;

    public LoginUserHandler(IUserRepository userRepository, IAuthService authService)
    {
        _userRepository = userRepository;
        _authService = authService;
    }

    public async Task<ResultViewModel<LoginUserViewModel>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var passwordHash = _authService.ComputeSha256Hash(request.Password);

        var user = await _userRepository.GetUserByEmailAndPasswordAsync(request.Email, passwordHash);

        if (user is null)
        {
            return ResultViewModel<LoginUserViewModel>.Error("E-mail ou senha incorretos, tente novamente");
        }
        
        var token = _authService.GenerateJwtToken(user.Email);

        return ResultViewModel<LoginUserViewModel>.Success(new LoginUserViewModel(user.Email, token));
    }
}