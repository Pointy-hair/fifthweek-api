﻿namespace Fifthweek.Api.Posts
{
    using Autofac;

    using Fifthweek.Api.Posts.Controllers;
    using Fifthweek.Api.Posts.Shared;
    using Fifthweek.Shared;

    public class AutofacRegistration : IAutofacRegistration
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<GetNewsfeedDbStatement>().As<IGetNewsfeedDbStatement>();
            builder.RegisterType<GetCreatorBacklogDbStatement>().As<IGetCreatorBacklogDbStatement>();
            builder.RegisterType<DeletePostDbStatement>().As<IDeletePostDbStatement>();
            builder.RegisterType<PostNoteDbStatement>().As<IPostNoteDbStatement>();
            builder.RegisterType<PostToCollectionDbStatement>().As<IPostToCollectionDbStatement>();
            builder.RegisterType<PostToCollectionDbSubStatements>().As<IPostToCollectionDbSubStatements>();
            builder.RegisterType<TryGetQueuedPostCollectionDbStatement>().As<ITryGetQueuedPostCollectionDbStatement>();
            builder.RegisterType<TryGetUnqueuedPostCollectionDbStatement>().As<ITryGetUnqueuedPostCollectionDbStatement>();
            builder.RegisterType<PostFileTypeChecks>().As<IPostFileTypeChecks>();
            builder.RegisterType<PostSecurity>().As<IPostSecurity>();
            builder.RegisterType<IsPostOwnerDbStatement>().As<IIsPostOwnerDbStatement>();
            builder.RegisterType<ScheduledDateClippingFunction>().As<IScheduledDateClippingFunction>();
            builder.RegisterType<SetPostLiveDateDbStatement>().As<ISetPostLiveDateDbStatement>();
            builder.RegisterType<RemoveFromQueueIfRequiredDbStatement>().As<IRemoveFromQueueIfRequiredDbStatement>();
            builder.RegisterType<MovePostToQueueDbStatement>().As<IMovePostToQueueDbStatement>();
            builder.RegisterType<FilePostController>().As<IFilePostController>();
            builder.RegisterType<ImagePostController>().As<IImagePostController>();
            builder.RegisterType<NotePostController>().As<INotePostController>();
            builder.RegisterType<PostController>().As<IPostController>();
            builder.RegisterType<IsPostSubscriberDbStatement>().As<IIsPostSubscriberDbStatement>();
            builder.RegisterType<LikePostDbStatement>().As<ILikePostDbStatement>();
            builder.RegisterType<UnlikePostDbStatement>().As<IUnlikePostDbStatement>();
            builder.RegisterType<CommentOnPostDbStatement>().As<ICommentOnPostDbStatement>();
            builder.RegisterType<GetCommentsDbStatement>().As<IGetCommentsDbStatement>();
        }
    }
}