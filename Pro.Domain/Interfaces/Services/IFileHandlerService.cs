using Microsoft.AspNetCore.Http;
using Pro.Domain.Common;

namespace Pro.Domain.Interfaces.Services
{
    public interface IFileHandlerService
    {
        FileDescriper PrepareFile(IFormFile formFile, out FileDescriper fileDescriper);
        Task SaveAsync(IFormFile filePath, string fileFullPath);
    }
}
