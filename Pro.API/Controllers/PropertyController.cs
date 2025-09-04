using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pro.API.Extentions;
using Pro.Application.DTOs.PropertyDtos;
using Pro.Application.UseCases.PropertyUseCases.Query.GetAllProperties;
using Pro.Application.UseCases.PropertyUserCases.Command.CreateNewProperty;
using Pro.Domain.Interfaces.Services;

namespace Pro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator mediator;
        private readonly IFileHandlerService fileHandlerService;

        public PropertyController(IMediator mediator, IFileHandlerService fileHandlerService)
        {
            this.mediator = mediator;
            this.fileHandlerService = fileHandlerService;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await mediator.Send(new GetAllPropertiesQuery());

            return result.ToActionResult();
        }

        [HttpPost("CreateNewProperty")]
        public async Task<IActionResult> CreateNewProperty([FromForm] CreateNewPeropertyDto createNewPeropertyDto)
        {
            var result = await mediator.Send(new CreateNewPeropertyCommand(createNewPeropertyDto));

            return result.ToActionResult();

        }

        public class Test2
        {
            public IFormFile file { get; set; } = default!;
        }





    }
}
