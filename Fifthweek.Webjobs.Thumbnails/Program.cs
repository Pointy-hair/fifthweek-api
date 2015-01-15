﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fifthweek.Webjobs.Thumbnails
{
    using System.IO;
    using System.Threading;
    using System.Web.Helpers;

    using Fifthweek.Webjobs.Thumbnails.Shared;

    using ImageMagick;

    using Microsoft.Azure.WebJobs;

    class Program
    {
        static void Main(string[] args)
        {
            var config = new JobHostConfiguration();
            config.Queues.BatchSize = 8;
            config.Queues.MaxDequeueCount = 3;
            config.Queues.MaxPollingInterval = TimeSpan.FromSeconds(5);
            var host = new JobHost(config);
            host.RunAndBlock();
        }

        public static Task CreateThumbnailAsync(
            [QueueTrigger(Constants.ThumbnailsQueueName)] ThumbnailQueueItem thumbnail,
            [Blob("{InputBlobLocation}", FileAccess.Read)] Stream input,
            [Blob("{OutputBlobLocation}", FileAccess.Write)] Stream output,
            TextWriter logger,
            CancellationToken cancellationToken)
        {
            using (var image = new MagickImage(input))
            {
                image.Resize(800, 600);
                image.Write(output);
            }

            return Task.FromResult(0);
        }
    }
}
