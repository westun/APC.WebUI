using System.ComponentModel.DataAnnotations;

namespace APC.WebUI.Models
{
    public class ProductAttributeValueDTO
    {
        [Required]
        public string Value { get; set; }
        public int DisplayOrder { get; set; } = 0;
        public ProductAttributeDTO ProductAttribute { get; set; }

    }
}
