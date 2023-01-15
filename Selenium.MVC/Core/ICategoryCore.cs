using Selenium.MVC.Models;

namespace Selenium.MVC.Core
{
    public interface ICategoryCore
    {
        List<CategorySampleModel> GetList();
        CategorySampleModel GetById(int CategoryId);
        bool SaveCategory(CategorySampleModel input);
        bool DeleteCategory(int CategoryId);
    }
}
