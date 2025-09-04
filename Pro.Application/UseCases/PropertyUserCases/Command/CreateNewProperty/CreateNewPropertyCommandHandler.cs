using MediatR;
using Pro.Application.Common.Errors;
using Pro.Application.Common.Results;
using Pro.Domain.Common;
using Pro.Domain.Enums;
using Pro.Domain.Interfaces.Services;
using Pro.Domain.Interfaces.UOW;
using Pro.Domain.Models;

namespace Pro.Application.UseCases.PropertyUserCases.Command.CreateNewProperty
{
    public class CreateNewPropertyCommandHandler :
        IRequestHandler<CreateNewPeropertyCommand, ServiceResult<object>>
    {
        private readonly IUOW uow;
        private readonly IFileHandlerService fileHandlerService;

        public CreateNewPropertyCommandHandler(IUOW uow, IFileHandlerService fileHandlerService)
        {
            this.uow = uow;
            this.fileHandlerService = fileHandlerService;
        }


        public async Task<ServiceResult<object>> Handle(CreateNewPeropertyCommand request, CancellationToken cancellationToken)
        {

            var repo = uow.GetRepo<Property>();
            FileDescriper fileDescriper = null!;

            if (request.CreateNewPeropertyDto.PropertyImg != null)
            {
                fileHandlerService.PrepareFile(request.CreateNewPeropertyDto.PropertyImg, out fileDescriper);
            }

            Image img = null!;

            if (fileDescriper != null)
            {
                img = new Image
                {
                    ImgType = ImageTypes.PropertyImage,
                    Url = fileDescriper.relativePath,
                    Size = (int)request.CreateNewPeropertyDto.PropertyImg!.Length
                };
            }



            var prop = new Property
            {
                Name = request.CreateNewPeropertyDto.Name,
                Description = request.CreateNewPeropertyDto.Description,
                MainImg = img
            };

            await repo.AddAsync(prop);
            var result = await uow.SaveAsync();


            if (result > 0)
            {
                if (fileDescriper != null)
                {
                    await fileHandlerService.SaveAsync(request.CreateNewPeropertyDto.PropertyImg!, fileDescriper.fullPath);
                }

                return ServiceResult<object>.Success(prop, "created success");
            }
            else
            {
                return ServiceResult<object>.Failure(Error.BadRequest("Can not add"), "somthing went wrong");
            }



        }
    }
}
