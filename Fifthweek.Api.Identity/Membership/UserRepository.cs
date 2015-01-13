﻿using Fifthweek.Api.Core;

namespace Fifthweek.Api.Identity.Membership
{
    using System;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Persistence;

    [AutoConstructor]
    public partial class UserRepository : IUserRepository
    {
        private readonly IFifthweekDbContext fifthweekDbContext;

        public Task UpdateLastSignInDateAndAccessTokenDateAsync(ValidatedUsername username, DateTime timestamp)
        {
            return this.fifthweekDbContext.Database.Connection.ExecuteAsync(
                    @"UPDATE AspNetUsers SET LastSignInDate=@timestamp, LastAccessTokenDate=@timestamp WHERE UserName=@username",
                    new { username = username.Value, timestamp });
        }

        public Task UpdateLastAccessTokenDateAsync(ValidatedUsername username, DateTime timestamp)
        {
            return this.fifthweekDbContext.Database.Connection.ExecuteAsync(
                   @"UPDATE AspNetUsers SET LastAccessTokenDate=@timestamp WHERE UserName=@username",
                   new { username = username.Value, timestamp });
        }
    }
}