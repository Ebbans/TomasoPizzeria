using Inlämning1Tomaso.Data.DTOs;

namespace Inlämning1Tomaso.Data.Interface.Services
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAllCategories();

        CategoryDto CreateCategory(CategoryDto categoryDto);

    }
}
