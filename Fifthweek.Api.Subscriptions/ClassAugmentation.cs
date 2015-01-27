﻿using System;
using System.Linq;

namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class CreateSubscriptionCommand 
    {
        public CreateSubscriptionCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester, 
            Fifthweek.Api.Subscriptions.Shared.SubscriptionId newSubscriptionId, 
            Fifthweek.Api.Subscriptions.Shared.ValidSubscriptionName subscriptionName, 
            Fifthweek.Api.Subscriptions.Shared.ValidTagline tagline, 
            Fifthweek.Api.Channels.Shared.ValidChannelPriceInUsCentsPerWeek basePrice)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (newSubscriptionId == null)
            {
                throw new ArgumentNullException("newSubscriptionId");
            }

            if (subscriptionName == null)
            {
                throw new ArgumentNullException("subscriptionName");
            }

            if (tagline == null)
            {
                throw new ArgumentNullException("tagline");
            }

            if (basePrice == null)
            {
                throw new ArgumentNullException("basePrice");
            }

            this.Requester = requester;
            this.NewSubscriptionId = newSubscriptionId;
            this.SubscriptionName = subscriptionName;
            this.Tagline = tagline;
            this.BasePrice = basePrice;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class CreateSubscriptionCommandHandler 
    {
        public CreateSubscriptionCommandHandler(
            Fifthweek.Api.Subscriptions.Shared.ISubscriptionSecurity subscriptionSecurity, 
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity, 
            Fifthweek.Api.Persistence.IFifthweekDbContext fifthweekDbContext)
        {
            if (subscriptionSecurity == null)
            {
                throw new ArgumentNullException("subscriptionSecurity");
            }

            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (fifthweekDbContext == null)
            {
                throw new ArgumentNullException("fifthweekDbContext");
            }

            this.subscriptionSecurity = subscriptionSecurity;
            this.requesterSecurity = requesterSecurity;
            this.fifthweekDbContext = fifthweekDbContext;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class PromoteNewUserToCreatorCommand 
    {
        public PromoteNewUserToCreatorCommand(
            Fifthweek.Api.Identity.Shared.Membership.UserId newUserId)
        {
            if (newUserId == null)
            {
                throw new ArgumentNullException("newUserId");
            }

            this.NewUserId = newUserId;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class PromoteNewUserToCreatorCommandHandler 
    {
        public PromoteNewUserToCreatorCommandHandler(
            Fifthweek.Api.Persistence.IUserManager userManager)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException("userManager");
            }

            this.userManager = userManager;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class PromoteNewUserToCreatorCommandInitiator 
    {
        public PromoteNewUserToCreatorCommandInitiator(
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Subscriptions.Commands.PromoteNewUserToCreatorCommand> promoteNewUserToCreator)
        {
            if (promoteNewUserToCreator == null)
            {
                throw new ArgumentNullException("promoteNewUserToCreator");
            }

            this.promoteNewUserToCreator = promoteNewUserToCreator;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class UpdateSubscriptionCommand 
    {
        public UpdateSubscriptionCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester, 
            Fifthweek.Api.Subscriptions.Shared.SubscriptionId subscriptionId, 
            Fifthweek.Api.Subscriptions.Shared.ValidSubscriptionName subscriptionName, 
            Fifthweek.Api.Subscriptions.Shared.ValidTagline tagline, 
            Fifthweek.Api.Subscriptions.Shared.ValidIntroduction introduction, 
            Fifthweek.Api.Subscriptions.Shared.ValidDescription description, 
            Fifthweek.Api.FileManagement.Shared.FileId headerImageFileId, 
            Fifthweek.Api.Subscriptions.Shared.ValidExternalVideoUrl video)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (subscriptionId == null)
            {
                throw new ArgumentNullException("subscriptionId");
            }

            if (subscriptionName == null)
            {
                throw new ArgumentNullException("subscriptionName");
            }

            if (tagline == null)
            {
                throw new ArgumentNullException("tagline");
            }

            if (introduction == null)
            {
                throw new ArgumentNullException("introduction");
            }

            this.Requester = requester;
            this.SubscriptionId = subscriptionId;
            this.SubscriptionName = subscriptionName;
            this.Tagline = tagline;
            this.Introduction = introduction;
            this.Description = description;
            this.HeaderImageFileId = headerImageFileId;
            this.Video = video;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class UpdateSubscriptionCommandHandler 
    {
        public UpdateSubscriptionCommandHandler(
            Fifthweek.Api.Subscriptions.Shared.ISubscriptionSecurity subscriptionSecurity, 
            Fifthweek.Api.FileManagement.Shared.IFileSecurity fileSecurity, 
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity, 
            Fifthweek.Api.Persistence.IFifthweekDbContext databaseContext)
        {
            if (subscriptionSecurity == null)
            {
                throw new ArgumentNullException("subscriptionSecurity");
            }

            if (fileSecurity == null)
            {
                throw new ArgumentNullException("fileSecurity");
            }

            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (databaseContext == null)
            {
                throw new ArgumentNullException("databaseContext");
            }

            this.subscriptionSecurity = subscriptionSecurity;
            this.fileSecurity = fileSecurity;
            this.requesterSecurity = requesterSecurity;
            this.databaseContext = databaseContext;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class SubscriptionController 
    {
        public SubscriptionController(
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Subscriptions.Commands.CreateSubscriptionCommand> createSubscription, 
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Subscriptions.Commands.UpdateSubscriptionCommand> updateSubscription, 
            IRequesterContext requesterContext, 
            Fifthweek.Api.Core.IGuidCreator guidCreator)
        {
            if (createSubscription == null)
            {
                throw new ArgumentNullException("createSubscription");
            }

            if (updateSubscription == null)
            {
                throw new ArgumentNullException("updateSubscription");
            }

            if (requesterContext == null)
            {
                throw new ArgumentNullException("requesterContext");
            }

            if (guidCreator == null)
            {
                throw new ArgumentNullException("guidCreator");
            }

            this.createSubscription = createSubscription;
            this.updateSubscription = updateSubscription;
            this.requesterContext = requesterContext;
            this.guidCreator = guidCreator;
        }
    }

}
namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class CreatorStatus 
    {
        public CreatorStatus(
            Fifthweek.Api.Subscriptions.Shared.SubscriptionId subscriptionId, 
            System.Boolean mustWriteFirstPost)
        {
            if (mustWriteFirstPost == null)
            {
                throw new ArgumentNullException("mustWriteFirstPost");
            }

            this.SubscriptionId = subscriptionId;
            this.MustWriteFirstPost = mustWriteFirstPost;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class GetCreatorStatusQuery 
    {
        public GetCreatorStatusQuery(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester, 
            Fifthweek.Api.Identity.Shared.Membership.UserId requestedUserId)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (requestedUserId == null)
            {
                throw new ArgumentNullException("requestedUserId");
            }

            this.Requester = requester;
            this.RequestedUserId = requestedUserId;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class GetCreatorStatusQueryHandler 
    {
        public GetCreatorStatusQueryHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity, 
            Fifthweek.Api.Persistence.IFifthweekDbContext databaseContext)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (databaseContext == null)
            {
                throw new ArgumentNullException("databaseContext");
            }

            this.requesterSecurity = requesterSecurity;
            this.databaseContext = databaseContext;
        }
    }

}
namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class SubscriptionOwnership 
    {
        public SubscriptionOwnership(
            Fifthweek.Api.Persistence.IFifthweekDbContext databaseContext)
        {
            if (databaseContext == null)
            {
                throw new ArgumentNullException("databaseContext");
            }

            this.databaseContext = databaseContext;
        }
    }

}
namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class SubscriptionSecurity 
    {
        public SubscriptionSecurity(
            Fifthweek.Api.Persistence.IUserManager userManager, 
            Fifthweek.Api.Subscriptions.ISubscriptionOwnership subscriptionOwnership)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException("userManager");
            }

            if (subscriptionOwnership == null)
            {
                throw new ArgumentNullException("subscriptionOwnership");
            }

            this.userManager = userManager;
            this.subscriptionOwnership = subscriptionOwnership;
        }
    }

}

namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class CreateSubscriptionCommand 
    {
        public override string ToString()
        {
            return string.Format("CreateSubscriptionCommand({0}, {1}, {2}, {3}, {4})", this.Requester == null ? "null" : this.Requester.ToString(), this.NewSubscriptionId == null ? "null" : this.NewSubscriptionId.ToString(), this.SubscriptionName == null ? "null" : this.SubscriptionName.ToString(), this.Tagline == null ? "null" : this.Tagline.ToString(), this.BasePrice == null ? "null" : this.BasePrice.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((CreateSubscriptionCommand)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.NewSubscriptionId != null ? this.NewSubscriptionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionName != null ? this.SubscriptionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Tagline != null ? this.Tagline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BasePrice != null ? this.BasePrice.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(CreateSubscriptionCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }

            if (!object.Equals(this.NewSubscriptionId, other.NewSubscriptionId))
            {
                return false;
            }

            if (!object.Equals(this.SubscriptionName, other.SubscriptionName))
            {
                return false;
            }

            if (!object.Equals(this.Tagline, other.Tagline))
            {
                return false;
            }

            if (!object.Equals(this.BasePrice, other.BasePrice))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class PromoteNewUserToCreatorCommand 
    {
        public override string ToString()
        {
            return string.Format("PromoteNewUserToCreatorCommand({0})", this.NewUserId == null ? "null" : this.NewUserId.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((PromoteNewUserToCreatorCommand)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.NewUserId != null ? this.NewUserId.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(PromoteNewUserToCreatorCommand other)
        {
            if (!object.Equals(this.NewUserId, other.NewUserId))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Identity.Membership.Events;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class UpdateSubscriptionCommand 
    {
        public override string ToString()
        {
            return string.Format("UpdateSubscriptionCommand({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7})", this.Requester == null ? "null" : this.Requester.ToString(), this.SubscriptionId == null ? "null" : this.SubscriptionId.ToString(), this.SubscriptionName == null ? "null" : this.SubscriptionName.ToString(), this.Tagline == null ? "null" : this.Tagline.ToString(), this.Introduction == null ? "null" : this.Introduction.ToString(), this.Description == null ? "null" : this.Description.ToString(), this.HeaderImageFileId == null ? "null" : this.HeaderImageFileId.ToString(), this.Video == null ? "null" : this.Video.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((UpdateSubscriptionCommand)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionId != null ? this.SubscriptionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionName != null ? this.SubscriptionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Tagline != null ? this.Tagline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Introduction != null ? this.Introduction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Description != null ? this.Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.HeaderImageFileId != null ? this.HeaderImageFileId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Video != null ? this.Video.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(UpdateSubscriptionCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }

            if (!object.Equals(this.SubscriptionId, other.SubscriptionId))
            {
                return false;
            }

            if (!object.Equals(this.SubscriptionName, other.SubscriptionName))
            {
                return false;
            }

            if (!object.Equals(this.Tagline, other.Tagline))
            {
                return false;
            }

            if (!object.Equals(this.Introduction, other.Introduction))
            {
                return false;
            }

            if (!object.Equals(this.Description, other.Description))
            {
                return false;
            }

            if (!object.Equals(this.HeaderImageFileId, other.HeaderImageFileId))
            {
                return false;
            }

            if (!object.Equals(this.Video, other.Video))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class CreatorStatus 
    {
        public override string ToString()
        {
            return string.Format("CreatorStatus({0}, {1})", this.SubscriptionId == null ? "null" : this.SubscriptionId.ToString(), this.MustWriteFirstPost == null ? "null" : this.MustWriteFirstPost.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((CreatorStatus)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SubscriptionId != null ? this.SubscriptionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.MustWriteFirstPost != null ? this.MustWriteFirstPost.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(CreatorStatus other)
        {
            if (!object.Equals(this.SubscriptionId, other.SubscriptionId))
            {
                return false;
            }

            if (!object.Equals(this.MustWriteFirstPost, other.MustWriteFirstPost))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Subscriptions.Shared;
    public partial class GetCreatorStatusQuery 
    {
        public override string ToString()
        {
            return string.Format("GetCreatorStatusQuery({0}, {1})", this.Requester == null ? "null" : this.Requester.ToString(), this.RequestedUserId == null ? "null" : this.RequestedUserId.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((GetCreatorStatusQuery)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.RequestedUserId != null ? this.RequestedUserId.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(GetCreatorStatusQuery other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }

            if (!object.Equals(this.RequestedUserId, other.RequestedUserId))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class NewSubscriptionData 
    {
        public override string ToString()
        {
            return string.Format("NewSubscriptionData({0}, {1}, {2}, \"{3}\", \"{4}\", {5})", this.SubscriptionNameObject == null ? "null" : this.SubscriptionNameObject.ToString(), this.TaglineObject == null ? "null" : this.TaglineObject.ToString(), this.BasePriceObject == null ? "null" : this.BasePriceObject.ToString(), this.SubscriptionName == null ? "null" : this.SubscriptionName.ToString(), this.Tagline == null ? "null" : this.Tagline.ToString(), this.BasePrice == null ? "null" : this.BasePrice.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((NewSubscriptionData)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SubscriptionNameObject != null ? this.SubscriptionNameObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaglineObject != null ? this.TaglineObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BasePriceObject != null ? this.BasePriceObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionName != null ? this.SubscriptionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Tagline != null ? this.Tagline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BasePrice != null ? this.BasePrice.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(NewSubscriptionData other)
        {
            if (!object.Equals(this.SubscriptionNameObject, other.SubscriptionNameObject))
            {
                return false;
            }

            if (!object.Equals(this.TaglineObject, other.TaglineObject))
            {
                return false;
            }

            if (!object.Equals(this.BasePriceObject, other.BasePriceObject))
            {
                return false;
            }

            if (!object.Equals(this.SubscriptionName, other.SubscriptionName))
            {
                return false;
            }

            if (!object.Equals(this.Tagline, other.Tagline))
            {
                return false;
            }

            if (!object.Equals(this.BasePrice, other.BasePrice))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class UpdatedSubscriptionData 
    {
        public override string ToString()
        {
            return string.Format("UpdatedSubscriptionData({0}, {1}, {2}, {3}, {4}, \"{5}\", \"{6}\", \"{7}\", {8}, \"{9}\", \"{10}\")", this.SubscriptionNameObject == null ? "null" : this.SubscriptionNameObject.ToString(), this.TaglineObject == null ? "null" : this.TaglineObject.ToString(), this.IntroductionObject == null ? "null" : this.IntroductionObject.ToString(), this.VideoObject == null ? "null" : this.VideoObject.ToString(), this.DescriptionObject == null ? "null" : this.DescriptionObject.ToString(), this.SubscriptionName == null ? "null" : this.SubscriptionName.ToString(), this.Tagline == null ? "null" : this.Tagline.ToString(), this.Introduction == null ? "null" : this.Introduction.ToString(), this.HeaderImageFileId == null ? "null" : this.HeaderImageFileId.ToString(), this.Video == null ? "null" : this.Video.ToString(), this.Description == null ? "null" : this.Description.ToString());
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((UpdatedSubscriptionData)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SubscriptionNameObject != null ? this.SubscriptionNameObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaglineObject != null ? this.TaglineObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IntroductionObject != null ? this.IntroductionObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.VideoObject != null ? this.VideoObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.DescriptionObject != null ? this.DescriptionObject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionName != null ? this.SubscriptionName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Tagline != null ? this.Tagline.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Introduction != null ? this.Introduction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.HeaderImageFileId != null ? this.HeaderImageFileId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Video != null ? this.Video.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Description != null ? this.Description.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(UpdatedSubscriptionData other)
        {
            if (!object.Equals(this.SubscriptionNameObject, other.SubscriptionNameObject))
            {
                return false;
            }

            if (!object.Equals(this.TaglineObject, other.TaglineObject))
            {
                return false;
            }

            if (!object.Equals(this.IntroductionObject, other.IntroductionObject))
            {
                return false;
            }

            if (!object.Equals(this.VideoObject, other.VideoObject))
            {
                return false;
            }

            if (!object.Equals(this.DescriptionObject, other.DescriptionObject))
            {
                return false;
            }

            if (!object.Equals(this.SubscriptionName, other.SubscriptionName))
            {
                return false;
            }

            if (!object.Equals(this.Tagline, other.Tagline))
            {
                return false;
            }

            if (!object.Equals(this.Introduction, other.Introduction))
            {
                return false;
            }

            if (!object.Equals(this.HeaderImageFileId, other.HeaderImageFileId))
            {
                return false;
            }

            if (!object.Equals(this.Video, other.Video))
            {
                return false;
            }

            if (!object.Equals(this.Description, other.Description))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class NewSubscriptionData 
    {
		[Optional]
        public ValidSubscriptionName SubscriptionNameObject { get; set; }
		[Optional]
        public ValidTagline TaglineObject { get; set; }
		[Optional]
        public ValidChannelPriceInUsCentsPerWeek BasePriceObject { get; set; }
    }

    public static partial class NewSubscriptionDataExtensions
    {
        public static void Parse(this NewSubscriptionData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();

            if (true || !ValidSubscriptionName.IsEmpty(target.SubscriptionName))
            {
                ValidSubscriptionName @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidSubscriptionName.TryParse(target.SubscriptionName, out @object, out errorMessages))
                {
                    target.SubscriptionNameObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("SubscriptionName", modelState);
                }
            }

            if (true || !ValidTagline.IsEmpty(target.Tagline))
            {
                ValidTagline @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidTagline.TryParse(target.Tagline, out @object, out errorMessages))
                {
                    target.TaglineObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Tagline", modelState);
                }
            }

            if (true || !ValidChannelPriceInUsCentsPerWeek.IsEmpty(target.BasePrice))
            {
                ValidChannelPriceInUsCentsPerWeek @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidChannelPriceInUsCentsPerWeek.TryParse(target.BasePrice, out @object, out errorMessages))
                {
                    target.BasePriceObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("BasePrice", modelState);
                }
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        }    
    }
}
namespace Fifthweek.Api.Subscriptions.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.Api.Subscriptions.Commands;
    using Fifthweek.Api.Subscriptions.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.FileManagement.Shared;
    public partial class UpdatedSubscriptionData 
    {
		[Optional]
        public ValidSubscriptionName SubscriptionNameObject { get; set; }
		[Optional]
        public ValidTagline TaglineObject { get; set; }
		[Optional]
        public ValidIntroduction IntroductionObject { get; set; }
		[Optional]
        public ValidExternalVideoUrl VideoObject { get; set; }
		[Optional]
        public ValidDescription DescriptionObject { get; set; }
    }

    public static partial class UpdatedSubscriptionDataExtensions
    {
        public static void Parse(this UpdatedSubscriptionData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();

            if (true || !ValidSubscriptionName.IsEmpty(target.SubscriptionName))
            {
                ValidSubscriptionName @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidSubscriptionName.TryParse(target.SubscriptionName, out @object, out errorMessages))
                {
                    target.SubscriptionNameObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("SubscriptionName", modelState);
                }
            }

            if (true || !ValidTagline.IsEmpty(target.Tagline))
            {
                ValidTagline @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidTagline.TryParse(target.Tagline, out @object, out errorMessages))
                {
                    target.TaglineObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Tagline", modelState);
                }
            }

            if (true || !ValidIntroduction.IsEmpty(target.Introduction))
            {
                ValidIntroduction @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidIntroduction.TryParse(target.Introduction, out @object, out errorMessages))
                {
                    target.IntroductionObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Introduction", modelState);
                }
            }

            if (false || !ValidExternalVideoUrl.IsEmpty(target.Video))
            {
                ValidExternalVideoUrl @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidExternalVideoUrl.TryParse(target.Video, out @object, out errorMessages))
                {
                    target.VideoObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Video", modelState);
                }
            }

            if (true || !ValidDescription.IsEmpty(target.Description))
            {
                ValidDescription @object;
                System.Collections.Generic.IReadOnlyCollection<string> errorMessages;
                if (ValidDescription.TryParse(target.Description, out @object, out errorMessages))
                {
                    target.DescriptionObject = @object;
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in errorMessages)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Description", modelState);
                }
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        }    
    }
}

