namespace Fifthweek.Azure
{
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    public interface ICloudBlobClient
    {
        ICloudBlobContainer GetContainerReference(string containerName);

        Task<ServiceProperties> GetServicePropertiesAsync();

        Task SetServicePropertiesAsync(ServiceProperties serviceProperties);

        Task<IContainerResultSegment> ListContainersSegmentedAsync(BlobContinuationToken continuationToken);
    }
}