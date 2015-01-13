namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Threading.Tasks;

    using Fifthweek.Api.Persistence.Identity;

    using Microsoft.AspNet.Identity;

    public interface IUserManager : IDisposable
    {
        IPasswordHasher PasswordHasher { get; }

        Task<IdentityResult> CreateAsync(FifthweekUser user, string password);

        Task<FifthweekUser> FindAsync(string userName, string password);

        Task<FifthweekUser> FindByIdAsync(Guid userId);

        Task<FifthweekUser> FindByEmailAsync(string email);

        Task<FifthweekUser> FindByNameAsync(string userName);

        Task<IdentityResult> UpdateAsync(FifthweekUser user);

        Task<string> GeneratePasswordResetTokenAsync(Guid userId);

        Task<IdentityResult> ResetPasswordAsync(Guid userId, string token, string newPassword);

        Task SendEmailAsync(Guid userId, string subject, string body);

        Task<bool> ValidatePasswordResetTokenAsync(FifthweekUser user, string token);

        Task<IdentityResult> AddToRoleAsync(Guid userId, string role);

        Task<bool> IsInRoleAsync(Guid userId, string role);
    }
}
