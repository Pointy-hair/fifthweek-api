﻿namespace Fifthweek.Api.Posts.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.CodeGeneration;

    [RoutePrefix("posts/images"), AutoConstructor]
    public partial class ImagePostController : ApiController
    {
        private readonly ICommandHandler<PostImageCommand> postImage;
        private readonly IRequesterContext requesterContext;
        private readonly IGuidCreator guidCreator;

        public async Task<IHttpActionResult> PostImage(NewImageData imageData)
        {
            imageData.AssertBodyProvided("imageData");
            var image = imageData.Parse();

            var requester = this.requesterContext.GetRequester();
            var newPostId = new PostId(this.guidCreator.CreateSqlSequential());

            await this.postImage.HandleAsync(new PostImageCommand(
                requester,
                newPostId,
                image.CollectionId,
                image.ImageFileId,
                image.Comment,
                image.ScheduledPostDate,
                image.IsQueued));

            return this.Ok();
        }
    }
}
