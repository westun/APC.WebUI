using System.ComponentModel.DataAnnotations;

namespace APC.WebUI.Models
{
    public class CompanyDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
