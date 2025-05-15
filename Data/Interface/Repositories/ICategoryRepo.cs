using Inlämning1Tomaso.Data.Models;

namespace Inlämning1Tomaso.Data.Interface.Repositories
{
     public interface ICategoryRepo
     { 
           List<Category> GetAllCategories();

           void CreateCategory(Category category);

     }


}

