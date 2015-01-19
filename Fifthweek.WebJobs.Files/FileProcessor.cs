﻿namespace Fifthweek.WebJobs.Files
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Fifthweek.Azure;
    using Fifthweek.CodeGeneration;
    using Fifthweek.WebJobs.Files.Shared;

    using Microsoft.Azure.WebJobs;

    [AutoConstructor]
    public partial class FileProcessor : IFileProcessor
    {
        private readonly IFilePurposeTasks filePurposeTasks;

        private readonly ICloudQueueResolver cloudQueueResolver;

        public async Task ProcessFileAsync(
            ProcessFileMessage message,
            IBinder binder,
            TextWriter logger,
            CancellationToken cancellationToken)
        {
            var tasks = this.filePurposeTasks.GetTasks(message.Purpose);

            ICloudQueue queue = null;
            foreach (var task in tasks)
            {
                try
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    if (queue == null || queue.Name != task.QueueName)
                    {
                        queue = await this.cloudQueueResolver.GetQueueAsync(binder, task);
                    }

                    await task.HandleAsync(queue, message);
                }
                catch (Exception t)
                {
                    logger.WriteLine("Failed to handle file task of type '{0}': {1}", task.GetType().Name, t);
                    throw;
                }
            }
        }
    }
}