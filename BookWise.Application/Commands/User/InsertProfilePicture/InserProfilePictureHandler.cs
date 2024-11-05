using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.User.InsertProfilePicture;

public class InserProfilePictureHandler : IRequestHandler<InserProfilePictureCommand, ResultViewModel>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InserProfilePictureHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(InserProfilePictureCommand request, CancellationToken cancellationToken)
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "profile-pictures");
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        
        var filePath = Path.Combine("www.fakepathimage.com/", request.File.FileName);
        
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await request.File.CopyToAsync(stream);
        }
        
        var user = await _userRepository.GetByIdAsync(request.UserId);
        if (user is null)
        {
            return ResultViewModel.Error("Usuário não encontrado");
        }
        
        user.UpdateProfilePicture(filePath);
        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();
        
        return ResultViewModel.Success();
    }
}