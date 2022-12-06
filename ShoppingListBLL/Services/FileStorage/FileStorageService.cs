using Microsoft.AspNetCore.Http;
using Models;
using Models.Requests;
using Models.Responses;
using ShoppingListDAL.Repositories;

namespace ShoppingListBLL.Services
{
    public class FileStorageService : IFileStorageService
    {
        readonly IFileStorageRepository _repository;

        public FileStorageService(IFileStorageRepository repository)
        {
            _repository = repository;
        }

        public bool UploadFile(string webRootPath, IFormFile file, int id)
        { 
            string uploads = Path.Combine(webRootPath, "images", "products", $"product-{id}");
           
            var filePath = Path.Combine(uploads, file.FileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            if (!File.Exists(filePath))
            {
                file.CopyToAsync(new FileStream(filePath, FileMode.Create));
                return true;
            } else
            {
                return false;
            }
        }

        public FileStorageCreateResponse SaveFile(FileStorageCreateRequest request)
        {
            var response = new FileStorageCreateResponse();

            FileStorage file = new FileStorage
            {
                ProductId = request.ProductId,
                Name = request.FileName,
            };

            response.FileId = _repository.Create(file);
            response.FileName = file.Name;

            return response;
        }
    }
}
