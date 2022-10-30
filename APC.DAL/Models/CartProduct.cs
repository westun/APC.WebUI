﻿namespace APC.DAL.Models
{
    public class CartProduct
    {
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }

        public Cart Cart { get; set; }
        public Product Product { get; set; }
    }
}
