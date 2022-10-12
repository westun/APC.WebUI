using System.Net.Http.Headers;

namespace APC.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        
        public ProductCategory Category { get; set; } = new ProductCategory();
        public ProductType Type { get; set; } = new ProductType();
        public ICollection<ProductAttributeValue> ProductAttributesValues { get; set; } = new List<ProductAttributeValue>();    
    }
}
