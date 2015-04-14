﻿namespace Fifthweek.Api.Blogs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Blogs.Queries;
    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetLandingPageDbStatement : IGetLandingPageDbStatement
    {
        private static readonly string BlogIdQuery = string.Format(
            @"  DECLARE @BlogId uniqueidentifier;

                SELECT TOP 1
                @BlogId = blog.{6}
                FROM {0} u 
                INNER JOIN {1} blog ON u.{2} = blog.{3} 
                WHERE u.{4}=@Username
                ORDER BY blog.{5} DESC;",
            FifthweekUser.Table,
            Blog.Table,
            FifthweekUser.Fields.Id,
            Blog.Fields.CreatorId,
            FifthweekUser.Fields.UserName,
            Blog.Fields.CreationDate,
            Blog.Fields.Id);

        private static readonly string Query = BlogIdQuery + 
            GetBlogChannelsAndCollectionsDbStatement.BlogQuery + 
            GetBlogChannelsAndCollectionsDbStatement.ChannelsQuery;

        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task<GetLandingPageDbResult> ExecuteAsync(Username username)
        {
            username.AssertNotNull("username");

            List<Blog> blogs;
            List<Channel> channels;
            using (var connection = this.connectionFactory.CreateConnection())
            {
                using (var multi = await connection.QueryMultipleAsync(Query, new { Username = username.Value }))
                {
                    blogs = multi.Read<Blog>().ToList();
                    channels = multi.Read<Channel>().ToList();
                }
            }

            var blog = blogs.SingleOrDefault();

            if (blog == null)
            {
                throw new InvalidOperationException("The blog couldn't be found for user " + username + ".");
            }

            var blogResult = GetBlogChannelsAndCollectionsDbStatement.GetBlogDbResult(blog);
            var channelsResult = channels.Select(v => new ChannelResult(
                new ChannelId(v.Id),
                v.Name,
                v.Description,
                v.PriceInUsCentsPerWeek,
                v.Id == v.BlogId,
                v.IsVisibleToNonSubscribers)).ToList();

            return new GetLandingPageDbResult(blogResult, channelsResult);
        }

        [AutoConstructor, AutoEqualityMembers]
        public partial class GetLandingPageDbResult
        {
            public GetBlogChannelsAndCollectionsDbStatement.BlogDbResult Blog { get; private set; }

            public IReadOnlyList<ChannelResult> Channels { get; private set; }
        }
    }
}