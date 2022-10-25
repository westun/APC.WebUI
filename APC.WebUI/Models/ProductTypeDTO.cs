using System.ComponentModel.DataAnnotations;

namespace APC.WebUI.Models
{
    public class ProductTypeDTO
    {
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        public ProductCategoryDTO Category { get; set; }
    }
}
