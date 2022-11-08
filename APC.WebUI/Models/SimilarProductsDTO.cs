namespace APC.WebUI.Models
{
    public class SimilarProductsDTO
    {
        public int Id { get; set; }
        public int TheProductid { get; set; }
        public int SimilarProductId { get; set; }

        public ProductDTO TheProduct { get; set; }
        public ProductDTO SimilarProduct { get; set; }
    }
}
