using Microsoft.AspNetCore.Http;
using Models.Requests;
using Models.Responses;

namespace ShoppingListBLL.Services
{
    public interface IFileStorageService
    {
        bool UploadFile(string webRootPath, IFormFile file, int id);
        FileStorageCreateResponse SaveFile(FileStorageCreateRequest request);
    }
}
