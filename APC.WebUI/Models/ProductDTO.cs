namespace APC.WebUI.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public ProductCategoryDTO Category { get; set; } = new ProductCategoryDTO();
        public ProductTypeDTO Type { get; set; } = new ProductTypeDTO();
        public IEnumerable<ProductAttributeValueDTO> AttributeValues { get; set; } = new List<ProductAttributeValueDTO>();
        public IEnumerable<AreasOfApplicationDTO> AreasOfApplications { get; set; } = new List<AreasOfApplicationDTO>();
    }
}
