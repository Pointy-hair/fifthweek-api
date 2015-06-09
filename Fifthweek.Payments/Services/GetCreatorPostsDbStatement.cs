﻿namespace Fifthweek.Payments.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;

    [AutoConstructor]
    public partial class GetCreatorPostsDbStatement : IGetCreatorPostsDbStatement
    {
        private static readonly string Sql = string.Format(
            @"SELECT {0}, {1} FROM {2} 
              WHERE {0} in @Channels AND {1} >= StartTimestampInclusive AND {1} < EndTimestampExclusive
              AND {3} < {1}",
            Post.Fields.ChannelId,
            Post.Fields.LiveDate,
            Post.Table,
            Post.Fields.CreationDate);

        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task<IReadOnlyList<CreatorPost>> ExecuteAsync(UserId creatorId, DateTime startTimestampInclusive, DateTime endTimestampExclusive)
        {
            using (var connection = this.connectionFactory.CreateConnection())
            {
                var databaseResult = await connection.QueryAsync<DbResult>(
                    Sql,
                    new
                    {
                        CreatorId = creatorId.Value,
                        StartTimestampInclusive = startTimestampInclusive,
                        EndTimestampExclusive = endTimestampExclusive
                    });

                return databaseResult.Select(v => new CreatorPost(new ChannelId(v.ChannelId), v.LiveDate)).ToList();
            }
        }

        private class DbResult
        {
            public Guid ChannelId { get; set; }

            public DateTime LiveDate { get; set; }
        }
    }
}