namespace Fifthweek.Api.Azure
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Azure;

    using Microsoft.WindowsAzure.Storage.Blob;

    public class BlobService : IBlobService
    {
        private readonly ICloudStorageAccount cloudStorageAccount;

        public BlobService(ICloudStorageAccount cloudStorageAccount)
        {
            this.cloudStorageAccount = cloudStorageAccount;
        }

        public async Task CreateBlobContainerAsync(string containerName)
        {
            containerName.AssertNotNull("containerName");

            var client = this.cloudStorageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            await container.CreateIfNotExistsAsync();
        }

        public Task<BlobSharedAccessInformation> GetBlobSharedAccessInformationForWritingAsync(string containerName, string blobName, DateTime expiry)
        {
            containerName.AssertNotNull("containerName");
            blobName.AssertNotNull("blobName");

            if (expiry.Kind != DateTimeKind.Utc)
            {
                throw new InvalidOperationException("Expiry time must be in UTC");
            }

            var client = this.cloudStorageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(blobName);

            var policy = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = expiry,
                Permissions = SharedAccessBlobPermissions.Write
            };

            var token = blob.GetSharedAccessSignature(policy);

            return Task.FromResult(new BlobSharedAccessInformation(containerName, blobName, blob.Uri.ToString(), token, expiry));
        }

        public Task<BlobContainerSharedAccessInformation> GetBlobContainerSharedAccessInformationForReadingAsync(string containerName, DateTime expiry)
        {
            containerName.AssertNotNull("containerName");

            if (expiry.Kind != DateTimeKind.Utc)
            {
                throw new InvalidOperationException("Expiry time must be in UTC");
            }
            
            var client = this.cloudStorageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);

            var policy = new SharedAccessBlobPolicy
            {
                SharedAccessExpiryTime = expiry,
                Permissions = SharedAccessBlobPermissions.Read
            };

            var token = container.GetSharedAccessSignature(policy);

            return Task.FromResult(new BlobContainerSharedAccessInformation(containerName, container.Uri.ToString(), token, expiry));
        }

        public async Task<long> GetBlobLengthAndSetContentTypeAsync(string containerName, string blobName, string contentType)
        {
            containerName.AssertNotNull("containerName");
            blobName.AssertNotNull("blobName");
            contentType.AssertNotNull("contentType");
            
            var client = this.cloudStorageAccount.CreateCloudBlobClient();
            var container = client.GetContainerReference(containerName);
            var blob = container.GetBlockBlobReference(blobName);
            await blob.FetchAttributesAsync();
            blob.Properties.ContentType = contentType;
            await blob.SetPropertiesAsync();
            return blob.Properties.Length;
        }
    }
}