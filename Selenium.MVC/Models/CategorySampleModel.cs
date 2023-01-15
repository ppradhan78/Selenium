using System.ComponentModel.DataAnnotations;

namespace Selenium.MVC.Models
{
    public class CategorySampleModel
    {
        public int CategoryID { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
