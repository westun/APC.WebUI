namespace APC.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? CartId { get; set; }
        public DateTimeOffset Created { get; set; }

        public Account Account { get; set; }
        public Cart Cart { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
