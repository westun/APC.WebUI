using System.ComponentModel.DataAnnotations;

namespace APC.WebUI.Models
{
    public class AccountProductDTO
    {
        public int AccountId { get; set; }
        public int ProductId { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public AccountDTO Account { get; set; }
        public ProductDTO Product { get; set; }
    }
}
