﻿namespace Dexter.Api
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Dexter.Api.Entities;
    using Dexter.Api.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class AuthenticationRepository : IDisposable
    {
        private readonly DexterDbContext dexterDbContext;

        private readonly UserManager<IdentityUser> userManager;

        public AuthenticationRepository()
        {
            this.dexterDbContext = new DexterDbContext();
            this.userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(this.dexterDbContext));
        }
 
        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            var user = new IdentityUser
            {
                UserName = userModel.UserName
            };
 
            var result = await this.userManager.CreateAsync(user, userModel.Password);
 
            return result;
        }
 
        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await this.userManager.FindAsync(userName, password);
 
            return user;
        }

        public Client FindClient(string clientId)
        {
            var client = this.dexterDbContext.Clients.Find(clientId);

            return client;
        }

        public async Task<bool> AddRefreshToken(RefreshToken token)
        {

            var existingToken = this.dexterDbContext.RefreshTokens.Where(r => r.UserName == token.UserName && r.ClientId == token.ClientId).SingleOrDefault();

            if (existingToken != null)
            {
                await RemoveRefreshToken(existingToken);
            }

            this.dexterDbContext.RefreshTokens.Add(token);

            return await this.dexterDbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = await this.dexterDbContext.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken != null)
            {
                this.dexterDbContext.RefreshTokens.Remove(refreshToken);
                return await this.dexterDbContext.SaveChangesAsync() > 0;
            }

            return false;
        }

        public async Task<bool> RemoveRefreshToken(RefreshToken refreshToken)
        {
            this.dexterDbContext.RefreshTokens.Remove(refreshToken);
            return await this.dexterDbContext.SaveChangesAsync() > 0;
        }

        public async Task<RefreshToken> FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = await this.dexterDbContext.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return this.dexterDbContext.RefreshTokens.ToList();
        }

        public async Task<IdentityUser> FindAsync(UserLoginInfo loginInfo)
        {
            IdentityUser user = await this.userManager.FindAsync(loginInfo);
 
            return user;
        }
 
        public async Task<IdentityResult> CreateAsync(IdentityUser user)
        {
            var result = await this.userManager.CreateAsync(user);
 
            return result;
        }
 
        public async Task<IdentityResult> AddLoginAsync(string userId, UserLoginInfo login)
        {
            var result = await this.userManager.AddLoginAsync(userId, login);
 
            return result;
        }

        public void Dispose()
        {
            this.dexterDbContext.Dispose();
            this.userManager.Dispose();
        }
    }
}