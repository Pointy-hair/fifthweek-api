﻿namespace Fifthweek.Api.Channels.Commands
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class UpdateChannelCommandHandler : ICommandHandler<UpdateChannelCommand>
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IChannelSecurity channelSecurity;
        private readonly IFifthweekDbContext databaseContext;

        public async Task HandleAsync(UpdateChannelCommand command)
        {
            command.AssertNotNull("command");

            var userId = await this.requesterSecurity.AuthenticateAsync(command.Requester);
            await this.channelSecurity.AssertWriteAllowedAsync(userId, command.ChannelId);

            await this.UpdateChannelAsync(command);
        }

        private Task UpdateChannelAsync(UpdateChannelCommand command)
        {
            var channel = new Channel(command.ChannelId.Value)
            {
                IsVisibleToNonSubscribers = command.IsVisibleToNonSubscribers,
                Name = command.Name.Value,
                PriceInUsCentsPerWeek = command.Price.Value
            };

            var updatedFields = 
                Channel.Fields.IsVisibleToNonSubscribers | 
                Channel.Fields.Name | 
                Channel.Fields.PriceInUsCentsPerWeek;

            return this.databaseContext.Database.Connection.UpdateAsync(channel, updatedFields);
        }
    }
}