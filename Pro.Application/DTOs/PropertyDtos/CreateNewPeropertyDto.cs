using Microsoft.AspNetCore.Http;

namespace Pro.Application.DTOs.PropertyDtos
{
    public record CreateNewPeropertyDto(
        string Name,
        string Description,
        IFormFile? PropertyImg
        )
    {
    }
}
