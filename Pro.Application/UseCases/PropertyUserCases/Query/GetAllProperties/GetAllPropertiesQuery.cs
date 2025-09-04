using MediatR;
using Pro.Application.Common.Results;

namespace Pro.Application.UseCases.PropertyUseCases.Query.GetAllProperties;

public record GetAllPropertiesQuery : IRequest<ServiceResult<IEnumerable<object>>>
{
}
