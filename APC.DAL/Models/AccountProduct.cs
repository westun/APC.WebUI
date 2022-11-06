namespace APC.DAL.Models
{
    public class AccountProduct
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }
        public decimal Cost { get; set; }

        public Account Account { get; set; }
        public Product Product { get; set; }
    }
}
