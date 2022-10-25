namespace APC.WebUI.Models
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public ProductCategoryDTO Category { get; set; }
    }
}
