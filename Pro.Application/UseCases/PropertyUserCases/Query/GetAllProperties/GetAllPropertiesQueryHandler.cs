using MediatR;
using Pro.Application.Common.Errors;
using Pro.Application.Common.Results;
using Pro.Application.Specifications.PropertySpecifications;
using Pro.Domain.Interfaces.UOW;
using Pro.Domain.Models;

namespace Pro.Application.UseCases.PropertyUseCases.Query.GetAllProperties;

public class GetAllPropertiesQueryHandler
    : IRequestHandler<GetAllPropertiesQuery, ServiceResult<IEnumerable<object>>>
{
    private readonly IUOW uow;

    public GetAllPropertiesQueryHandler(IUOW _uow)
    {
        uow = _uow;
    }

    public async Task<ServiceResult<IEnumerable<object>>> Handle(GetAllPropertiesQuery request, CancellationToken cancellationToken)
    {
        var repo = uow.GetRepo<Property>();

        var result = await repo.GetAllAsync(new GetAllPropertiesSpecification());

        if (result == null || !result.Any())
        {
            return ServiceResult<IEnumerable<object>>.Failure(Error.NotFound("No Properties Found"), "NOT FOUND");
        }


        return ServiceResult<IEnumerable<object>>.Success(result, "Properties Retreived Successfuly");


    }
}
