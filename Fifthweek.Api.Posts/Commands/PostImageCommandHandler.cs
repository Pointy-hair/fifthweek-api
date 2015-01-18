﻿namespace Fifthweek.Api.Posts.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Collections;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class PostImageCommandHandler : ICommandHandler<PostImageCommand>
    {
        private readonly ICollectionSecurity collectionSecurity;
        private readonly IFileSecurity fileSecurity;
        private readonly IPostFileTypeChecks postFileTypeChecks;
        private readonly IPostToCollectionDbStatement postToCollectionDbStatement;

        public async Task HandleAsync(PostImageCommand command)
        {
            command.AssertNotNull("command");

            await this.collectionSecurity.AssertPostingAllowedAsync(command.Requester, command.CollectionId);

            await this.fileSecurity.AssertUsageAllowedAsync(command.Requester, command.ImageFileId);

            await this.postFileTypeChecks.AssertValidForImagePostAsync(command.ImageFileId);

            await this.postToCollectionDbStatement.ExecuteAsync(
                command.NewPostId,
                command.CollectionId,
                command.Comment,
                command.ScheduledPostDate,
                command.IsQueued,
                command.ImageFileId,
                true,
                DateTime.UtcNow);
        }
    }
}