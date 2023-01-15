using Selenium.MVC.Models;

namespace Selenium.MVC.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private List<CategorySampleModel> categoryList = new List<CategorySampleModel>();

        public CategoryRepository()
        {
            categoryList.Add(new CategorySampleModel { CategoryID = 1, CategoryName = "Beverages", Description = "Soft drinks, coffees, teas, beers, and ales" });
            categoryList.Add(new CategorySampleModel { CategoryID = 2, CategoryName = "Condiments", Description = "Sweet and savory sauces, relishes, spreads, and seasonings" });
            categoryList.Add(new CategorySampleModel { CategoryID = 3, CategoryName = "Confections", Description = "Desserts, candies, and sweet breads" });
            categoryList.Add(new CategorySampleModel { CategoryID = 4, CategoryName = "Dairy Products", Description = "Cheeses" });
            categoryList.Add(new CategorySampleModel { CategoryID = 5, CategoryName = "Grains/Cereals", Description = "Breads, crackers, pasta, and cereal" });
            categoryList.Add(new CategorySampleModel { CategoryID = 6, CategoryName = "Meat/Poultry", Description = "Prepared meats" });
            categoryList.Add(new CategorySampleModel { CategoryID = 7, CategoryName = "Produce", Description = "Dried fruit and bean curd" });
            categoryList.Add(new CategorySampleModel { CategoryID = 8, CategoryName = "Seafood", Description = "Seaweed and fish" });

        }
        public bool DeleteCategory(int CategoryId)
        {
            bool isSuccess = false;
            var output = categoryList.Find(x => x.CategoryID == CategoryId);
            if (output != null)
            {
                categoryList.Remove(output);
                isSuccess = true;
            }
            return isSuccess;
        }

        public CategorySampleModel GetById(int CategoryId)
        {
            return categoryList.Find(x => x.CategoryID == CategoryId);
        }

        public List<CategorySampleModel> GetList()
        {
            return categoryList;
        }

        public bool SaveCategory(CategorySampleModel input)
        {
            bool isSuccess = false;
            if (input.CategoryID == 0)
            {
                categoryList.Add(new CategorySampleModel { CategoryID = categoryList.Count + 1, CategoryName = input.CategoryName, Description = input.Description });
                isSuccess = true;
            }
            else
            {
                var output = categoryList.Find(x => x.CategoryID == input.CategoryID );
                if (output != null)
                {
                    categoryList.Remove(output);
                    categoryList.Add(new CategorySampleModel { CategoryID = output.CategoryID, CategoryName = input.CategoryName, Description = input.Description });
                    isSuccess = true;
                }
            }
            return isSuccess;
        }
    }
}
