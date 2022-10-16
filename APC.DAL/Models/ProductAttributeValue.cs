namespace APC.DAL.Models
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public int DisplayOrder { get; set; } = 0;

        public Product Product { get; set; }
        public ProductAttribute ProductAttribute { get; set; }
    }
}
