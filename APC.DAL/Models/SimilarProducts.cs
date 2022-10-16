namespace APC.DAL.Models
{
    public class SimilarProducts
    {
        public int Id { get; set; }
        public int TheProductid { get; set; }
        public int SimilarProductId { get; set; }

        public Product TheProduct { get; set; }
        public Product SimilarProduct { get; set; }
    }
}
