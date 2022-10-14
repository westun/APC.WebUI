using APC.WebUI.Models;

namespace APC.WebUI.Services
{
    public interface IFileUploadService
    {
        Task<FileUploadResultDTO> UploadFile(FileUploadDataDTO fileUploadData);
    }
}