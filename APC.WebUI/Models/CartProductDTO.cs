namespace APC.WebUI.Models
{
    public class CartProductDTO
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public CartDTO Cart { get; set; }
        public ProductDTO Product { get; set; }
    }
}
