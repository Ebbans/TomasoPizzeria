using Inlämning1Tomaso.Data.DTOs;
using Inlämning1Tomaso.Data.Interface.Repositories;
using Inlämning1Tomaso.Data.Interface.Services;
using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;

        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public List<CategoryDto> GetAllCategories()
        {
            return _categoryRepo.GetAllCategories()
                .Select(c => new CategoryDto
                {
                    //CategoryID = c.CategoryID,
                    CategoryName = c.CategoryName
                }).ToList();
        }

        public CategoryDto CreateCategory(CategoryDto categoryDto)
        {
            var category = new Category
            {
                CategoryName = categoryDto.CategoryName
            };

            _categoryRepo.CreateCategory(category);

            // Returnera DTO med ID (om du vill se det direkt i svaret)
            return new CategoryDto
            {
                //CategoryID = category.CategoryID,
                CategoryName = category.CategoryName
            };
        }

    }
}
