﻿namespace Fifthweek.Api.FileManagement
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class GetFileWaitingForUploadDbStatement : IGetFileWaitingForUploadDbStatement
    {
        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task<FileWaitingForUpload> ExecuteAsync(Shared.FileId fileId)
        {
            fileId.AssertNotNull("fileId");
            
            using (var connection = this.connectionFactory.CreateConnection())
            {
                var items = await connection.QueryAsync<File>(
                    string.Format(
                        @"SELECT {0}, {1}, {2}, {3}, {4} FROM Files WHERE Id=@FileId",
                        File.Fields.Id,
                        File.Fields.UserId,
                        File.Fields.FileNameWithoutExtension,
                        File.Fields.FileExtension,
                        File.Fields.Purpose),
                    new { FileId = fileId.Value });

                var result = items.SingleOrDefault();

                if (result == null)
                {
                    throw new InvalidOperationException("The File " + fileId + " couldn't be found.");
                }

                return new FileWaitingForUpload(new Shared.FileId(result.Id), new UserId(result.UserId), result.FileNameWithoutExtension, result.FileExtension, result.Purpose);
            }
        }
    }
}