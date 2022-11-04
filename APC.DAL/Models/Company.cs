namespace APC.DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        IEnumerable<Product> Products { get; set; }
    }
}
