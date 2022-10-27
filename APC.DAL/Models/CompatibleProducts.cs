namespace APC.DAL.Models
{
    public class CompatibleProducts
    {
        public int Id { get; set; }

        public int TheProductid { get; set; }

        public int CompatibleProductId { get; set; }

        public Product TheProduct { get; set; }
        public Product CompatibleProduct { get; set; }
    }
}
