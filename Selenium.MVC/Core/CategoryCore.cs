using Selenium.MVC.Models;
using Selenium.MVC.Repository;

namespace Selenium.MVC.Core
{
    public class CategoryCore : ICategoryCore
    {
        ICategoryRepository categoryRepository;
        public CategoryCore(ICategoryRepository _categoryRepository)
        {
            categoryRepository= _categoryRepository;
        }
        public bool DeleteCategory(int CategoryId)
        {
            if (CategoryId>0)
            {
              return  categoryRepository.DeleteCategory(CategoryId);
            }
            else
            {
                throw new ArgumentException("Invalide CategoryId");
            }
        }

        public CategorySampleModel GetById(int CategoryId)
        {
            if (CategoryId > 0)
            {
                return categoryRepository.GetById(CategoryId);
            }
            else
            {
                throw new ArgumentException("Invalide CategoryId");
            }
        }

        public List<CategorySampleModel> GetList()
        {
            return categoryRepository.GetList();
        }

        public bool SaveCategory(CategorySampleModel input)
        {
            if (input==null)
            {
                throw new ArgumentException("Invalide input");
            }
            return categoryRepository.SaveCategory(input);
        }
    }
}
