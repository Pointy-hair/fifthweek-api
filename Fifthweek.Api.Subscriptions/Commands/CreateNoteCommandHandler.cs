﻿namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class CreateNoteCommandHandler : ICommandHandler<CreateNoteCommand>
    {
        private readonly IChannelSecurity channelSecurity;
        private readonly IFifthweekDbContext databaseContext;

        public async Task HandleAsync(CreateNoteCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException("command");
            }

            await this.channelSecurity.AssertPostingAllowedAsync(command.Requester, command.ChannelId);

            await this.CreatePostAsync(command);
        }

        private Task CreatePostAsync(CreateNoteCommand command)
        {
            var now = DateTime.UtcNow;

            var liveDate = now;
            if (command.ScheduledPostDate != null)
            {
                var scheduledPostDate = command.ScheduledPostDate.Value;
                if (scheduledPostDate > now)
                {
                    liveDate = scheduledPostDate;    
                }
            }

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
                null,
                liveDate,
                now);

            return this.databaseContext.Database.Connection.InsertAsync(post);
        }
    }
}