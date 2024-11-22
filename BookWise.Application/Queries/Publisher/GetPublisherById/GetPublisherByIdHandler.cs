using BookWise.Application.DTOs;
using BookWise.Core.Repositories;
using MediatR;

namespace BookWise.Application.Queries.Publisher.GetPublisherById;

public class GetPublisherByIdHandler : IRequestHandler<GetPublisherByIdQuery, ResultViewModel<PublisherViewModel>>
{
    private readonly IPublisherRepository _publisherRepository;

    public GetPublisherByIdHandler(IPublisherRepository publisherRepository)
    {
        _publisherRepository = publisherRepository;
    }

    public async Task<ResultViewModel<PublisherViewModel>> Handle(GetPublisherByIdQuery request, CancellationToken cancellationToken)
    {
        var publisher = await _publisherRepository.GetByIdAsync(request.Id);
        if (publisher is null)
        {
            return ResultViewModel<PublisherViewModel>.Error("Editora não encontrada");
        }
        
        var model = PublisherViewModel.FromEntity(publisher);

        return ResultViewModel<PublisherViewModel>.Success(model);
        
    }
}