namespace Pro.Domain.Models
{
    public class Property : BaseEntity
    {
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public Guid? MainImgId { get; set; } = default!;
        public Image MainImg { get; set; } = default!;


    }
}
