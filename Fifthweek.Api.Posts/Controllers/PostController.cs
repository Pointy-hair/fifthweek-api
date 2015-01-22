﻿namespace Fifthweek.Api.Posts.Controllers
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.Api.Posts.Queries;
    using Fifthweek.CodeGeneration;

    [RoutePrefix("posts"), AutoConstructor]
    public partial class PostController : ApiController
    {
        private readonly ICommandHandler<PostNoteCommand> postNote;
        private readonly ICommandHandler<PostImageCommand> postImage;
        private readonly ICommandHandler<PostFileCommand> postFile;
        private readonly ICommandHandler<DeletePostCommand> deletePost;
        private readonly IQueryHandler<GetCreatorBacklogQuery, IReadOnlyList<BacklogPost>> getCreatorBacklog;
        private readonly IUserContext userContext;
        private readonly IGuidCreator guidCreator;

        [Route("notes")]
        public async Task<IHttpActionResult> PostNote(NewNoteData note)
        {
            note.AssertBodyProvided("note");
            note.Parse();

            var requester = this.userContext.GetRequester();
            var newPostId = new PostId(this.guidCreator.CreateSqlSequential());

            await this.postNote.HandleAsync(new PostNoteCommand(
                requester,
                newPostId,
                note.ChannelIdObject,
                note.NoteObject,
                note.ScheduledPostDate));

            return this.Ok();
        }

        [Route("images")]
        public async Task<IHttpActionResult> PostImage(NewImageData image)
        {
            image.AssertBodyProvided("image");
            image.Parse();

            var requester = this.userContext.GetRequester();
            var newPostId = new PostId(this.guidCreator.CreateSqlSequential());

            await this.postImage.HandleAsync(new PostImageCommand(
                requester,
                newPostId,
                image.CollectionIdObject,
                image.ImageFileIdObject,
                image.CommentObject,
                image.ScheduledPostDate,
                image.IsQueued));

            return this.Ok();
        }

        [Route("files")]
        public async Task<IHttpActionResult> PostFile(NewFileData file)
        {
            file.AssertBodyProvided("file");
            file.Parse();

            var requester = this.userContext.GetRequester();
            var newPostId = new PostId(this.guidCreator.CreateSqlSequential());

            await this.postFile.HandleAsync(new PostFileCommand(
                requester,
                newPostId,
                file.CollectionIdObject,
                file.FileIdObject,
                file.CommentObject,
                file.ScheduledPostDate,
                file.IsQueued));

            return this.Ok();
        }

        [Route("creatorBacklog/{creatorId}")]
        public async Task<IEnumerable<BacklogPostData>> GetPosts(string creatorId)
        {
            creatorId.AssertUrlParameterProvided("creatorId");
            var creatorIdObject = new UserId(creatorId.DecodeGuid());
            var requester = this.userContext.GetRequester();

            var posts = await this.getCreatorBacklog.HandleAsync(new GetCreatorBacklogQuery(requester, creatorIdObject));

            return posts.Select(_ => new BacklogPostData(
                _.ChannelId,
                _.CollectionId,
                _.Comment,
                _.FileId,
                _.ImageId,
                _.ScheduledByQueue,
                _.LiveDate));
        }

        [Route("{postId}")]
        public Task DeletePost(string postId)
        {
            postId.AssertUrlParameterProvided("postId");
            var parsedPostId = new PostId(postId.DecodeGuid());
            var requester = this.userContext.GetRequester();

            return this.deletePost.HandleAsync(new DeletePostCommand(parsedPostId, requester));
        }
    }
}
