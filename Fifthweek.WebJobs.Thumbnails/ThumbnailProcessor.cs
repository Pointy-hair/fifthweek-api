﻿namespace Fifthweek.WebJobs.Thumbnails
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Fifthweek.Azure;
    using Fifthweek.CodeGeneration;
    using Fifthweek.WebJobs.Shared;
    using Fifthweek.WebJobs.Thumbnails.Shared;

    using ImageMagick;

    using Microsoft.WindowsAzure.Storage.Blob;

    [AutoConstructor]
    public partial class ThumbnailProcessor : IThumbnailProcessor
    {
        private readonly IImageService imageService;

        public async Task CreateThumbnailAsync(
            CreateThumbnailMessage thumbnail,
            Stream input,
            ICloudBlockBlob output,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            var exists = await output.ExistsAsync(cancellationToken);

            if (thumbnail.Overwrite || !exists)
            {
                using (var image = new MagickImage(input))
                {
                    if (exists)
                    {
                        await output.FetchAttributesAsync(cancellationToken);
                    }

                    output.Properties.ContentType = image.FormatInfo.MimeType;

                    using (var outputStream = await output.OpenWriteAsync(cancellationToken))
                    {
                        this.imageService.Resize(image, outputStream, thumbnail.Width, thumbnail.Height, thumbnail.ResizeBehaviour);
                        
                        await Task.Factory.FromAsync(outputStream.BeginCommit(null, null), outputStream.EndCommit);
                    }
                }
            }
        }

        public async Task CreatePoisonThumbnailAsync(
            CreateThumbnailMessage thumbnail,
            ICloudBlockBlob output,
            ILogger logger,
            CancellationToken cancellationToken)
        {
            var exists = await output.ExistsAsync(cancellationToken);

            if (thumbnail.Overwrite || !exists)
            {
                // Create a small red image.
                using (var image = new MagickImage(new MagickColor(0, 0, 0), 1, 1))
                {
                    image.Format = MagickFormat.Png;

                    if (exists)
                    {
                        await output.FetchAttributesAsync(cancellationToken);
                    }

                    output.Properties.ContentType = image.FormatInfo.MimeType;
                    
                    using (var outputStream = await output.OpenWriteAsync(cancellationToken))
                    {
                        image.Write(outputStream);
                        await Task.Factory.FromAsync(outputStream.BeginCommit(null, null), outputStream.EndCommit);
                    }
                }
            }
        }
    }
}