namespace Fifthweek.Api.Posts
{
    using System.Threading.Tasks;

    public interface IDeletePostDbStatement
    {
        Task ExecuteAsync(PostId postId);
    }
}