using MediatR;
using Pro.Application.Common.Results;
using Pro.Application.DTOs.PropertyDtos;

namespace Pro.Application.UseCases.PropertyUserCases.Command.CreateNewProperty
{
    public record CreateNewPeropertyCommand(CreateNewPeropertyDto CreateNewPeropertyDto) : IRequest<ServiceResult<object>>
    {
    }
}
