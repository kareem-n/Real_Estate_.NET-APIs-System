using Pro.Domain.Enums;

namespace Pro.Domain.Models
{
    public class Image : BaseEntity
    {
        public string Url { get; set; } = default!;

        public ImageTypes ImgType { get; set; }

        public int Size { get; set; }


    }
}
