namespace APC.DAL.Models
{
    public class ProductType
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public ProductCategory Category { get; set; }
    }
}
