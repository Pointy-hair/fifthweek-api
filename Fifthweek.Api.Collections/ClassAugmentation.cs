﻿using System;
using System.Linq;

//// Generated on 01/06/2015 09:44:24 (UTC)
//// Mapped solution in 6.36s


namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class CollectionOwnership 
    {
        public CollectionOwnership(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class CollectionSecurity 
    {
        public CollectionSecurity(
            Fifthweek.Api.Collections.ICollectionOwnership collectionOwnership)
        {
            if (collectionOwnership == null)
            {
                throw new ArgumentNullException("collectionOwnership");
            }

            this.collectionOwnership = collectionOwnership;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class CreateCollectionCommand 
    {
        public CreateCollectionCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Collections.Shared.CollectionId newCollectionId,
            Fifthweek.Api.Channels.Shared.ChannelId channelId,
            Fifthweek.Api.Collections.Shared.ValidCollectionName name,
            Fifthweek.Api.Collections.Shared.HourOfWeek initialWeeklyReleaseTime)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (newCollectionId == null)
            {
                throw new ArgumentNullException("newCollectionId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (initialWeeklyReleaseTime == null)
            {
                throw new ArgumentNullException("initialWeeklyReleaseTime");
            }

            this.Requester = requester;
            this.NewCollectionId = newCollectionId;
            this.ChannelId = channelId;
            this.Name = name;
            this.InitialWeeklyReleaseTime = initialWeeklyReleaseTime;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class CreateCollectionCommandHandler 
    {
        public CreateCollectionCommandHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Api.Channels.Shared.IChannelSecurity channelSecurity,
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (channelSecurity == null)
            {
                throw new ArgumentNullException("channelSecurity");
            }

            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.requesterSecurity = requesterSecurity;
            this.channelSecurity = channelSecurity;
            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class UpdateCollectionCommand 
    {
        public UpdateCollectionCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Collections.Shared.CollectionId collectionId,
            Fifthweek.Api.Collections.Shared.ValidCollectionName name,
            Fifthweek.Api.Collections.Shared.WeeklyReleaseSchedule weeklyReleaseSchedule)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (collectionId == null)
            {
                throw new ArgumentNullException("collectionId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (weeklyReleaseSchedule == null)
            {
                throw new ArgumentNullException("weeklyReleaseSchedule");
            }

            this.Requester = requester;
            this.CollectionId = collectionId;
            this.Name = name;
            this.WeeklyReleaseSchedule = weeklyReleaseSchedule;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class CollectionController 
    {
        public CollectionController(
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Collections.Commands.CreateCollectionCommand> createCollection,
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Collections.Commands.UpdateCollectionCommand> updateCollection,
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Collections.Commands.DeleteCollectionCommand> deleteCollection,
            Fifthweek.Api.Core.IQueryHandler<Fifthweek.Api.Collections.Queries.GetLiveDateOfNewQueuedPostQuery,System.DateTime> getLiveDateOfNewQueuedPost,
            Fifthweek.Api.Identity.Shared.Membership.IRequesterContext requesterContext,
            Fifthweek.Api.Core.IGuidCreator guidCreator,
            Fifthweek.Shared.IRandom random)
        {
            if (createCollection == null)
            {
                throw new ArgumentNullException("createCollection");
            }

            if (updateCollection == null)
            {
                throw new ArgumentNullException("updateCollection");
            }

            if (deleteCollection == null)
            {
                throw new ArgumentNullException("deleteCollection");
            }

            if (getLiveDateOfNewQueuedPost == null)
            {
                throw new ArgumentNullException("getLiveDateOfNewQueuedPost");
            }

            if (requesterContext == null)
            {
                throw new ArgumentNullException("requesterContext");
            }

            if (guidCreator == null)
            {
                throw new ArgumentNullException("guidCreator");
            }

            if (random == null)
            {
                throw new ArgumentNullException("random");
            }

            this.createCollection = createCollection;
            this.updateCollection = updateCollection;
            this.deleteCollection = deleteCollection;
            this.getLiveDateOfNewQueuedPost = getLiveDateOfNewQueuedPost;
            this.requesterContext = requesterContext;
            this.guidCreator = guidCreator;
            this.random = random;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class NewCollectionData 
    {
        public NewCollectionData(
            Fifthweek.Api.Channels.Shared.ChannelId channelId,
            System.String name)
        {
            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            this.ChannelId = channelId;
            this.Name = name;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class UpdatedCollectionData 
    {
        public UpdatedCollectionData(
            System.String name,
            System.Collections.Generic.List<System.Int32> weeklyReleaseSchedule)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (weeklyReleaseSchedule == null)
            {
                throw new ArgumentNullException("weeklyReleaseSchedule");
            }

            this.Name = name;
            this.WeeklyReleaseSchedule = weeklyReleaseSchedule;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class GetWeeklyReleaseScheduleDbStatement 
    {
        public GetWeeklyReleaseScheduleDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class GetLiveDateOfNewQueuedPostDbStatement 
    {
        public GetLiveDateOfNewQueuedPostDbStatement(
            Fifthweek.Api.Collections.IGetNewQueuedPostLiveDateLowerBoundDbStatement getNewQueuedPostLiveDateLowerBound,
            Fifthweek.Api.Collections.Shared.IGetWeeklyReleaseScheduleDbStatement getWeeklyReleaseSchedule,
            Fifthweek.Api.Collections.IQueuedPostLiveDateCalculator queuedPostLiveDateCalculator)
        {
            if (getNewQueuedPostLiveDateLowerBound == null)
            {
                throw new ArgumentNullException("getNewQueuedPostLiveDateLowerBound");
            }

            if (getWeeklyReleaseSchedule == null)
            {
                throw new ArgumentNullException("getWeeklyReleaseSchedule");
            }

            if (queuedPostLiveDateCalculator == null)
            {
                throw new ArgumentNullException("queuedPostLiveDateCalculator");
            }

            this.getNewQueuedPostLiveDateLowerBound = getNewQueuedPostLiveDateLowerBound;
            this.getWeeklyReleaseSchedule = getWeeklyReleaseSchedule;
            this.queuedPostLiveDateCalculator = queuedPostLiveDateCalculator;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class GetNewQueuedPostLiveDateLowerBoundDbStatement 
    {
        public GetNewQueuedPostLiveDateLowerBoundDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections.Queries
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using System.Threading.Tasks;
    using Fifthweek.Shared;

    public partial class GetLiveDateOfNewQueuedPostQuery 
    {
        public GetLiveDateOfNewQueuedPostQuery(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Collections.Shared.CollectionId collectionId)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (collectionId == null)
            {
                throw new ArgumentNullException("collectionId");
            }

            this.Requester = requester;
            this.CollectionId = collectionId;
        }
    }
}
namespace Fifthweek.Api.Collections.Queries
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using System.Threading.Tasks;
    using Fifthweek.Shared;

    public partial class GetLiveDateOfNewQueuedPostQueryHandler 
    {
        public GetLiveDateOfNewQueuedPostQueryHandler(
            Fifthweek.Api.Collections.Shared.ICollectionSecurity collectionSecurity,
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Api.Collections.Shared.IGetLiveDateOfNewQueuedPostDbStatement getLiveDateOfNewQueuedPost)
        {
            if (collectionSecurity == null)
            {
                throw new ArgumentNullException("collectionSecurity");
            }

            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (getLiveDateOfNewQueuedPost == null)
            {
                throw new ArgumentNullException("getLiveDateOfNewQueuedPost");
            }

            this.collectionSecurity = collectionSecurity;
            this.requesterSecurity = requesterSecurity;
            this.getLiveDateOfNewQueuedPost = getLiveDateOfNewQueuedPost;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class UpdateCollectionCommandHandler 
    {
        public UpdateCollectionCommandHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Api.Collections.Shared.ICollectionSecurity collectionSecurity,
            Fifthweek.Api.Collections.IUpdateCollectionFieldsDbStatement updateCollectionFields,
            Fifthweek.Api.Collections.IUpdateWeeklyReleaseScheduleDbStatement updateWeeklyReleaseSchedule)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (collectionSecurity == null)
            {
                throw new ArgumentNullException("collectionSecurity");
            }

            if (updateCollectionFields == null)
            {
                throw new ArgumentNullException("updateCollectionFields");
            }

            if (updateWeeklyReleaseSchedule == null)
            {
                throw new ArgumentNullException("updateWeeklyReleaseSchedule");
            }

            this.requesterSecurity = requesterSecurity;
            this.collectionSecurity = collectionSecurity;
            this.updateCollectionFields = updateCollectionFields;
            this.updateWeeklyReleaseSchedule = updateWeeklyReleaseSchedule;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class DeleteCollectionCommand 
    {
        public DeleteCollectionCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Collections.Shared.CollectionId collectionId)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (collectionId == null)
            {
                throw new ArgumentNullException("collectionId");
            }

            this.Requester = requester;
            this.CollectionId = collectionId;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class DeleteCollectionCommandHandler 
    {
        public DeleteCollectionCommandHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Api.Collections.Shared.ICollectionSecurity collectionSecurity,
            Fifthweek.Api.Collections.IDeleteCollectionDbStatement deleteCollection,
            Fifthweek.Api.FileManagement.Shared.IScheduleGarbageCollectionStatement scheduleGarbageCollection)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (collectionSecurity == null)
            {
                throw new ArgumentNullException("collectionSecurity");
            }

            if (deleteCollection == null)
            {
                throw new ArgumentNullException("deleteCollection");
            }

            if (scheduleGarbageCollection == null)
            {
                throw new ArgumentNullException("scheduleGarbageCollection");
            }

            this.requesterSecurity = requesterSecurity;
            this.collectionSecurity = collectionSecurity;
            this.deleteCollection = deleteCollection;
            this.scheduleGarbageCollection = scheduleGarbageCollection;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class DeleteCollectionDbStatement 
    {
        public DeleteCollectionDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class DefragmentQueueDbStatement 
    {
        public DefragmentQueueDbStatement(
            Fifthweek.Api.Collections.IGetQueueSizeDbStatement getQueueSize,
            Fifthweek.Api.Collections.IGetQueueLowerBoundDbStatement getQueueLowerBound,
            Fifthweek.Api.Collections.IQueuedPostLiveDateCalculator liveDateCalculator,
            Fifthweek.Api.Collections.IUpdateAllLiveDatesInQueueDbStatement updateAllLiveDatesInQueue)
        {
            if (getQueueSize == null)
            {
                throw new ArgumentNullException("getQueueSize");
            }

            if (getQueueLowerBound == null)
            {
                throw new ArgumentNullException("getQueueLowerBound");
            }

            if (liveDateCalculator == null)
            {
                throw new ArgumentNullException("liveDateCalculator");
            }

            if (updateAllLiveDatesInQueue == null)
            {
                throw new ArgumentNullException("updateAllLiveDatesInQueue");
            }

            this.getQueueSize = getQueueSize;
            this.getQueueLowerBound = getQueueLowerBound;
            this.liveDateCalculator = liveDateCalculator;
            this.updateAllLiveDatesInQueue = updateAllLiveDatesInQueue;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class GetQueueSizeDbStatement 
    {
        public GetQueueSizeDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class UpdateAllLiveDatesInQueueDbStatement 
    {
        public UpdateAllLiveDatesInQueueDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class ReplaceWeeklyReleaseTimesDbStatement 
    {
        public ReplaceWeeklyReleaseTimesDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class UpdateCollectionFieldsDbStatement 
    {
        public UpdateCollectionFieldsDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class UpdateWeeklyReleaseScheduleDbStatement 
    {
        public UpdateWeeklyReleaseScheduleDbStatement(
            Fifthweek.Api.Collections.IReplaceWeeklyReleaseTimesDbStatement replaceWeeklyReleaseTimes,
            Fifthweek.Api.Collections.Shared.IDefragmentQueueDbStatement defragmentQueue)
        {
            if (replaceWeeklyReleaseTimes == null)
            {
                throw new ArgumentNullException("replaceWeeklyReleaseTimes");
            }

            if (defragmentQueue == null)
            {
                throw new ArgumentNullException("defragmentQueue");
            }

            this.replaceWeeklyReleaseTimes = replaceWeeklyReleaseTimes;
            this.defragmentQueue = defragmentQueue;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class CollectionCreation 
    {
        public CollectionCreation(
            Fifthweek.Api.Collections.Shared.CollectionId collectionId,
            Fifthweek.Api.Collections.Shared.HourOfWeek defaultWeeklyReleaseTime)
        {
            if (collectionId == null)
            {
                throw new ArgumentNullException("collectionId");
            }

            if (defaultWeeklyReleaseTime == null)
            {
                throw new ArgumentNullException("defaultWeeklyReleaseTime");
            }

            this.CollectionId = collectionId;
            this.DefaultWeeklyReleaseTime = defaultWeeklyReleaseTime;
        }
    }
}
namespace Fifthweek.Api.Collections
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Collections.Shared;
    using System.Collections.Generic;
    using System.Text;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Queries;
    using System.Transactions;
    using Fifthweek.Shared;

    public partial class GetQueueLowerBoundDbStatement 
    {
        public GetQueueLowerBoundDbStatement(
            Fifthweek.Api.Persistence.IFifthweekDbConnectionFactory connectionFactory)
        {
            if (connectionFactory == null)
            {
                throw new ArgumentNullException("connectionFactory");
            }

            this.connectionFactory = connectionFactory;
        }
    }
}

namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class CreateCollectionCommand 
    {
        public override string ToString()
        {
            return string.Format("CreateCollectionCommand({0}, {1}, {2}, {3}, {4})", this.Requester == null ? "null" : this.Requester.ToString(), this.NewCollectionId == null ? "null" : this.NewCollectionId.ToString(), this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.InitialWeeklyReleaseTime == null ? "null" : this.InitialWeeklyReleaseTime.ToString());
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
        
            return this.Equals((CreateCollectionCommand)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.NewCollectionId != null ? this.NewCollectionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.InitialWeeklyReleaseTime != null ? this.InitialWeeklyReleaseTime.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreateCollectionCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.NewCollectionId, other.NewCollectionId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (!object.Equals(this.InitialWeeklyReleaseTime, other.InitialWeeklyReleaseTime))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class UpdateCollectionCommand 
    {
        public override string ToString()
        {
            return string.Format("UpdateCollectionCommand({0}, {1}, {2}, {3})", this.Requester == null ? "null" : this.Requester.ToString(), this.CollectionId == null ? "null" : this.CollectionId.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.WeeklyReleaseSchedule == null ? "null" : this.WeeklyReleaseSchedule.ToString());
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
        
            return this.Equals((UpdateCollectionCommand)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CollectionId != null ? this.CollectionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.WeeklyReleaseSchedule != null ? this.WeeklyReleaseSchedule.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(UpdateCollectionCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.CollectionId, other.CollectionId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (!object.Equals(this.WeeklyReleaseSchedule, other.WeeklyReleaseSchedule))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class NewCollectionData 
    {
        public override string ToString()
        {
            return string.Format("NewCollectionData({0}, \"{1}\")", this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.Name == null ? "null" : this.Name.ToString());
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
        
            return this.Equals((NewCollectionData)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(NewCollectionData other)
        {
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class UpdatedCollectionData 
    {
        public override string ToString()
        {
            return string.Format("UpdatedCollectionData(\"{0}\", {1})", this.Name == null ? "null" : this.Name.ToString(), this.WeeklyReleaseSchedule == null ? "null" : this.WeeklyReleaseSchedule.ToString());
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
        
            return this.Equals((UpdatedCollectionData)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.WeeklyReleaseSchedule != null 
        			? this.WeeklyReleaseSchedule.Aggregate(0, (previous, current) => 
        				{ 
        				    unchecked
        				    {
        				        return (previous * 397) ^ (current != null ? current.GetHashCode() : 0);
        				    }
        				})
        			: 0);
                return hashCode;
            }
        }
        
        protected bool Equals(UpdatedCollectionData other)
        {
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (this.WeeklyReleaseSchedule != null && other.WeeklyReleaseSchedule != null)
            {
                if (!this.WeeklyReleaseSchedule.SequenceEqual(other.WeeklyReleaseSchedule))
                {
                    return false;    
                }
            }
            else if (this.WeeklyReleaseSchedule != null || other.WeeklyReleaseSchedule != null)
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Queries
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using System.Threading.Tasks;
    using Fifthweek.Shared;

    public partial class GetLiveDateOfNewQueuedPostQuery 
    {
        public override string ToString()
        {
            return string.Format("GetLiveDateOfNewQueuedPostQuery({0}, {1})", this.Requester == null ? "null" : this.Requester.ToString(), this.CollectionId == null ? "null" : this.CollectionId.ToString());
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
        
            return this.Equals((GetLiveDateOfNewQueuedPostQuery)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CollectionId != null ? this.CollectionId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(GetLiveDateOfNewQueuedPostQuery other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.CollectionId, other.CollectionId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Channels.Shared;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using System.Transactions;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using Dapper;
    using Fifthweek.Api.FileManagement.Shared;

    public partial class DeleteCollectionCommand 
    {
        public override string ToString()
        {
            return string.Format("DeleteCollectionCommand({0}, {1})", this.Requester == null ? "null" : this.Requester.ToString(), this.CollectionId == null ? "null" : this.CollectionId.ToString());
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
        
            return this.Equals((DeleteCollectionCommand)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CollectionId != null ? this.CollectionId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(DeleteCollectionCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.CollectionId, other.CollectionId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class CollectionCreation 
    {
        public override string ToString()
        {
            return string.Format("CollectionCreation({0}, {1})", this.CollectionId == null ? "null" : this.CollectionId.ToString(), this.DefaultWeeklyReleaseTime == null ? "null" : this.DefaultWeeklyReleaseTime.ToString());
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
        
            return this.Equals((CollectionCreation)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.CollectionId != null ? this.CollectionId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.DefaultWeeklyReleaseTime != null ? this.DefaultWeeklyReleaseTime.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CollectionCreation other)
        {
            if (!object.Equals(this.CollectionId, other.CollectionId))
            {
                return false;
            }
        
            if (!object.Equals(this.DefaultWeeklyReleaseTime, other.DefaultWeeklyReleaseTime))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class NewCollectionData 
    {
        public class Parsed
        {
            public Parsed(
                Fifthweek.Api.Channels.Shared.ChannelId channelId,
                ValidCollectionName name)
            {
                if (channelId == null)
                {
                    throw new ArgumentNullException("channelId");
                }

                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }

                this.ChannelId = channelId;
                this.Name = name;
            }
        
            public Fifthweek.Api.Channels.Shared.ChannelId ChannelId { get; private set; }
        
            public ValidCollectionName Name { get; private set; }
        }
    }

    public static partial class NewCollectionDataExtensions
    {
        public static NewCollectionData.Parsed Parse(this NewCollectionData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();
        
            ValidCollectionName parsed0 = null;
            if (!ValidCollectionName.IsEmpty(target.Name))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed0Errors;
                if (!ValidCollectionName.TryParse(target.Name, out parsed0, out parsed0Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed0Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Name", modelState);
                }
            }
            else
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                modelState.Errors.Add("Value required");
                modelStateDictionary.Add("Name", modelState);
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        
            return new NewCollectionData.Parsed(
                target.ChannelId,
                parsed0);
        }    
    }
}
namespace Fifthweek.Api.Collections.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Fifthweek.Api.Collections.Commands;
    using Fifthweek.Api.Collections.Queries;
    using Fifthweek.Api.Collections.Shared;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Channels.Shared;
    using System.Collections.Generic;
    using Fifthweek.Shared;

    public partial class UpdatedCollectionData 
    {
        public class Parsed
        {
            public Parsed(
                ValidCollectionName name,
                WeeklyReleaseSchedule weeklyReleaseSchedule)
            {
                if (name == null)
                {
                    throw new ArgumentNullException("name");
                }

                if (weeklyReleaseSchedule == null)
                {
                    throw new ArgumentNullException("weeklyReleaseSchedule");
                }

                this.Name = name;
                this.WeeklyReleaseSchedule = weeklyReleaseSchedule;
            }
        
            public ValidCollectionName Name { get; private set; }
        
            public WeeklyReleaseSchedule WeeklyReleaseSchedule { get; private set; }
        }
    }

    public static partial class UpdatedCollectionDataExtensions
    {
        public static UpdatedCollectionData.Parsed Parse(this UpdatedCollectionData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();
        
            ValidCollectionName parsed0 = null;
            if (!ValidCollectionName.IsEmpty(target.Name))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed0Errors;
                if (!ValidCollectionName.TryParse(target.Name, out parsed0, out parsed0Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed0Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("Name", modelState);
                }
            }
            else
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                modelState.Errors.Add("Value required");
                modelStateDictionary.Add("Name", modelState);
            }

            System.Collections.Generic.List<Fifthweek.Api.Collections.Shared.HourOfWeek> parsed1Buffer = null;
            if (target.WeeklyReleaseSchedule != null)
            {
                parsed1Buffer = new System.Collections.Generic.List<Fifthweek.Api.Collections.Shared.HourOfWeek>();
                for (var i = 0; i < target.WeeklyReleaseSchedule.Count; i++)
                {
                    Fifthweek.Api.Collections.Shared.HourOfWeek parsedElement = null;
                    System.Collections.Generic.IReadOnlyCollection<string> parsedElementErrors;
                    if (!Fifthweek.Api.Collections.Shared.HourOfWeek.TryParse(target.WeeklyReleaseSchedule[i], out parsedElement, out parsedElementErrors))
                    {
                        var modelState = new System.Web.Http.ModelBinding.ModelState();
                        foreach (var errorMessage in parsedElementErrors)
                        {
                            modelState.Errors.Add(errorMessage);
                        }

                        modelStateDictionary.Add("WeeklyReleaseSchedule[" + i + "]", modelState);
                    }

                    if (parsedElement != null)
                    {
                        parsed1Buffer.Add(parsedElement);
                    }
                }
            }

            WeeklyReleaseSchedule parsed1 = null;
            if (!WeeklyReleaseSchedule.IsEmpty(parsed1Buffer))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed1Errors;
                if (!WeeklyReleaseSchedule.TryParse(parsed1Buffer, out parsed1, out parsed1Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed1Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("WeeklyReleaseSchedule", modelState);
                }
            }
            else
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                modelState.Errors.Add("Value required");
                modelStateDictionary.Add("WeeklyReleaseSchedule", modelState);
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        
            return new UpdatedCollectionData.Parsed(
                parsed0,
                parsed1);
        }    
    }
}


