using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;

namespace file_service.Data
{
    public interface ICategoryRepository
    {
         Task<PagedList<Category>> CreateCategory(int projectId, string categoryName);
    }
}