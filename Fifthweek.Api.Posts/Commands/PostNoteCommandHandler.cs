﻿namespace Fifthweek.Api.Posts.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class PostNoteCommandHandler : ICommandHandler<PostNoteCommand>
    {
        private readonly IChannelSecurity channelSecurity;
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IFifthweekDbContext databaseContext;
        private readonly IScheduledDateClippingFunction scheduledDateClipping;

        public async Task HandleAsync(PostNoteCommand command)
        {
            command.AssertNotNull("command");

            var authenticatedUserId = await this.requesterSecurity.AuthenticateAsync(command.Requester);

            await this.channelSecurity.AssertWriteAllowedAsync(authenticatedUserId, command.ChannelId);

            await this.SchedulePostAsync(command);
        }

        private Task SchedulePostAsync(PostNoteCommand command)
        {
            var now = DateTime.UtcNow;
            var scheduledDate = this.scheduledDateClipping.Apply(now, command.ScheduledPostDate);
            var post = new Post(
                command.NewPostId.Value,
                command.ChannelId.Value,
                null,
                null,
                null,
                null,
                null,
                null,
                null,
                command.Note.Value,
                false,
                scheduledDate,
                now);

            return this.databaseContext.Database.Connection.InsertAsync(post);
        }
    }
}