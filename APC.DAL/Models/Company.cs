namespace APC.DAL.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
