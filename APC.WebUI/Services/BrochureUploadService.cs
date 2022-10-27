using APC.WebUI.Models;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;

namespace APC.WebUI.Services
{
    public class BrochureUploadService : IBrochureUploadService
    {
        private const string ConnectionString = "DefaultEndpointsProtocol=https;AccountName=apcdevelopment;AccountKey=lZdasgvG5mXWdFn5VXRPsuPNsziS2H+T0lTrtsax//PJBil6YmhbRhiSMWuCykfcdsu3/HUhYrsP+ASthiVXlQ==;EndpointSuffix=core.windows.net";
        private const string BlobContainerName = "brochure";

        public async Task<FileUploadResultDTO> UploadFile(FileUploadDataDTO fileUploadData)
        {
            BlobContainerClient containerClient
                = new BlobContainerClient(ConnectionString, BlobContainerName);

            BlobClient blobClient = containerClient.GetBlobClient(fileUploadData.FileName);
            await blobClient.UploadAsync(fileUploadData.BrowserFile.OpenReadStream());

            var headers = await this.ConfigureBlobContentType(blobClient, fileUploadData.BrowserFile.ContentType);
            await blobClient.SetHttpHeadersAsync(headers);

            return new FileUploadResultDTO
            {
                OriginalFileName = fileUploadData.BrowserFile.Name,
                FileName = fileUploadData.FileName,
                FileUrl = blobClient.Uri
            };
        }

        private async Task<BlobHttpHeaders> ConfigureBlobContentType(BlobClient blobClient, string contentType)
        {
            var properties = await blobClient.GetPropertiesAsync();
            BlobHttpHeaders headers = new BlobHttpHeaders
            {
                // Set the MIME ContentType every time the properties 
                // are updated or the field will be cleared
                ContentType = contentType,
                ContentLanguage = "en-us",

                // Populate remaining headers with 
                // the pre-existing properties
                CacheControl = properties.Value.CacheControl,
                ContentDisposition = properties.Value.ContentDisposition,
                ContentEncoding = properties.Value.ContentEncoding,
                ContentHash = properties.Value.ContentHash,
            };

            return headers;
        }
    }
}
