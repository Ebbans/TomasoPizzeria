using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Repos
{
    public class CategoryRepo : ICategoryRepo
    {
        private readonly TomasoDbContext _context;

        public CategoryRepo(TomasoDbContext context)
        {
            _context = context;
        }

   
        public List<Category> GetAllCategories()
        {
            return _context.Category.ToList();
        }

        public void CreateCategory(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
        }


    }
}
