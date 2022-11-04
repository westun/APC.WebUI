namespace APC.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int TypeId { get; set; }
        public int? CompanyId { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? BrochureUrl { get; set; }
        public bool Recycled { get; set; }

        public ProductCategory Category { get; set; } 
        public ProductType Type { get; set; }
        public Company Company { get; set; }
        public ICollection<ProductAttributeValue> ProductAttributesValues { get; set; } = new List<ProductAttributeValue>();
        public ICollection<AreasOfApplication> AreasOfApplications { get; set; } = new List<AreasOfApplication>();
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
