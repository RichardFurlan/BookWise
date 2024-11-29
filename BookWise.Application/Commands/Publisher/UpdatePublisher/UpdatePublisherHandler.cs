using BookWise.Application.Commands.User.UpdateUser;
using BookWise.Application.DTOs;
using BookWise.Core.Exceptions;
using BookWise.Core.Repositories;
using BookWise.Core.Services;
using MediatR;

namespace BookWise.Application.Commands.Publisher.UpdatePublisher;

public class UpdatePublisherHandler : IRequestHandler<UpdatePublisherCommand, ResultViewModel>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly PublisherDomainService _publisherDomainService;

    public UpdatePublisherHandler(IPublisherRepository publisherRepository, PublisherDomainService publisherDomainService, IUnitOfWork unitOfWork)
    {
        _publisherRepository = publisherRepository;
        _publisherDomainService = publisherDomainService;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var publisher = await _publisherRepository.GetByIdAsync(request.PublisherId);
            if (publisher == null)
                return ResultViewModel.Error("Editora não encontrada");

            _publisherDomainService.UpdatePublisher(publisher, request.Name, request.Street, request.City,
                request.State, request.ZipCode, request.Country);
            _publisherRepository.Update(publisher);

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