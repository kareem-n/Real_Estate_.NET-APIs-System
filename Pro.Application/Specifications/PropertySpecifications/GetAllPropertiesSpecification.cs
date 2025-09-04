using Pro.Domain.Models;
using Pro.Infrastructure.Services.Specification;

namespace Pro.Application.Specifications.PropertySpecifications
{
    public class GetAllPropertiesSpecification : ProjectionSpecification<Property, object>
    {

        public GetAllPropertiesSpecification()
        {

            AddProjection(x => new
            {
                x.Id,
                x.Name,
                x.Description,
                //x.PropertyImgPath
            });


        }


    }
}
