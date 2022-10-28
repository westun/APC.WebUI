using APC.DAL.Models;

namespace APC.WebUI.Models
{
    public class CartProductDTO
    {
        public int CartId { get; set; }

        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
