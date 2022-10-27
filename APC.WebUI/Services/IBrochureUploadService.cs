using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IBrochureUploadService
    {
        Task<FileUploadResultDTO> UploadFile(FileUploadDataDTO fileUploadData);
    }
}