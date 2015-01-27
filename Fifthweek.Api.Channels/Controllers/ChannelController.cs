﻿namespace Fifthweek.Api.Channels.Controllers
{
    using System.Web.Http;

    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.CodeGeneration;

    [RoutePrefix("collections"), AutoConstructor]
    public partial class ChannelController : ApiController
    {
        private readonly IUserContext userContext;
        private readonly IGuidCreator guidCreator;


    }
}