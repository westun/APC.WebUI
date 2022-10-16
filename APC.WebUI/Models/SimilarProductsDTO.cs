using APC.DAL.Models;

namespace APC.WebUI.Models
{
    public class SimilarProductsDTO
    {
        public int TheProductid { get; set; }
        public int SimiliarProductId { get; set; }

        public Product TheProduct { get; set; }
        public Product SimiliarProduct { get; set; }
    }
}
