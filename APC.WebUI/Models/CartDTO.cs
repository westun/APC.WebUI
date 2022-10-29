namespace APC.WebUI.Models
{
    public class CartDTO
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public bool Completed { get; set; }

        public AccountDTO Account { get; set; }
        public ICollection<CartProductDTO> CartProducts { get; set; } = new List<CartProductDTO>();
    }
}
