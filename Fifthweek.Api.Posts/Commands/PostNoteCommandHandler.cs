﻿namespace Fifthweek.Api.Posts.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class PostNoteCommandHandler : ICommandHandler<PostNoteCommand>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IChannelSecurity channelSecurity;
        private readonly IUpsertNoteDbStatement upsertNote;

        public async Task HandleAsync(PostNoteCommand command)
        {
            command.AssertNotNull("command");

            var authenticatedUserId = await this.requesterSecurity.AuthenticateAsync(command.Requester);

            await this.channelSecurity.AssertWriteAllowedAsync(authenticatedUserId, command.ChannelId);

            await this.upsertNote.ExecuteAsync(
                command.NewPostId,
                command.ChannelId,
                command.Note,
                command.ScheduledPostDate,
                DateTime.UtcNow);
        }
    }
}