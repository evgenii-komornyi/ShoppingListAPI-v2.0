using Models;
using ShoppingListDAL.Data;

namespace ShoppingListDAL.Repositories
{
    public class FileStorageRepository : IFileStorageRepository
    {
        readonly ShoppingListContext _context;

        public FileStorageRepository(ShoppingListContext context)
        {
            _context = context;
        }

        public int Create(FileStorage file)
        {
            _context.Files.Add(file);
            _context.SaveChanges();

            return file.Id;
        }
    }
}
