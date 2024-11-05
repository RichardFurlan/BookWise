using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Commands.Publisher.DeletePublisher;

public class DeletePublisherHandler : IRequestHandler<DeletePublisherCommand, ResultViewModel>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeletePublisherHandler(IPublisherRepository publisherRepository, IUnitOfWork unitOfWork)
    {
        _publisherRepository = publisherRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ResultViewModel> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByIdAsync(request.Id);

        if (publisher is null)
        {
            return ResultViewModel.Error("Editora não encontrada");
        }
        
        publisher.SetAsDeleted();
        
        _publisherRepository.Update(publisher);

        await _unitOfWork.SaveChangesAsync();

        return ResultViewModel.Success();
    }
}