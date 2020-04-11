using System.Linq;
using System.Threading.Tasks;
using file_service.Helpers;
using file_service.Models;
using file_service.Params;
using Microsoft.EntityFrameworkCore;

namespace file_service.Data
{
	public class CategoryRepository : ICategoryRepository
	{
		private readonly DataContext _context;
		public CategoryRepository(DataContext context)
		{
			_context = context;
		}
		public async Task<bool> CreateCategory(int projectId, Category category)
		{
			var project = await _context.Projects.Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == projectId);

			project.Category.Add(category);

			if (await _context.SaveChangesAsync() > 0)
				return true;

			return false;
		}

		public async Task<bool> ExistCategory(string categoryName)
		{
			if (await _context.Categories.AnyAsync(c => c.Name == categoryName))
			{
				return true;
			}

			return false;
		}

		public async Task<PagedList<Category>> GetCategories(int projectId, CategoryParams categoryParams)
		{
			var categroies = _context.Categories.AsQueryable();

			categroies = categroies.Where(c => c.ProjectId == projectId);

			return await PagedList<Category>.CreateAsync(categroies, categoryParams.PageNumber, categoryParams.PageSize); 
		}

		public async Task<Category> GetCategory(int id)
		{
			var category = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);

			return category;
		}

		public async Task<bool> SaveAll()
		{
			return await _context.SaveChangesAsync() > 0;
		}
	}
}