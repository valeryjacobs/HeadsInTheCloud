using HeadsInTheCloud.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.IO;

namespace HeadsInTheCloud.UWP
{
    public class BlobStorageUWP : IBlobStorage
    {
        CloudStorageAccount _storageAccount = null;
        CloudBlobClient _blobClient = null;

        public BlobStorageUWP()
        {
            // Retrieve storage account from connection string.
            _storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=headsinthecloud;AccountKey=A3/dAM3C6HHifInmTyohi4H3aN8grl9PQnIR648sAEYLu873b6U/RQ2sJgbwvMPAz7BnrEXSnHxp1nPW/MJK9Q==");

            // Create the blob client.
            _blobClient = _storageAccount.CreateCloudBlobClient();
        }

        public async Task SaveMediaFile(Stream stream, string name)
        {
            // Retrieve reference to a previously created container.
            CloudBlobContainer container = _blobClient.GetContainerReference("mycontainer");

            // Create the container if it doesn't already exist.
            await container.CreateIfNotExistsAsync();

            // Retrieve reference to a blob named "myblob".
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(name);

            // Create the "myblob" blob with the text "Hello, world!"
            await blockBlob.UploadFromStreamAsync(stream);
        }
    }
}
