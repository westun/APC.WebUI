namespace APC.DAL.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public bool Completed { get; set; }

        public Account Account { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; } = new List<CartProduct>();
    }
}
