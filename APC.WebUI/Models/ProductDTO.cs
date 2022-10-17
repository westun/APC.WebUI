using System.ComponentModel.DataAnnotations;

namespace APC.WebUI.Models
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }

        [Required(ErrorMessage = "Product Name is required.")]
        public string Name { get; set; }

        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public ProductCategoryDTO Category { get; set; }
        public ProductTypeDTO Type { get; set; }
        public IEnumerable<ProductAttributeValueDTO> ProductAttributesValues { get; set; } = new List<ProductAttributeValueDTO>();
        public IEnumerable<AreasOfApplicationDTO> AreasOfApplications { get; set; } = new List<AreasOfApplicationDTO>();
    }
}
