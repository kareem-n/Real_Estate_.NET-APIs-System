namespace Pro.Domain.Common
{
    public record FileDescriper(
        string fullPath,
        string relativePath,
        string filName
    )
    {
    }
}
