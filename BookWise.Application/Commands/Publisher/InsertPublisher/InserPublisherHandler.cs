using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using BookWise.Core.ValueObjects;
using MediatR;

namespace BookWise.Application.Commands.Publisher.InsertPublisher;

public class InserPublisherHandler : IRequestHandler<InsertPublisherCommand, ResultViewModel<int>>
{
    private readonly IPublisherRepository _publisherRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InserPublisherHandler(IUnitOfWork unitOfWork, IPublisherRepository publisherRepository)
    {
        _unitOfWork = unitOfWork;
        _publisherRepository = publisherRepository;
    }

    public async Task<ResultViewModel<int>> Handle(InsertPublisherCommand request, CancellationToken cancellationToken)
    {
        var publisher = request.ToEntity();

        await _publisherRepository.AddAsync(publisher);

        await _unitOfWork.SaveChangesAsync();

        return ResultViewModel<int>.Success(publisher.Id);
    }
}