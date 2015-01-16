﻿namespace Fifthweek.Api.Azure
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Azure;
    using Fifthweek.Webjobs.Files.Shared;

    using Microsoft.WindowsAzure.Storage.Queue;

    using Newtonsoft.Json;

    public class QueueService : IQueueService
    {
        private readonly ICloudStorageAccount cloudStorageAccount;

        public QueueService(ICloudStorageAccount cloudStorageAccount)
        {
            this.cloudStorageAccount = cloudStorageAccount;
        }

        public async Task PostFileUploadCompletedMessageToQueueAsync(string containerName, string blobName, string purpose)
        {
            containerName.AssertNotNull("containerName");
            blobName.AssertNotNull("blobName");
            purpose.AssertNotNull("purpose");

            var cloudQueueClient = this.cloudStorageAccount.CreateCloudQueueClient();
            var queue = cloudQueueClient.GetQueueReference(Fifthweek.Webjobs.Files.Shared.Constants.FilesQueueName);
            await queue.CreateIfNotExistsAsync();

            var messageContent = new ProcessFileMessage(containerName, blobName, purpose, false);
            var serializedMessageContent = JsonConvert.SerializeObject(messageContent);
            var message = new CloudQueueMessage(serializedMessageContent);
            await queue.AddMessageAsync(message);
        }
    }
}