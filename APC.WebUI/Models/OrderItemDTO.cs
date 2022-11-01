namespace APC.WebUI.Models
{
    public class OrderItemDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public Decimal Cost { get; set; }

        public OrderDTO Order { get; set; }
        public ProductDTO Product { get; set; }
    }
}
