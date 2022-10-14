using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Components.Forms;

namespace APC.WebUI.Services
{
    public class FileUploadServicec
    {
        BlobServiceClient blobServiceClient = new BlobServiceClient("");

        public void UploadFile(IBrowserFile browserFile)
        {
            var serviceClient = blobServiceClient.GetBlobContainerClient("products");

            //serviceClient.

        }
    }
}
