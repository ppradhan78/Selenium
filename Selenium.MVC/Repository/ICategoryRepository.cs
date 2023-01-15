using Selenium.MVC.Models;

namespace Selenium.MVC.Repository
{
    public interface ICategoryRepository
    {
        List<CategorySampleModel> GetList();
        CategorySampleModel GetById(int CategoryId);
        bool SaveCategory(CategorySampleModel input);
        bool DeleteCategory(int CategoryId);
    }
}
