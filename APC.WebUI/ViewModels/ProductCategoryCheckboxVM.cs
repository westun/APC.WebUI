using APC.WebUI.Models;

namespace APC.WebUI.ViewModels
{
    public class ProductCategoryCheckboxVM
    {
        public ProductCategoryDTO Category { get; set; }
        public bool IsChecked { get; set; } = true;
        public int ProductCount { get; set; }
    }
}
