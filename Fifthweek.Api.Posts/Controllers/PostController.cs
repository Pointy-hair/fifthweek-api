﻿namespace Fifthweek.Api.Posts.Controllers
{
    using System.Threading.Tasks;
    using System.Web.Http;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Posts.Commands;
    using Fifthweek.CodeGeneration;

    [RoutePrefix("posts"), AutoConstructor]
    public partial class PostController : ApiController
    {
        private readonly ICommandHandler<PostNoteCommand> postNote;
        private readonly ICommandHandler<PostImageCommand> postImage;
        private readonly ICommandHandler<PostFileCommand> postFile; 
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
    }
}
