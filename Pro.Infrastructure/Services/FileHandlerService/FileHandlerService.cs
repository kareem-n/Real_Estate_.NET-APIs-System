using Microsoft.AspNetCore.Http;
using Pro.Domain.Common;
using Pro.Domain.Interfaces.Services;

namespace Pro.Infrastructure.Services.FileHandlerService
{
    public class FileHandlerService : IFileHandlerService
    {


        public readonly string _rootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        public FileDescriper PrepareFile(IFormFile filePath, out FileDescriper fileDescriper)
        {


            var uniqueName = $"{Guid.NewGuid()}_{Path.GetFileName(filePath.FileName)}";
            var fullPath = Path.Combine(_rootPath, uniqueName);

            var relativePath = Path.Combine("uploads", uniqueName);

            return fileDescriper = new FileDescriper(
                fullPath: fullPath,
                relativePath: relativePath,
                filName: uniqueName
            );



        }

        public async Task SaveAsync(IFormFile filePath, string fileFullPath)
        {

            if (!Directory.Exists(_rootPath))
            {
                Directory.CreateDirectory(_rootPath);
            }


            using (var stream = new FileStream(fileFullPath, FileMode.Create))
            {
                await filePath.CopyToAsync(stream);
            }

        }
    }
}
