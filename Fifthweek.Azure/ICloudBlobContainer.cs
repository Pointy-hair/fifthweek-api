namespace Fifthweek.Azure
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage.Blob;

    public interface ICloudBlobContainer
    {
        Task<bool> CreateIfNotExistsAsync();

        ICloudBlockBlob GetBlockBlobReference(string blobName);

        string GetSharedAccessSignature(SharedAccessBlobPolicy policy);

        Uri Uri { get; }
    }
}