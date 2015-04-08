namespace Fifthweek.Api.Blogs
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Blogs.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class BlogSecurity : IBlogSecurity
    {
        private readonly IRequesterSecurity requesterSecurity;
        private readonly IBlogOwnership blogOwnership;

        public Task<bool> IsCreationAllowedAsync(Requester requester)
        {
            requester.AssertNotNull("requester");

            return this.requesterSecurity.IsInRoleAsync(requester, FifthweekRole.Creator);
        }

        public Task<bool> IsWriteAllowedAsync(UserId requester, BlogId blogId)
        {
            requester.AssertNotNull("requester");
            blogId.AssertNotNull("blogId");

            return this.blogOwnership.IsOwnerAsync(requester, blogId);
        }

        public async Task AssertCreationAllowedAsync(Requester requester)
        {
            requester.AssertNotNull("requester");

            var isCreationAllowed = await this.IsCreationAllowedAsync(requester);
            if (!isCreationAllowed)
            {
                throw new UnauthorizedException("Not allowed to create blog. {0}", requester);
            }
        }

        public async Task AssertWriteAllowedAsync(UserId requester, BlogId blogId)
        {
            requester.AssertNotNull("requester");
            blogId.AssertNotNull("blogId");

            var isUpdateAllowed = await this.IsWriteAllowedAsync(requester, blogId);
            if (!isUpdateAllowed)
            {
                throw new UnauthorizedException("Not allowed to update blog. {0} {1}", requester, blogId);
            }
        }
    }
}