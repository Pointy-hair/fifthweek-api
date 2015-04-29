﻿namespace Fifthweek.Api.Blogs.Queries
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetLandingPageQueryHandler : IQueryHandler<GetLandingPageQuery, GetLandingPageResult>
    {
        private readonly IFileInformationAggregator fileInformationAggregator;
        private readonly IGetLandingPageDbStatement getLandingPageDbStatement;
        
        public async Task<GetLandingPageResult> HandleAsync(GetLandingPageQuery query)
        {
            query.AssertNotNull("query");

            var queryResult = await this.getLandingPageDbStatement.ExecuteAsync(query.CreatorUsername);

            var blog = queryResult.Blog;
            var channels = queryResult.Channels;


            FileInformation headerFileInformation = null;
            if (blog.HeaderImageFileId != null)
            {
                headerFileInformation = await this.fileInformationAggregator.GetFileInformationAsync(
                        blog.CreatorId,
                        blog.HeaderImageFileId,
                        FilePurposes.ProfileHeaderImage);
            }

            FileInformation profileImageFileInformation = null;
            if (queryResult.ProfileImageFileId != null)
            {
                profileImageFileInformation = await this.fileInformationAggregator.GetFileInformationAsync(
                        queryResult.UserId,
                        queryResult.ProfileImageFileId,
                        FilePurposes.ProfileImage);
            }

            var blogWithFileInformation = new BlogWithFileInformation(
                blog.BlogId,
                blog.BlogName,
                blog.Tagline,
                blog.Introduction,
                blog.CreationDate,
                headerFileInformation,
                blog.Video,
                blog.Description);

            return new GetLandingPageResult(
                queryResult.UserId, 
                profileImageFileInformation, 
                blogWithFileInformation, 
                channels);
        }
    }
}