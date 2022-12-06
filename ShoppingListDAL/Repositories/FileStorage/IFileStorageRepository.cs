using Models;

namespace ShoppingListDAL.Repositories
{
    public interface IFileStorageRepository
    {
        int Create(FileStorage file);
    }
}
