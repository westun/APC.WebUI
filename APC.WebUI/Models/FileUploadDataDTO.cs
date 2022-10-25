using Microsoft.AspNetCore.Components.Forms;

namespace APC.WebUI.Models
{
    public class FileUploadDataDTO
    {
        public string FileName { get; set; }
        public IBrowserFile BrowserFile { get; set; }
    }
}
