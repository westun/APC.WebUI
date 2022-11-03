namespace APC.WebUI.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int? CartId { get; set; }

        public DateTimeOffset Created { get; set; }

        public AccountDTO Account { get; set; }
        public CartDTO Cart { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();
    }
}
