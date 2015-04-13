﻿namespace Fifthweek.Api.Channels
{
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class DeleteChannelDbStatement : IDeleteChannelDbStatement
    {
        private static readonly string DeleteSql = string.Format(
            @"
            DELETE FROM {0} WHERE {1} = @ChannelId;
            DELETE FROM {2} WHERE {3} = @ChannelId;",
            ChannelSubscription.Table,
            ChannelSubscription.Fields.ChannelId,
            Channel.Table,
            Channel.Fields.Id);

        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task ExecuteAsync(ChannelId channelId)
        {
            channelId.AssertNotNull("channelId");
            var channelIdParameter = new
            {
                ChannelId = channelId.Value
            };

            using (var connection = this.connectionFactory.CreateConnection())
            {
                await connection.ExecuteAsync(DeleteSql, channelIdParameter);
            }
        }
    }
}