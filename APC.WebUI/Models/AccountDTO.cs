namespace APC.WebUI.Models
{
    public class AccountDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? DisplayName { get; set; }
        public string Email { get; set; }
        public string? ObjectIdentifier { get; set; }
        public IEnumerable<CompanyDTO> Companies { get; set; }
    }
}
