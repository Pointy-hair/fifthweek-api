namespace Fifthweek.Api.Identity.OAuth
{
    using System.Threading.Tasks;

    using Fifthweek.Api.Persistence;

    public interface IUpsertRefreshTokenDbStatement
    {
        Task ExecuteAsync(RefreshToken refreshToken);
    }
}