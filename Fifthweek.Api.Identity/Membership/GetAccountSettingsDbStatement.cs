﻿namespace Fifthweek.Api.Identity.Membership
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Dapper;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.FileManagement.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;

    [AutoConstructor]
    public partial class GetAccountSettingsDbStatement : IGetAccountSettingsDbStatement
    {
        private static readonly string Sql = string.Format(
            @"SELECT u.{0}, u.{1}, u.{2}, u.{3}, cab.{4} as Balance
                FROM {5} u
                LEFT OUTER JOIN ({8}) cab 
                ON u.{6} = cab.{7}
                WHERE u.{6}=@UserId",
            FifthweekUser.Fields.Name,
            FifthweekUser.Fields.UserName,
            FifthweekUser.Fields.Email,
            FifthweekUser.Fields.ProfileImageFileId,
            CalculatedAccountBalance.Fields.Amount,
            FifthweekUser.Table,
            FifthweekUser.Fields.Id,
            CalculatedAccountBalance.Fields.UserId,
            CalculatedAccountBalance.GetQuery("UserId"));

        private readonly IFifthweekDbConnectionFactory connectionFactory;

        public async Task<GetAccountSettingsDbResult> ExecuteAsync(UserId userId)
        {
            userId.AssertNotNull("userId");

            using (var connection = this.connectionFactory.CreateConnection())
            {
                var result = (await connection.QueryAsync<GetAccountSettingsDapperResult>(
                         Sql,
                         new { UserId = userId.Value })).SingleOrDefault();

                if (result == null)
                {
                    throw new DetailedRecoverableException(
                        "Unknown user.",
                        "The user ID " + userId.Value + " was not found in the database.");
                }

                return new GetAccountSettingsDbResult(
                    result.Name == null ? null : new CreatorName(result.Name),
                    new Username(result.UserName),
                    new Email(result.Email), 
                    result.ProfileImageFileId == null ? null : new FileId(result.ProfileImageFileId.Value),
                    result.Balance == null ? 0 : result.Balance.Value);
            }
        }

        private class GetAccountSettingsDapperResult
        {
            public string Name { get; set; }

            public string UserName { get; set; }

            public string Email { get; set; }

            public Guid? ProfileImageFileId { get; set; }

            public decimal? Balance { get; set; }
        }
    }

    [AutoConstructor, AutoEqualityMembers]
    public partial class GetAccountSettingsDbResult
    {
        [Optional]
        public CreatorName Name { get; private set; }

        public Username Username { get; private set; }

        public Email Email { get; private set; }

        [Optional]
        public FileId ProfileImageFileId { get; private set; }

        public decimal Balance { get; set; }
    }
}