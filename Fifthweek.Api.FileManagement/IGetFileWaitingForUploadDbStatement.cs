﻿namespace Fifthweek.Api.FileManagement
{
    using System.Threading.Tasks;

    public interface IGetFileWaitingForUploadDbStatement
    {
        Task<FileWaitingForUpload> ExecuteAsync(FileId fileId);
    }
}