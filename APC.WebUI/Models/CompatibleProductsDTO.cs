namespace APC.WebUI.Models
{
    public class CompatibleProductsDTO
    {
        public int Id { get; set; }
        public int TheProductid { get; set; }
        public int CompatibleProductId { get; set; }

        public ProductDTO TheProduct { get; set; }
        public ProductDTO CompatibleProduct { get; set; }
    }
}
