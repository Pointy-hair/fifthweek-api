﻿namespace Fifthweek.Api.Identity.Membership
{
    using System;
    using System.Data.SqlTypes;
    using System.Threading.Tasks;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Payments.SnapshotCreation;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class RegisterUserDbStatement : IRegisterUserDbStatement
    {
        private static readonly string WhereUsernameNotTaken = string.Format(
            @"NOT EXISTS (SELECT * 
                          FROM  {0} WITH (UPDLOCK, HOLDLOCK)
                          WHERE {1} != @{1}
                          AND   {2} = @{2})",
            FifthweekUser.Table,
            FifthweekUser.Fields.Id,
            FifthweekUser.Fields.UserName);

        private static readonly string WhereEmailNotTaken = string.Format(
            @"NOT EXISTS (SELECT * 
                          FROM  {0} WITH (UPDLOCK, HOLDLOCK)
                          WHERE {1} != @{1}
                          AND   {2} = @{2})",
            FifthweekUser.Table,
            FifthweekUser.Fields.Id,
            FifthweekUser.Fields.Email);

        private readonly IUserManager userManager;

        private readonly IFifthweekDbConnectionFactory connectionFactory;
        private readonly IRequestSnapshotService requestSnapshot;

        public async Task ExecuteAsync(
            UserId userId, 
            Username username,
            Email email,
            string exampleWork,
            CreatorName name,
            Password password,
            DateTime timeStamp)
        {
            userId.AssertNotNull("userId");
            username.AssertNotNull("username");
            email.AssertNotNull("email");
            password.AssertNotNull("password");

            var passwordHash = this.userManager.PasswordHasher.HashPassword(password.Value);
           
            var user = new FifthweekUser
            {
                Id = userId.Value,
                UserName = username.Value,
                Email = email.Value,
                ExampleWork = exampleWork,
                Name = name == null ? null : name.Value,
                RegistrationDate = timeStamp,
                LastSignInDate = SqlDateTime.MinValue.Value,
                LastAccessTokenDate = SqlDateTime.MinValue.Value,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = passwordHash,
            };

            var parameters = new SqlGenerationParameters<FifthweekUser, FifthweekUser.Fields>(user)
            {
                Conditions = new[]
                {
                    WhereUsernameNotTaken, 
                    WhereEmailNotTaken
                }
            };

            using (var transaction = TransactionScopeBuilder.CreateAsync())
            {
                using (var connection = this.connectionFactory.CreateConnection())
                {
                    var result = await connection.InsertAsync(parameters);

                    switch (result)
                    {
                        case 0: throw new RecoverableException("The username '" + username.Value + "' is already taken.");
                        case 1: throw new RecoverableException("The email address '" + email.Value + "' is already taken.");
                    }
                }

                await this.requestSnapshot.ExecuteAsync(userId, SnapshotType.Subscriber);

                transaction.Complete();
            }
        }
    }
}