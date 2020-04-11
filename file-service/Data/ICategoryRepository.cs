using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;

namespace file_service.Data
{
    public interface ICategoryRepository
    {
         Task<bool> CreateCategory(int projectId, Category category);
         Task<bool> ExistCategory(string categoryName);
         Task<PagedList<Category>> GetCategories(int projectId, CategoryParams categoryParams);
         Task<Category> GetCategory(int id);
         Task<bool> SaveAll();
    }
}