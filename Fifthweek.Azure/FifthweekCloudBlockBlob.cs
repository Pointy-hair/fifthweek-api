namespace Fifthweek.Azure
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;

    public class FifthweekCloudBlockBlob : ICloudBlockBlob
    {
        private readonly CloudBlockBlob blob;

        public FifthweekCloudBlockBlob(CloudBlockBlob blob)
        {
            this.blob = blob;
        }

        public Uri Uri
        {
            get
            {
                return this.blob.Uri;
            }
        }

        public IBlobProperties Properties
        {
            get
            {
                return new FifthweekBlobProperties(this.blob.Properties);
            }
        }

        public IDictionary<string, string> Metadata
        {
            get
            {
                return this.blob.Metadata;
            }
        }

        public Task<bool> ExistsAsync(CancellationToken cancellationToken)
        {
            return this.blob.ExistsAsync(cancellationToken);
        }

        public Task<bool> ExistsAsync()
        {
            return this.blob.ExistsAsync();
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy)
        {
            return this.blob.GetSharedAccessSignature(policy);
        }

        public string GetSharedAccessSignature(SharedAccessBlobPolicy policy, SharedAccessBlobHeaders headers)
        {
            return this.blob.GetSharedAccessSignature(policy, headers);
        }

        public Task FetchAttributesAsync()
        {
            return this.blob.FetchAttributesAsync();
        }

        public Task FetchAttributesAsync(CancellationToken cancellationToken)
        {
            return this.blob.FetchAttributesAsync(cancellationToken);
        }

        public Task SetPropertiesAsync()
        {
            return this.blob.SetPropertiesAsync();
        }

        public Task SetMetadataAsync()
        {
            return this.blob.SetMetadataAsync();
        }

        public Task SetMetadataAsync(AccessCondition accessCondition, BlobRequestOptions blobRequestOptions, OperationContext operationContext, CancellationToken cancellationToken)
        {
            return this.blob.SetMetadataAsync(accessCondition, blobRequestOptions, operationContext, cancellationToken);
        }

        public Task SetPropertiesAsync(CancellationToken cancellationToken)
        {
            return this.blob.SetPropertiesAsync(cancellationToken);
        }

        public Task<Stream> OpenReadAsync(CancellationToken cancellationToken)
        {
            return this.blob.OpenReadAsync(cancellationToken);
        }

        public Task<CloudBlobStream> OpenWriteAsync(CancellationToken cancellationToken)
        {
            return this.blob.OpenWriteAsync(cancellationToken);
        }

        public Task UploadTextAsync(string content)
        {
            return this.blob.UploadTextAsync(content);
        }

        public Task<string> AcquireLeaseAsync(TimeSpan? leaseTime, string proposedLeaseId, CancellationToken cancellationToken)
        {
            return this.blob.AcquireLeaseAsync(leaseTime, proposedLeaseId, cancellationToken);
        }

        public Task RenewLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return this.blob.RenewLeaseAsync(accessCondition, cancellationToken);
        }

        public Task ReleaseLeaseAsync(AccessCondition accessCondition, CancellationToken cancellationToken)
        {
            return this.blob.ReleaseLeaseAsync(accessCondition, cancellationToken);
        }

        public Task DeleteAsync()
        {
            return this.blob.DeleteAsync();
        }
    }
}