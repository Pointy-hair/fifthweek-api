﻿using System;
using System.Linq;

//// Generated on 16/11/2015 11:56:24 (UTC)
//// Mapped solution in 17.93s


namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class Blog 
    {
        public Blog(
            System.Guid id,
            System.Guid creatorId,
            Fifthweek.Api.Persistence.Identity.FifthweekUser creator,
            System.String name,
            System.String introduction,
            System.String description,
            System.String externalVideoUrl,
            System.Nullable<System.Guid> headerImageFileId,
            Fifthweek.Api.Persistence.File headerImageFile,
            System.DateTime creationDate)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            this.Id = id;
            this.CreatorId = creatorId;
            this.Creator = creator;
            this.Name = name;
            this.Introduction = introduction;
            this.Description = description;
            this.ExternalVideoUrl = externalVideoUrl;
            this.HeaderImageFileId = headerImageFileId;
            this.HeaderImageFile = headerImageFile;
            this.CreationDate = creationDate;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using Fifthweek.Api.Persistence.Identity;

    public partial class Channel 
    {
        public Channel(
            System.Guid id,
            System.Guid blogId,
            Fifthweek.Api.Persistence.Blog blog,
            System.String name,
            System.Int32 price,
            System.Boolean isVisibleToNonSubscribers,
            System.DateTime creationDate,
            System.DateTime priceLastSetDate,
            System.Boolean isDiscoverable)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (blogId == null)
            {
                throw new ArgumentNullException("blogId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            if (isVisibleToNonSubscribers == null)
            {
                throw new ArgumentNullException("isVisibleToNonSubscribers");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            if (priceLastSetDate == null)
            {
                throw new ArgumentNullException("priceLastSetDate");
            }

            if (isDiscoverable == null)
            {
                throw new ArgumentNullException("isDiscoverable");
            }

            this.Id = id;
            this.BlogId = blogId;
            this.Blog = blog;
            this.Name = name;
            this.Price = price;
            this.IsVisibleToNonSubscribers = isVisibleToNonSubscribers;
            this.CreationDate = creationDate;
            this.PriceLastSetDate = priceLastSetDate;
            this.IsDiscoverable = isDiscoverable;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class ChannelSubscription 
    {
        public ChannelSubscription(
            System.Guid channelId,
            Fifthweek.Api.Persistence.Channel channel,
            System.Guid userId,
            Fifthweek.Api.Persistence.Identity.FifthweekUser user,
            System.Int32 acceptedPrice,
            System.DateTime priceLastAcceptedDate,
            System.DateTime subscriptionStartDate)
        {
            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (acceptedPrice == null)
            {
                throw new ArgumentNullException("acceptedPrice");
            }

            if (priceLastAcceptedDate == null)
            {
                throw new ArgumentNullException("priceLastAcceptedDate");
            }

            if (subscriptionStartDate == null)
            {
                throw new ArgumentNullException("subscriptionStartDate");
            }

            this.ChannelId = channelId;
            this.Channel = channel;
            this.UserId = userId;
            this.User = user;
            this.AcceptedPrice = acceptedPrice;
            this.PriceLastAcceptedDate = priceLastAcceptedDate;
            this.SubscriptionStartDate = subscriptionStartDate;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Queue 
    {
        public Queue(
            System.Guid id,
            System.Guid blogId,
            Fifthweek.Api.Persistence.Blog blog,
            System.String name,
            System.DateTime creationDate)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (blogId == null)
            {
                throw new ArgumentNullException("blogId");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            this.Id = id;
            this.BlogId = blogId;
            this.Blog = blog;
            this.Name = name;
            this.CreationDate = creationDate;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class EndToEndTestEmail 
    {
        public EndToEndTestEmail(
            System.String mailbox,
            System.String subject,
            System.String body,
            System.DateTime dateReceived)
        {
            if (mailbox == null)
            {
                throw new ArgumentNullException("mailbox");
            }

            if (subject == null)
            {
                throw new ArgumentNullException("subject");
            }

            if (body == null)
            {
                throw new ArgumentNullException("body");
            }

            if (dateReceived == null)
            {
                throw new ArgumentNullException("dateReceived");
            }

            this.Mailbox = mailbox;
            this.Subject = subject;
            this.Body = body;
            this.DateReceived = dateReceived;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class File 
    {
        public File(
            System.Guid id,
            System.Guid userId,
            System.Nullable<System.Guid> channelId,
            Fifthweek.Api.Persistence.FileState state,
            System.DateTime uploadStartedDate,
            System.Nullable<System.DateTime> uploadCompletedDate,
            System.Nullable<System.DateTime> processingStartedDate,
            System.Nullable<System.DateTime> processingCompletedDate,
            System.Nullable<System.Int32> processingAttempts,
            System.String fileNameWithoutExtension,
            System.String fileExtension,
            System.Int64 blobSizeBytes,
            System.String purpose,
            System.Nullable<System.Int32> renderWidth,
            System.Nullable<System.Int32> renderHeight)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (state == null)
            {
                throw new ArgumentNullException("state");
            }

            if (uploadStartedDate == null)
            {
                throw new ArgumentNullException("uploadStartedDate");
            }

            if (fileNameWithoutExtension == null)
            {
                throw new ArgumentNullException("fileNameWithoutExtension");
            }

            if (fileExtension == null)
            {
                throw new ArgumentNullException("fileExtension");
            }

            if (blobSizeBytes == null)
            {
                throw new ArgumentNullException("blobSizeBytes");
            }

            if (purpose == null)
            {
                throw new ArgumentNullException("purpose");
            }

            this.Id = id;
            this.UserId = userId;
            this.ChannelId = channelId;
            this.State = state;
            this.UploadStartedDate = uploadStartedDate;
            this.UploadCompletedDate = uploadCompletedDate;
            this.ProcessingStartedDate = processingStartedDate;
            this.ProcessingCompletedDate = processingCompletedDate;
            this.ProcessingAttempts = processingAttempts;
            this.FileNameWithoutExtension = fileNameWithoutExtension;
            this.FileExtension = fileExtension;
            this.BlobSizeBytes = blobSizeBytes;
            this.Purpose = purpose;
            this.RenderWidth = renderWidth;
            this.RenderHeight = renderHeight;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreeAccessUser 
    {
        public FreeAccessUser(
            System.Guid blogId,
            Fifthweek.Api.Persistence.Blog blog,
            System.String email)
        {
            if (blogId == null)
            {
                throw new ArgumentNullException("blogId");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            this.BlogId = blogId;
            this.Blog = blog;
            this.Email = email;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Post 
    {
        public Post(
            System.Guid id,
            System.Guid channelId,
            Fifthweek.Api.Persistence.Channel channel,
            System.Nullable<System.Guid> queueId,
            Fifthweek.Api.Persistence.Queue queue,
            System.Nullable<System.Guid> previewImageId,
            Fifthweek.Api.Persistence.File previewImage,
            System.String previewText,
            System.String content,
            System.Int32 previewWordCount,
            System.Int32 wordCount,
            System.Int32 imageCount,
            System.Int32 fileCount,
            System.Int32 videoCount,
            System.DateTime liveDate,
            System.DateTime creationDate)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (previewWordCount == null)
            {
                throw new ArgumentNullException("previewWordCount");
            }

            if (wordCount == null)
            {
                throw new ArgumentNullException("wordCount");
            }

            if (imageCount == null)
            {
                throw new ArgumentNullException("imageCount");
            }

            if (fileCount == null)
            {
                throw new ArgumentNullException("fileCount");
            }

            if (videoCount == null)
            {
                throw new ArgumentNullException("videoCount");
            }

            if (liveDate == null)
            {
                throw new ArgumentNullException("liveDate");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            this.Id = id;
            this.ChannelId = channelId;
            this.Channel = channel;
            this.QueueId = queueId;
            this.Queue = queue;
            this.PreviewImageId = previewImageId;
            this.PreviewImage = previewImage;
            this.PreviewText = previewText;
            this.Content = content;
            this.PreviewWordCount = previewWordCount;
            this.WordCount = wordCount;
            this.ImageCount = imageCount;
            this.FileCount = fileCount;
            this.VideoCount = videoCount;
            this.LiveDate = liveDate;
            this.CreationDate = creationDate;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Comment 
    {
        public Comment(
            System.Guid id,
            System.Guid postId,
            Fifthweek.Api.Persistence.Post post,
            System.Guid userId,
            Fifthweek.Api.Persistence.Identity.FifthweekUser user,
            System.String content,
            System.DateTime creationDate)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            this.Id = id;
            this.PostId = postId;
            this.Post = post;
            this.UserId = userId;
            this.User = user;
            this.Content = content;
            this.CreationDate = creationDate;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Like 
    {
        public Like(
            System.Guid postId,
            Fifthweek.Api.Persistence.Post post,
            System.Guid userId,
            Fifthweek.Api.Persistence.Identity.FifthweekUser user,
            System.DateTime creationDate)
        {
            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (creationDate == null)
            {
                throw new ArgumentNullException("creationDate");
            }

            this.PostId = postId;
            this.Post = post;
            this.UserId = userId;
            this.User = user;
            this.CreationDate = creationDate;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class AppendOnlyLedgerRecord 
    {
        public AppendOnlyLedgerRecord(
            System.Guid id,
            System.Guid accountOwnerId,
            System.Nullable<System.Guid> counterpartyId,
            System.DateTime timestamp,
            System.Decimal amount,
            Fifthweek.Api.Persistence.Payments.LedgerAccountType accountType,
            Fifthweek.Api.Persistence.Payments.LedgerTransactionType transactionType,
            System.Guid transactionReference,
            System.Nullable<System.Guid> inputDataReference,
            System.String comment,
            System.String stripeChargeId,
            System.String taxamoTransactionKey)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (accountOwnerId == null)
            {
                throw new ArgumentNullException("accountOwnerId");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            if (accountType == null)
            {
                throw new ArgumentNullException("accountType");
            }

            if (transactionType == null)
            {
                throw new ArgumentNullException("transactionType");
            }

            if (transactionReference == null)
            {
                throw new ArgumentNullException("transactionReference");
            }

            this.Id = id;
            this.AccountOwnerId = accountOwnerId;
            this.CounterpartyId = counterpartyId;
            this.Timestamp = timestamp;
            this.Amount = amount;
            this.AccountType = accountType;
            this.TransactionType = transactionType;
            this.TransactionReference = transactionReference;
            this.InputDataReference = inputDataReference;
            this.Comment = comment;
            this.StripeChargeId = stripeChargeId;
            this.TaxamoTransactionKey = taxamoTransactionKey;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CalculatedAccountBalance 
    {
        public CalculatedAccountBalance(
            System.Guid userId,
            Fifthweek.Api.Persistence.Payments.LedgerAccountType accountType,
            System.DateTime timestamp,
            System.Decimal amount)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (accountType == null)
            {
                throw new ArgumentNullException("accountType");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            this.UserId = userId;
            this.AccountType = accountType;
            this.Timestamp = timestamp;
            this.Amount = amount;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CreatorPercentageOverride 
    {
        public CreatorPercentageOverride(
            System.Guid userId,
            System.Decimal percentage,
            System.Nullable<System.DateTime> expiryDate)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (percentage == null)
            {
                throw new ArgumentNullException("percentage");
            }

            this.UserId = userId;
            this.Percentage = percentage;
            this.ExpiryDate = expiryDate;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UncommittedSubscriptionPayment 
    {
        public UncommittedSubscriptionPayment(
            System.Guid subscriberId,
            System.Guid creatorId,
            System.DateTime startTimestampInclusive,
            System.DateTime endTimestampExclusive,
            System.Decimal amount,
            System.Guid inputDataReference)
        {
            if (subscriberId == null)
            {
                throw new ArgumentNullException("subscriberId");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            if (startTimestampInclusive == null)
            {
                throw new ArgumentNullException("startTimestampInclusive");
            }

            if (endTimestampExclusive == null)
            {
                throw new ArgumentNullException("endTimestampExclusive");
            }

            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            if (inputDataReference == null)
            {
                throw new ArgumentNullException("inputDataReference");
            }

            this.SubscriberId = subscriberId;
            this.CreatorId = creatorId;
            this.StartTimestampInclusive = startTimestampInclusive;
            this.EndTimestampExclusive = endTimestampExclusive;
            this.Amount = amount;
            this.InputDataReference = inputDataReference;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UserPaymentOrigin 
    {
        public UserPaymentOrigin(
            System.Guid userId,
            Fifthweek.Api.Persistence.Identity.FifthweekUser user,
            System.String paymentOriginKey,
            Fifthweek.Api.Persistence.Payments.PaymentOriginKeyType paymentOriginKeyType,
            System.String countryCode,
            System.String creditCardPrefix,
            System.String ipAddress,
            System.String originalTaxamoTransactionKey,
            Fifthweek.Api.Persistence.Payments.PaymentStatus paymentStatus)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (paymentStatus == null)
            {
                throw new ArgumentNullException("paymentStatus");
            }

            this.UserId = userId;
            this.User = user;
            this.PaymentOriginKey = paymentOriginKey;
            this.PaymentOriginKeyType = paymentOriginKeyType;
            this.CountryCode = countryCode;
            this.CreditCardPrefix = creditCardPrefix;
            this.IpAddress = ipAddress;
            this.OriginalTaxamoTransactionKey = originalTaxamoTransactionKey;
            this.PaymentStatus = paymentStatus;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class PostFile 
    {
        public PostFile(
            System.Guid postId,
            Fifthweek.Api.Persistence.Post post,
            System.Guid fileId,
            Fifthweek.Api.Persistence.File file)
        {
            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (fileId == null)
            {
                throw new ArgumentNullException("fileId");
            }

            this.PostId = postId;
            this.Post = post;
            this.FileId = fileId;
            this.File = file;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class RefreshToken 
    {
        public RefreshToken(
            System.String username,
            System.String clientId,
            System.String encryptedId,
            System.DateTime issuedDate,
            System.DateTime expiresDate,
            System.String protectedTicket)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            if (clientId == null)
            {
                throw new ArgumentNullException("clientId");
            }

            if (encryptedId == null)
            {
                throw new ArgumentNullException("encryptedId");
            }

            if (issuedDate == null)
            {
                throw new ArgumentNullException("issuedDate");
            }

            if (expiresDate == null)
            {
                throw new ArgumentNullException("expiresDate");
            }

            if (protectedTicket == null)
            {
                throw new ArgumentNullException("protectedTicket");
            }

            this.Username = username;
            this.ClientId = clientId;
            this.EncryptedId = encryptedId;
            this.IssuedDate = issuedDate;
            this.ExpiresDate = expiresDate;
            this.ProtectedTicket = protectedTicket;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshot 
    {
        public CreatorChannelsSnapshot(
            System.Guid id,
            System.DateTime timestamp,
            System.Guid creatorId)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            this.Id = id;
            this.Timestamp = timestamp;
            this.CreatorId = creatorId;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshotItem 
    {
        public CreatorChannelsSnapshotItem(
            System.Guid creatorChannelsSnapshotId,
            Fifthweek.Api.Persistence.Snapshots.CreatorChannelsSnapshot creatorChannelsSnapshot,
            System.Guid channelId,
            System.Int32 price)
        {
            if (creatorChannelsSnapshotId == null)
            {
                throw new ArgumentNullException("creatorChannelsSnapshotId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (price == null)
            {
                throw new ArgumentNullException("price");
            }

            this.CreatorChannelsSnapshotId = creatorChannelsSnapshotId;
            this.CreatorChannelsSnapshot = creatorChannelsSnapshot;
            this.ChannelId = channelId;
            this.Price = price;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshot 
    {
        public CreatorFreeAccessUsersSnapshot(
            System.Guid id,
            System.DateTime timestamp,
            System.Guid creatorId)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            this.Id = id;
            this.Timestamp = timestamp;
            this.CreatorId = creatorId;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshotItem 
    {
        public CreatorFreeAccessUsersSnapshotItem(
            System.Guid creatorFreeAccessUsersSnapshotId,
            Fifthweek.Api.Persistence.Snapshots.CreatorFreeAccessUsersSnapshot creatorFreeAccessUsersSnapshot,
            System.String email)
        {
            if (creatorFreeAccessUsersSnapshotId == null)
            {
                throw new ArgumentNullException("creatorFreeAccessUsersSnapshotId");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            this.CreatorFreeAccessUsersSnapshotId = creatorFreeAccessUsersSnapshotId;
            this.CreatorFreeAccessUsersSnapshot = creatorFreeAccessUsersSnapshot;
            this.Email = email;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshot 
    {
        public SubscriberChannelsSnapshot(
            System.Guid id,
            System.DateTime timestamp,
            System.Guid subscriberId)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (subscriberId == null)
            {
                throw new ArgumentNullException("subscriberId");
            }

            this.Id = id;
            this.Timestamp = timestamp;
            this.SubscriberId = subscriberId;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshotItem 
    {
        public SubscriberChannelsSnapshotItem(
            System.Guid subscriberChannelsSnapshotId,
            Fifthweek.Api.Persistence.Snapshots.SubscriberChannelsSnapshot subscriberChannelsSnapshot,
            System.Guid channelId,
            System.Guid creatorId,
            System.Int32 acceptedPrice,
            System.DateTime subscriptionStartDate)
        {
            if (subscriberChannelsSnapshotId == null)
            {
                throw new ArgumentNullException("subscriberChannelsSnapshotId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            if (acceptedPrice == null)
            {
                throw new ArgumentNullException("acceptedPrice");
            }

            if (subscriptionStartDate == null)
            {
                throw new ArgumentNullException("subscriptionStartDate");
            }

            this.SubscriberChannelsSnapshotId = subscriberChannelsSnapshotId;
            this.SubscriberChannelsSnapshot = subscriberChannelsSnapshot;
            this.ChannelId = channelId;
            this.CreatorId = creatorId;
            this.AcceptedPrice = acceptedPrice;
            this.SubscriptionStartDate = subscriptionStartDate;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberSnapshot 
    {
        public SubscriberSnapshot(
            System.DateTime timestamp,
            System.Guid subscriberId,
            System.String email)
        {
            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (subscriberId == null)
            {
                throw new ArgumentNullException("subscriberId");
            }

            this.Timestamp = timestamp;
            this.SubscriberId = subscriberId;
            this.Email = email;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class WeeklyReleaseTime 
    {
        public WeeklyReleaseTime(
            System.Guid queueId,
            Fifthweek.Api.Persistence.Queue queue,
            System.Byte hourOfWeek)
        {
            if (queueId == null)
            {
                throw new ArgumentNullException("queueId");
            }

            if (hourOfWeek == null)
            {
                throw new ArgumentNullException("hourOfWeek");
            }

            this.QueueId = queueId;
            this.Queue = queue;
            this.HourOfWeek = hourOfWeek;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreePost 
    {
        public FreePost(
            System.Guid userId,
            System.Guid postId,
            Fifthweek.Api.Persistence.Post post,
            System.DateTime timestamp)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            this.UserId = userId;
            this.PostId = postId;
            this.Post = post;
            this.Timestamp = timestamp;
        }
    }
}

namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class Blog 
    {
        public override string ToString()
        {
            return string.Format("Blog({0}, {1}, \"{2}\", \"{3}\", \"{4}\", \"{5}\", {6}, {7})", this.Id == null ? "null" : this.Id.ToString(), this.CreatorId == null ? "null" : this.CreatorId.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.Introduction == null ? "null" : this.Introduction.ToString(), this.Description == null ? "null" : this.Description.ToString(), this.ExternalVideoUrl == null ? "null" : this.ExternalVideoUrl.ToString(), this.HeaderImageFileId == null ? "null" : this.HeaderImageFileId.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString());
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
        
            return this.Equals((Blog)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreatorId != null ? this.CreatorId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Introduction != null ? this.Introduction.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Description != null ? this.Description.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ExternalVideoUrl != null ? this.ExternalVideoUrl.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.HeaderImageFileId != null ? this.HeaderImageFileId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Blog other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
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
        
            if (!object.Equals(this.ExternalVideoUrl, other.ExternalVideoUrl))
            {
                return false;
            }
        
            if (!object.Equals(this.HeaderImageFileId, other.HeaderImageFileId))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using Fifthweek.Api.Persistence.Identity;

    public partial class Channel 
    {
        public override string ToString()
        {
            return string.Format("Channel({0}, {1}, \"{2}\", {3}, {4}, {5}, {6}, {7})", this.Id == null ? "null" : this.Id.ToString(), this.BlogId == null ? "null" : this.BlogId.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.Price == null ? "null" : this.Price.ToString(), this.IsVisibleToNonSubscribers == null ? "null" : this.IsVisibleToNonSubscribers.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString(), this.PriceLastSetDate == null ? "null" : this.PriceLastSetDate.ToString(), this.IsDiscoverable == null ? "null" : this.IsDiscoverable.ToString());
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
        
            return this.Equals((Channel)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BlogId != null ? this.BlogId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Price != null ? this.Price.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IsVisibleToNonSubscribers != null ? this.IsVisibleToNonSubscribers.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PriceLastSetDate != null ? this.PriceLastSetDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IsDiscoverable != null ? this.IsDiscoverable.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Channel other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.BlogId, other.BlogId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (!object.Equals(this.Price, other.Price))
            {
                return false;
            }
        
            if (!object.Equals(this.IsVisibleToNonSubscribers, other.IsVisibleToNonSubscribers))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            if (!object.Equals(this.PriceLastSetDate, other.PriceLastSetDate))
            {
                return false;
            }
        
            if (!object.Equals(this.IsDiscoverable, other.IsDiscoverable))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class ChannelSubscription 
    {
        public override string ToString()
        {
            return string.Format("ChannelSubscription({0}, {1}, {2}, {3}, {4})", this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.AcceptedPrice == null ? "null" : this.AcceptedPrice.ToString(), this.PriceLastAcceptedDate == null ? "null" : this.PriceLastAcceptedDate.ToString(), this.SubscriptionStartDate == null ? "null" : this.SubscriptionStartDate.ToString());
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
        
            return this.Equals((ChannelSubscription)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AcceptedPrice != null ? this.AcceptedPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PriceLastAcceptedDate != null ? this.PriceLastAcceptedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionStartDate != null ? this.SubscriptionStartDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ChannelSubscription other)
        {
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.AcceptedPrice, other.AcceptedPrice))
            {
                return false;
            }
        
            if (!object.Equals(this.PriceLastAcceptedDate, other.PriceLastAcceptedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.SubscriptionStartDate, other.SubscriptionStartDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Queue 
    {
        public override string ToString()
        {
            return string.Format("Queue({0}, {1}, \"{2}\", {3})", this.Id == null ? "null" : this.Id.ToString(), this.BlogId == null ? "null" : this.BlogId.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString());
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
        
            return this.Equals((Queue)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BlogId != null ? this.BlogId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Queue other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.BlogId, other.BlogId))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class EndToEndTestEmail 
    {
        public override string ToString()
        {
            return string.Format("EndToEndTestEmail(\"{0}\", \"{1}\", \"{2}\", {3})", this.Mailbox == null ? "null" : this.Mailbox.ToString(), this.Subject == null ? "null" : this.Subject.ToString(), this.Body == null ? "null" : this.Body.ToString(), this.DateReceived == null ? "null" : this.DateReceived.ToString());
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
        
            return this.Equals((EndToEndTestEmail)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Mailbox != null ? this.Mailbox.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Subject != null ? this.Subject.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Body != null ? this.Body.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.DateReceived != null ? this.DateReceived.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(EndToEndTestEmail other)
        {
            if (!object.Equals(this.Mailbox, other.Mailbox))
            {
                return false;
            }
        
            if (!object.Equals(this.Subject, other.Subject))
            {
                return false;
            }
        
            if (!object.Equals(this.Body, other.Body))
            {
                return false;
            }
        
            if (!object.Equals(this.DateReceived, other.DateReceived))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class File 
    {
        public override string ToString()
        {
            return string.Format("File({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, \"{9}\", \"{10}\", {11}, \"{12}\", {13}, {14})", this.Id == null ? "null" : this.Id.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.State == null ? "null" : this.State.ToString(), this.UploadStartedDate == null ? "null" : this.UploadStartedDate.ToString(), this.UploadCompletedDate == null ? "null" : this.UploadCompletedDate.ToString(), this.ProcessingStartedDate == null ? "null" : this.ProcessingStartedDate.ToString(), this.ProcessingCompletedDate == null ? "null" : this.ProcessingCompletedDate.ToString(), this.ProcessingAttempts == null ? "null" : this.ProcessingAttempts.ToString(), this.FileNameWithoutExtension == null ? "null" : this.FileNameWithoutExtension.ToString(), this.FileExtension == null ? "null" : this.FileExtension.ToString(), this.BlobSizeBytes == null ? "null" : this.BlobSizeBytes.ToString(), this.Purpose == null ? "null" : this.Purpose.ToString(), this.RenderWidth == null ? "null" : this.RenderWidth.ToString(), this.RenderHeight == null ? "null" : this.RenderHeight.ToString());
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
        
            return this.Equals((File)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.State != null ? this.State.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UploadStartedDate != null ? this.UploadStartedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UploadCompletedDate != null ? this.UploadCompletedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ProcessingStartedDate != null ? this.ProcessingStartedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ProcessingCompletedDate != null ? this.ProcessingCompletedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ProcessingAttempts != null ? this.ProcessingAttempts.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.FileNameWithoutExtension != null ? this.FileNameWithoutExtension.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.FileExtension != null ? this.FileExtension.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.BlobSizeBytes != null ? this.BlobSizeBytes.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Purpose != null ? this.Purpose.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.RenderWidth != null ? this.RenderWidth.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.RenderHeight != null ? this.RenderHeight.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(File other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.State, other.State))
            {
                return false;
            }
        
            if (!object.Equals(this.UploadStartedDate, other.UploadStartedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.UploadCompletedDate, other.UploadCompletedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ProcessingStartedDate, other.ProcessingStartedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ProcessingCompletedDate, other.ProcessingCompletedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ProcessingAttempts, other.ProcessingAttempts))
            {
                return false;
            }
        
            if (!object.Equals(this.FileNameWithoutExtension, other.FileNameWithoutExtension))
            {
                return false;
            }
        
            if (!object.Equals(this.FileExtension, other.FileExtension))
            {
                return false;
            }
        
            if (!object.Equals(this.BlobSizeBytes, other.BlobSizeBytes))
            {
                return false;
            }
        
            if (!object.Equals(this.Purpose, other.Purpose))
            {
                return false;
            }
        
            if (!object.Equals(this.RenderWidth, other.RenderWidth))
            {
                return false;
            }
        
            if (!object.Equals(this.RenderHeight, other.RenderHeight))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreeAccessUser 
    {
        public override string ToString()
        {
            return string.Format("FreeAccessUser({0}, \"{1}\")", this.BlogId == null ? "null" : this.BlogId.ToString(), this.Email == null ? "null" : this.Email.ToString());
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
        
            return this.Equals((FreeAccessUser)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.BlogId != null ? this.BlogId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Email != null ? this.Email.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(FreeAccessUser other)
        {
            if (!object.Equals(this.BlogId, other.BlogId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Post 
    {
        public override string ToString()
        {
            return string.Format("Post({0}, {1}, {2}, {3}, \"{4}\", \"{5}\", {6}, {7}, {8}, {9}, {10}, {11}, {12})", this.Id == null ? "null" : this.Id.ToString(), this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.QueueId == null ? "null" : this.QueueId.ToString(), this.PreviewImageId == null ? "null" : this.PreviewImageId.ToString(), this.PreviewText == null ? "null" : this.PreviewText.ToString(), this.Content == null ? "null" : this.Content.ToString(), this.PreviewWordCount == null ? "null" : this.PreviewWordCount.ToString(), this.WordCount == null ? "null" : this.WordCount.ToString(), this.ImageCount == null ? "null" : this.ImageCount.ToString(), this.FileCount == null ? "null" : this.FileCount.ToString(), this.VideoCount == null ? "null" : this.VideoCount.ToString(), this.LiveDate == null ? "null" : this.LiveDate.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString());
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
        
            return this.Equals((Post)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.QueueId != null ? this.QueueId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PreviewImageId != null ? this.PreviewImageId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PreviewText != null ? this.PreviewText.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Content != null ? this.Content.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PreviewWordCount != null ? this.PreviewWordCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.WordCount != null ? this.WordCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ImageCount != null ? this.ImageCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.FileCount != null ? this.FileCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.VideoCount != null ? this.VideoCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.LiveDate != null ? this.LiveDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Post other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.QueueId, other.QueueId))
            {
                return false;
            }
        
            if (!object.Equals(this.PreviewImageId, other.PreviewImageId))
            {
                return false;
            }
        
            if (!object.Equals(this.PreviewText, other.PreviewText))
            {
                return false;
            }
        
            if (!object.Equals(this.Content, other.Content))
            {
                return false;
            }
        
            if (!object.Equals(this.PreviewWordCount, other.PreviewWordCount))
            {
                return false;
            }
        
            if (!object.Equals(this.WordCount, other.WordCount))
            {
                return false;
            }
        
            if (!object.Equals(this.ImageCount, other.ImageCount))
            {
                return false;
            }
        
            if (!object.Equals(this.FileCount, other.FileCount))
            {
                return false;
            }
        
            if (!object.Equals(this.VideoCount, other.VideoCount))
            {
                return false;
            }
        
            if (!object.Equals(this.LiveDate, other.LiveDate))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Comment 
    {
        public override string ToString()
        {
            return string.Format("Comment({0}, {1}, {2}, \"{3}\", {4})", this.Id == null ? "null" : this.Id.ToString(), this.PostId == null ? "null" : this.PostId.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.Content == null ? "null" : this.Content.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString());
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
        
            return this.Equals((Comment)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PostId != null ? this.PostId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Content != null ? this.Content.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Comment other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.Content, other.Content))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Like 
    {
        public override string ToString()
        {
            return string.Format("Like({0}, {1}, {2})", this.PostId == null ? "null" : this.PostId.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.CreationDate == null ? "null" : this.CreationDate.ToString());
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
        
            return this.Equals((Like)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.PostId != null ? this.PostId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreationDate != null ? this.CreationDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Like other)
        {
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.CreationDate, other.CreationDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class AppendOnlyLedgerRecord 
    {
        public override string ToString()
        {
            return string.Format("AppendOnlyLedgerRecord({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, \"{9}\", \"{10}\", \"{11}\")", this.Id == null ? "null" : this.Id.ToString(), this.AccountOwnerId == null ? "null" : this.AccountOwnerId.ToString(), this.CounterpartyId == null ? "null" : this.CounterpartyId.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.Amount == null ? "null" : this.Amount.ToString(), this.AccountType == null ? "null" : this.AccountType.ToString(), this.TransactionType == null ? "null" : this.TransactionType.ToString(), this.TransactionReference == null ? "null" : this.TransactionReference.ToString(), this.InputDataReference == null ? "null" : this.InputDataReference.ToString(), this.Comment == null ? "null" : this.Comment.ToString(), this.StripeChargeId == null ? "null" : this.StripeChargeId.ToString(), this.TaxamoTransactionKey == null ? "null" : this.TaxamoTransactionKey.ToString());
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
        
            return this.Equals((AppendOnlyLedgerRecord)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AccountOwnerId != null ? this.AccountOwnerId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CounterpartyId != null ? this.CounterpartyId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AccountType != null ? this.AccountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TransactionType != null ? this.TransactionType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TransactionReference != null ? this.TransactionReference.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.InputDataReference != null ? this.InputDataReference.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Comment != null ? this.Comment.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.StripeChargeId != null ? this.StripeChargeId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaxamoTransactionKey != null ? this.TaxamoTransactionKey.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(AppendOnlyLedgerRecord other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.AccountOwnerId, other.AccountOwnerId))
            {
                return false;
            }
        
            if (!object.Equals(this.CounterpartyId, other.CounterpartyId))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            if (!object.Equals(this.AccountType, other.AccountType))
            {
                return false;
            }
        
            if (!object.Equals(this.TransactionType, other.TransactionType))
            {
                return false;
            }
        
            if (!object.Equals(this.TransactionReference, other.TransactionReference))
            {
                return false;
            }
        
            if (!object.Equals(this.InputDataReference, other.InputDataReference))
            {
                return false;
            }
        
            if (!object.Equals(this.Comment, other.Comment))
            {
                return false;
            }
        
            if (!object.Equals(this.StripeChargeId, other.StripeChargeId))
            {
                return false;
            }
        
            if (!object.Equals(this.TaxamoTransactionKey, other.TaxamoTransactionKey))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CalculatedAccountBalance 
    {
        public override string ToString()
        {
            return string.Format("CalculatedAccountBalance({0}, {1}, {2}, {3})", this.UserId == null ? "null" : this.UserId.ToString(), this.AccountType == null ? "null" : this.AccountType.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.Amount == null ? "null" : this.Amount.ToString());
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
        
            return this.Equals((CalculatedAccountBalance)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AccountType != null ? this.AccountType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CalculatedAccountBalance other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.AccountType, other.AccountType))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CreatorPercentageOverride 
    {
        public override string ToString()
        {
            return string.Format("CreatorPercentageOverride({0}, {1}, {2})", this.UserId == null ? "null" : this.UserId.ToString(), this.Percentage == null ? "null" : this.Percentage.ToString(), this.ExpiryDate == null ? "null" : this.ExpiryDate.ToString());
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
        
            return this.Equals((CreatorPercentageOverride)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Percentage != null ? this.Percentage.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ExpiryDate != null ? this.ExpiryDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreatorPercentageOverride other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.Percentage, other.Percentage))
            {
                return false;
            }
        
            if (!object.Equals(this.ExpiryDate, other.ExpiryDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UncommittedSubscriptionPayment 
    {
        public override string ToString()
        {
            return string.Format("UncommittedSubscriptionPayment({0}, {1}, {2}, {3}, {4}, {5})", this.SubscriberId == null ? "null" : this.SubscriberId.ToString(), this.CreatorId == null ? "null" : this.CreatorId.ToString(), this.StartTimestampInclusive == null ? "null" : this.StartTimestampInclusive.ToString(), this.EndTimestampExclusive == null ? "null" : this.EndTimestampExclusive.ToString(), this.Amount == null ? "null" : this.Amount.ToString(), this.InputDataReference == null ? "null" : this.InputDataReference.ToString());
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
        
            return this.Equals((UncommittedSubscriptionPayment)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SubscriberId != null ? this.SubscriberId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreatorId != null ? this.CreatorId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.StartTimestampInclusive != null ? this.StartTimestampInclusive.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.EndTimestampExclusive != null ? this.EndTimestampExclusive.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.InputDataReference != null ? this.InputDataReference.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(UncommittedSubscriptionPayment other)
        {
            if (!object.Equals(this.SubscriberId, other.SubscriberId))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            if (!object.Equals(this.StartTimestampInclusive, other.StartTimestampInclusive))
            {
                return false;
            }
        
            if (!object.Equals(this.EndTimestampExclusive, other.EndTimestampExclusive))
            {
                return false;
            }
        
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            if (!object.Equals(this.InputDataReference, other.InputDataReference))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UserPaymentOrigin 
    {
        public override string ToString()
        {
            return string.Format("UserPaymentOrigin({0}, \"{1}\", {2}, \"{3}\", \"{4}\", \"{5}\", \"{6}\", {7})", this.UserId == null ? "null" : this.UserId.ToString(), this.PaymentOriginKey == null ? "null" : this.PaymentOriginKey.ToString(), this.PaymentOriginKeyType == null ? "null" : this.PaymentOriginKeyType.ToString(), this.CountryCode == null ? "null" : this.CountryCode.ToString(), this.CreditCardPrefix == null ? "null" : this.CreditCardPrefix.ToString(), this.IpAddress == null ? "null" : this.IpAddress.ToString(), this.OriginalTaxamoTransactionKey == null ? "null" : this.OriginalTaxamoTransactionKey.ToString(), this.PaymentStatus == null ? "null" : this.PaymentStatus.ToString());
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
        
            return this.Equals((UserPaymentOrigin)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PaymentOriginKey != null ? this.PaymentOriginKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PaymentOriginKeyType != null ? this.PaymentOriginKeyType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CountryCode != null ? this.CountryCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreditCardPrefix != null ? this.CreditCardPrefix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IpAddress != null ? this.IpAddress.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OriginalTaxamoTransactionKey != null ? this.OriginalTaxamoTransactionKey.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PaymentStatus != null ? this.PaymentStatus.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(UserPaymentOrigin other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.PaymentOriginKey, other.PaymentOriginKey))
            {
                return false;
            }
        
            if (!object.Equals(this.PaymentOriginKeyType, other.PaymentOriginKeyType))
            {
                return false;
            }
        
            if (!object.Equals(this.CountryCode, other.CountryCode))
            {
                return false;
            }
        
            if (!object.Equals(this.CreditCardPrefix, other.CreditCardPrefix))
            {
                return false;
            }
        
            if (!object.Equals(this.IpAddress, other.IpAddress))
            {
                return false;
            }
        
            if (!object.Equals(this.OriginalTaxamoTransactionKey, other.OriginalTaxamoTransactionKey))
            {
                return false;
            }
        
            if (!object.Equals(this.PaymentStatus, other.PaymentStatus))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class PostFile 
    {
        public override string ToString()
        {
            return string.Format("PostFile({0}, {1})", this.PostId == null ? "null" : this.PostId.ToString(), this.FileId == null ? "null" : this.FileId.ToString());
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
        
            return this.Equals((PostFile)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.PostId != null ? this.PostId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.FileId != null ? this.FileId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(PostFile other)
        {
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.FileId, other.FileId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class RefreshToken 
    {
        public override string ToString()
        {
            return string.Format("RefreshToken(\"{0}\", \"{1}\", \"{2}\", {3}, {4}, \"{5}\")", this.Username == null ? "null" : this.Username.ToString(), this.ClientId == null ? "null" : this.ClientId.ToString(), this.EncryptedId == null ? "null" : this.EncryptedId.ToString(), this.IssuedDate == null ? "null" : this.IssuedDate.ToString(), this.ExpiresDate == null ? "null" : this.ExpiresDate.ToString(), this.ProtectedTicket == null ? "null" : this.ProtectedTicket.ToString());
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
        
            return this.Equals((RefreshToken)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Username != null ? this.Username.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ClientId != null ? this.ClientId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.EncryptedId != null ? this.EncryptedId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IssuedDate != null ? this.IssuedDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ExpiresDate != null ? this.ExpiresDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ProtectedTicket != null ? this.ProtectedTicket.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(RefreshToken other)
        {
            if (!object.Equals(this.Username, other.Username))
            {
                return false;
            }
        
            if (!object.Equals(this.ClientId, other.ClientId))
            {
                return false;
            }
        
            if (!object.Equals(this.EncryptedId, other.EncryptedId))
            {
                return false;
            }
        
            if (!object.Equals(this.IssuedDate, other.IssuedDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ExpiresDate, other.ExpiresDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ProtectedTicket, other.ProtectedTicket))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshot 
    {
        public override string ToString()
        {
            return string.Format("CreatorChannelsSnapshot({0}, {1}, {2})", this.Id == null ? "null" : this.Id.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.CreatorId == null ? "null" : this.CreatorId.ToString());
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
        
            return this.Equals((CreatorChannelsSnapshot)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreatorId != null ? this.CreatorId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreatorChannelsSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshotItem 
    {
        public override string ToString()
        {
            return string.Format("CreatorChannelsSnapshotItem({0}, {1}, {2})", this.CreatorChannelsSnapshotId == null ? "null" : this.CreatorChannelsSnapshotId.ToString(), this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.Price == null ? "null" : this.Price.ToString());
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
        
            return this.Equals((CreatorChannelsSnapshotItem)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.CreatorChannelsSnapshotId != null ? this.CreatorChannelsSnapshotId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Price != null ? this.Price.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreatorChannelsSnapshotItem other)
        {
            if (!object.Equals(this.CreatorChannelsSnapshotId, other.CreatorChannelsSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.Price, other.Price))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshot 
    {
        public override string ToString()
        {
            return string.Format("CreatorFreeAccessUsersSnapshot({0}, {1}, {2})", this.Id == null ? "null" : this.Id.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.CreatorId == null ? "null" : this.CreatorId.ToString());
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
        
            return this.Equals((CreatorFreeAccessUsersSnapshot)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreatorId != null ? this.CreatorId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreatorFreeAccessUsersSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshotItem 
    {
        public override string ToString()
        {
            return string.Format("CreatorFreeAccessUsersSnapshotItem({0}, \"{1}\")", this.CreatorFreeAccessUsersSnapshotId == null ? "null" : this.CreatorFreeAccessUsersSnapshotId.ToString(), this.Email == null ? "null" : this.Email.ToString());
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
        
            return this.Equals((CreatorFreeAccessUsersSnapshotItem)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.CreatorFreeAccessUsersSnapshotId != null ? this.CreatorFreeAccessUsersSnapshotId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Email != null ? this.Email.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreatorFreeAccessUsersSnapshotItem other)
        {
            if (!object.Equals(this.CreatorFreeAccessUsersSnapshotId, other.CreatorFreeAccessUsersSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshot 
    {
        public override string ToString()
        {
            return string.Format("SubscriberChannelsSnapshot({0}, {1}, {2})", this.Id == null ? "null" : this.Id.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.SubscriberId == null ? "null" : this.SubscriberId.ToString());
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
        
            return this.Equals((SubscriberChannelsSnapshot)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriberId != null ? this.SubscriberId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(SubscriberChannelsSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.SubscriberId, other.SubscriberId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshotItem 
    {
        public override string ToString()
        {
            return string.Format("SubscriberChannelsSnapshotItem({0}, {1}, {2}, {3}, {4})", this.SubscriberChannelsSnapshotId == null ? "null" : this.SubscriberChannelsSnapshotId.ToString(), this.ChannelId == null ? "null" : this.ChannelId.ToString(), this.CreatorId == null ? "null" : this.CreatorId.ToString(), this.AcceptedPrice == null ? "null" : this.AcceptedPrice.ToString(), this.SubscriptionStartDate == null ? "null" : this.SubscriptionStartDate.ToString());
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
        
            return this.Equals((SubscriberChannelsSnapshotItem)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SubscriberChannelsSnapshotId != null ? this.SubscriberChannelsSnapshotId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ChannelId != null ? this.ChannelId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreatorId != null ? this.CreatorId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AcceptedPrice != null ? this.AcceptedPrice.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriptionStartDate != null ? this.SubscriptionStartDate.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(SubscriberChannelsSnapshotItem other)
        {
            if (!object.Equals(this.SubscriberChannelsSnapshotId, other.SubscriberChannelsSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            if (!object.Equals(this.AcceptedPrice, other.AcceptedPrice))
            {
                return false;
            }
        
            if (!object.Equals(this.SubscriptionStartDate, other.SubscriptionStartDate))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberSnapshot 
    {
        public override string ToString()
        {
            return string.Format("SubscriberSnapshot({0}, {1}, \"{2}\")", this.Timestamp == null ? "null" : this.Timestamp.ToString(), this.SubscriberId == null ? "null" : this.SubscriberId.ToString(), this.Email == null ? "null" : this.Email.ToString());
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
        
            return this.Equals((SubscriberSnapshot)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SubscriberId != null ? this.SubscriberId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Email != null ? this.Email.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(SubscriberSnapshot other)
        {
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.SubscriberId, other.SubscriberId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class WeeklyReleaseTime 
    {
        public override string ToString()
        {
            return string.Format("WeeklyReleaseTime({0}, {1})", this.QueueId == null ? "null" : this.QueueId.ToString(), this.HourOfWeek == null ? "null" : this.HourOfWeek.ToString());
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
        
            return this.Equals((WeeklyReleaseTime)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.QueueId != null ? this.QueueId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.HourOfWeek != null ? this.HourOfWeek.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(WeeklyReleaseTime other)
        {
            if (!object.Equals(this.QueueId, other.QueueId))
            {
                return false;
            }
        
            if (!object.Equals(this.HourOfWeek, other.HourOfWeek))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreePost 
    {
        public override string ToString()
        {
            return string.Format("FreePost({0}, {1}, {2})", this.UserId == null ? "null" : this.UserId.ToString(), this.PostId == null ? "null" : this.PostId.ToString(), this.Timestamp == null ? "null" : this.Timestamp.ToString());
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
        
            return this.Equals((FreePost)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PostId != null ? this.PostId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Timestamp != null ? this.Timestamp.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(FreePost other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekRole 
    {
        public override string ToString()
        {
            return string.Format("FifthweekRole({0}, \"{1}\")", this.Id == null ? "null" : this.Id.ToString(), this.Name == null ? "null" : this.Name.ToString());
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
        
            return this.Equals((FifthweekRole)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(FifthweekRole other)
        {
            if (!object.Equals(this.Id, other.Id))
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
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekUser 
    {
        public override string ToString()
        {
            return string.Format("FifthweekUser(\"{0}\", {1}, {2}, {3}, {4}, \"{5}\", \"{6}\", {7}, {8}, {9}, {10}, {11}, \"{12}\", \"{13}\", {14}, \"{15}\", {16}, \"{17}\")", this.ExampleWork == null ? "null" : this.ExampleWork.ToString(), this.RegistrationDate == null ? "null" : this.RegistrationDate.ToString(), this.LastSignInDate == null ? "null" : this.LastSignInDate.ToString(), this.LastAccessTokenDate == null ? "null" : this.LastAccessTokenDate.ToString(), this.ProfileImageFileId == null ? "null" : this.ProfileImageFileId.ToString(), this.Email == null ? "null" : this.Email.ToString(), this.Name == null ? "null" : this.Name.ToString(), this.Id == null ? "null" : this.Id.ToString(), this.AccessFailedCount == null ? "null" : this.AccessFailedCount.ToString(), this.EmailConfirmed == null ? "null" : this.EmailConfirmed.ToString(), this.LockoutEnabled == null ? "null" : this.LockoutEnabled.ToString(), this.LockoutEndDateUtc == null ? "null" : this.LockoutEndDateUtc.ToString(), this.PasswordHash == null ? "null" : this.PasswordHash.ToString(), this.PhoneNumber == null ? "null" : this.PhoneNumber.ToString(), this.PhoneNumberConfirmed == null ? "null" : this.PhoneNumberConfirmed.ToString(), this.SecurityStamp == null ? "null" : this.SecurityStamp.ToString(), this.TwoFactorEnabled == null ? "null" : this.TwoFactorEnabled.ToString(), this.UserName == null ? "null" : this.UserName.ToString());
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
        
            return this.Equals((FifthweekUser)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.ExampleWork != null ? this.ExampleWork.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.RegistrationDate != null ? this.RegistrationDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.LastSignInDate != null ? this.LastSignInDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.LastAccessTokenDate != null ? this.LastAccessTokenDate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ProfileImageFileId != null ? this.ProfileImageFileId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Email != null ? this.Email.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Id != null ? this.Id.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.AccessFailedCount != null ? this.AccessFailedCount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.EmailConfirmed != null ? this.EmailConfirmed.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.LockoutEnabled != null ? this.LockoutEnabled.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.LockoutEndDateUtc != null ? this.LockoutEndDateUtc.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PasswordHash != null ? this.PasswordHash.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PhoneNumber != null ? this.PhoneNumber.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.PhoneNumberConfirmed != null ? this.PhoneNumberConfirmed.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SecurityStamp != null ? this.SecurityStamp.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TwoFactorEnabled != null ? this.TwoFactorEnabled.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserName != null ? this.UserName.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(FifthweekUser other)
        {
            if (!object.Equals(this.ExampleWork, other.ExampleWork))
            {
                return false;
            }
        
            if (!object.Equals(this.RegistrationDate, other.RegistrationDate))
            {
                return false;
            }
        
            if (!object.Equals(this.LastSignInDate, other.LastSignInDate))
            {
                return false;
            }
        
            if (!object.Equals(this.LastAccessTokenDate, other.LastAccessTokenDate))
            {
                return false;
            }
        
            if (!object.Equals(this.ProfileImageFileId, other.ProfileImageFileId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }
        
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            if (!object.Equals(this.AccessFailedCount, other.AccessFailedCount))
            {
                return false;
            }
        
            if (!object.Equals(this.EmailConfirmed, other.EmailConfirmed))
            {
                return false;
            }
        
            if (!object.Equals(this.LockoutEnabled, other.LockoutEnabled))
            {
                return false;
            }
        
            if (!object.Equals(this.LockoutEndDateUtc, other.LockoutEndDateUtc))
            {
                return false;
            }
        
            if (!object.Equals(this.PasswordHash, other.PasswordHash))
            {
                return false;
            }
        
            if (!object.Equals(this.PhoneNumber, other.PhoneNumber))
            {
                return false;
            }
        
            if (!object.Equals(this.PhoneNumberConfirmed, other.PhoneNumberConfirmed))
            {
                return false;
            }
        
            if (!object.Equals(this.SecurityStamp, other.SecurityStamp))
            {
                return false;
            }
        
            if (!object.Equals(this.TwoFactorEnabled, other.TwoFactorEnabled))
            {
                return false;
            }
        
            if (!object.Equals(this.UserName, other.UserName))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekUserRole 
    {
        public override string ToString()
        {
            return string.Format("FifthweekUserRole({0}, {1})", this.RoleId == null ? "null" : this.RoleId.ToString(), this.UserId == null ? "null" : this.UserId.ToString());
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
        
            return this.Equals((FifthweekUserRole)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.RoleId != null ? this.RoleId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(FifthweekUserRole other)
        {
            if (!object.Equals(this.RoleId, other.RoleId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Queue 
    {
        public Queue Copy()
        {
            var copy = new Queue();
            copy.Id = this.Id;
            copy.BlogId = this.BlogId;
            copy.Blog = this.Blog;
            copy.Name = this.Name;
            copy.CreationDate = this.CreationDate;
            return copy;
        }
        
        public Queue Copy(Action<Queue> applyDelta)
        {
            var copy = this.Copy();
            applyDelta(copy);
            return copy;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Post 
    {
        public Post Copy()
        {
            var copy = new Post();
            copy.Id = this.Id;
            copy.ChannelId = this.ChannelId;
            copy.Channel = this.Channel;
            copy.QueueId = this.QueueId;
            copy.Queue = this.Queue;
            copy.PreviewImageId = this.PreviewImageId;
            copy.PreviewImage = this.PreviewImage;
            copy.PreviewText = this.PreviewText;
            copy.Content = this.Content;
            copy.PreviewWordCount = this.PreviewWordCount;
            copy.WordCount = this.WordCount;
            copy.ImageCount = this.ImageCount;
            copy.FileCount = this.FileCount;
            copy.VideoCount = this.VideoCount;
            copy.LiveDate = this.LiveDate;
            copy.CreationDate = this.CreationDate;
            return copy;
        }
        
        public Post Copy(Action<Post> applyDelta)
        {
            var copy = this.Copy();
            applyDelta(copy);
            return copy;
        }
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class PostFile 
    {
        public PostFile Copy()
        {
            var copy = new PostFile();
            copy.PostId = this.PostId;
            copy.Post = this.Post;
            copy.FileId = this.FileId;
            copy.File = this.File;
            return copy;
        }
        
        public PostFile Copy(Action<PostFile> applyDelta)
        {
            var copy = this.Copy();
            applyDelta(copy);
            return copy;
        }
    }
}

namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class Blog  : IIdentityEquatable
    {
        public const string Table = "Blogs";
        
        public Blog(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Blog)other);
        }
        
        protected bool IdentityEquals(Blog other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            CreatorId = 2, 
            Name = 4, 
            Introduction = 8, 
            Description = 16, 
            ExternalVideoUrl = 32, 
            HeaderImageFileId = 64, 
            CreationDate = 128
        }
    }

    public static partial class BlogExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Blog> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.CreatorId, entity.Name, entity.Introduction, entity.Description, entity.ExternalVideoUrl, entity.HeaderImageFileId, entity.CreationDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Blog entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.CreatorId, entity.Name, entity.Introduction, entity.Description, entity.ExternalVideoUrl, entity.HeaderImageFileId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Blog, Blog.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.CreatorId, entity.Name, entity.Introduction, entity.Description, entity.ExternalVideoUrl, entity.HeaderImageFileId, entity.CreationDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Blog entity, 
            Blog.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Blog.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.CreatorId, entity.Name, entity.Introduction, entity.Description, entity.ExternalVideoUrl, entity.HeaderImageFileId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Blog entity, 
            Blog.Fields mergeOnFields,
            Blog.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.CreatorId, entity.Name, entity.Introduction, entity.Description, entity.ExternalVideoUrl, entity.HeaderImageFileId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Blog entity, 
            Blog.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Blog, Blog.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Blogs(Id, CreatorId, Name, Introduction, Description, ExternalVideoUrl, HeaderImageFileId, CreationDate) VALUES(@Id, @CreatorId, @Name, @Introduction, @Description, @ExternalVideoUrl, @HeaderImageFileId, @CreationDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Blog.Fields mergeOnFields, Blog.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Blogs WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @CreatorId, @Name, @Introduction, @Description, @ExternalVideoUrl, @HeaderImageFileId, @CreationDate)) AS Source (Id, CreatorId, Name, Introduction, Description, ExternalVideoUrl, HeaderImageFileId, CreationDate)
                ON    (");
                
            if (mergeOnFields == Blog.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, CreatorId, Name, Introduction, Description, ExternalVideoUrl, HeaderImageFileId, CreationDate)
                    VALUES  (Source.Id, Source.CreatorId, Source.Name, Source.Introduction, Source.Description, Source.ExternalVideoUrl, Source.HeaderImageFileId, Source.CreationDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Blog.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Blogs SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Blog.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(Blog.Fields.CreatorId))
            {
                fieldNames.Add("CreatorId");
            }
        
            if (fields.HasFlag(Blog.Fields.Name))
            {
                fieldNames.Add("Name");
            }
        
            if (fields.HasFlag(Blog.Fields.Introduction))
            {
                fieldNames.Add("Introduction");
            }
        
            if (fields.HasFlag(Blog.Fields.Description))
            {
                fieldNames.Add("Description");
            }
        
            if (fields.HasFlag(Blog.Fields.ExternalVideoUrl))
            {
                fieldNames.Add("ExternalVideoUrl");
            }
        
            if (fields.HasFlag(Blog.Fields.HeaderImageFileId))
            {
                fieldNames.Add("HeaderImageFileId");
            }
        
            if (fields.HasFlag(Blog.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Blog entity, 
            Blog.Fields fields,
            Blog.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(Blog.Fields.CreatorId) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.CreatorId)))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            if (fields.HasFlag(Blog.Fields.Name) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.Name)))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (fields.HasFlag(Blog.Fields.Introduction) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.Introduction)))
            {
                parameters.Add("Introduction", entity.Introduction);
            }
        
            if (fields.HasFlag(Blog.Fields.Description) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.Description)))
            {
                parameters.Add("Description", entity.Description);
            }
        
            if (fields.HasFlag(Blog.Fields.ExternalVideoUrl) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.ExternalVideoUrl)))
            {
                parameters.Add("ExternalVideoUrl", entity.ExternalVideoUrl);
            }
        
            if (fields.HasFlag(Blog.Fields.HeaderImageFileId) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.HeaderImageFileId)))
            {
                parameters.Add("HeaderImageFileId", entity.HeaderImageFileId);
            }
        
            if (fields.HasFlag(Blog.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Blog.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Blog entity, 
            Blog.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(Blog.Fields.CreatorId))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            if (!fields.HasFlag(Blog.Fields.Name))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (!fields.HasFlag(Blog.Fields.Introduction))
            {
                parameters.Add("Introduction", entity.Introduction);
            }
        
            if (!fields.HasFlag(Blog.Fields.Description))
            {
                parameters.Add("Description", entity.Description);
            }
        
            if (!fields.HasFlag(Blog.Fields.ExternalVideoUrl))
            {
                parameters.Add("ExternalVideoUrl", entity.ExternalVideoUrl);
            }
        
            if (!fields.HasFlag(Blog.Fields.HeaderImageFileId))
            {
                parameters.Add("HeaderImageFileId", entity.HeaderImageFileId);
            }
        
            if (!fields.HasFlag(Blog.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using Fifthweek.Api.Persistence.Identity;

    public partial class Channel  : IIdentityEquatable
    {
        public const string Table = "Channels";
        
        public Channel(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Channel)other);
        }
        
        protected bool IdentityEquals(Channel other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            BlogId = 2, 
            Name = 4, 
            Price = 8, 
            IsVisibleToNonSubscribers = 16, 
            CreationDate = 32, 
            PriceLastSetDate = 64, 
            IsDiscoverable = 128
        }
    }

    public static partial class ChannelExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Channel> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.Price, entity.IsVisibleToNonSubscribers, entity.CreationDate, entity.PriceLastSetDate, entity.IsDiscoverable
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Channel entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.Price, entity.IsVisibleToNonSubscribers, entity.CreationDate, entity.PriceLastSetDate, entity.IsDiscoverable
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Channel, Channel.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.BlogId, entity.Name, entity.Price, entity.IsVisibleToNonSubscribers, entity.CreationDate, entity.PriceLastSetDate, entity.IsDiscoverable });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Channel entity, 
            Channel.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Channel.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.Price, entity.IsVisibleToNonSubscribers, entity.CreationDate, entity.PriceLastSetDate, entity.IsDiscoverable
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Channel entity, 
            Channel.Fields mergeOnFields,
            Channel.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.Price, entity.IsVisibleToNonSubscribers, entity.CreationDate, entity.PriceLastSetDate, entity.IsDiscoverable
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Channel entity, 
            Channel.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Channel, Channel.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Channels(Id, BlogId, Name, Price, IsVisibleToNonSubscribers, CreationDate, PriceLastSetDate, IsDiscoverable) VALUES(@Id, @BlogId, @Name, @Price, @IsVisibleToNonSubscribers, @CreationDate, @PriceLastSetDate, @IsDiscoverable)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Channel.Fields mergeOnFields, Channel.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Channels WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @BlogId, @Name, @Price, @IsVisibleToNonSubscribers, @CreationDate, @PriceLastSetDate, @IsDiscoverable)) AS Source (Id, BlogId, Name, Price, IsVisibleToNonSubscribers, CreationDate, PriceLastSetDate, IsDiscoverable)
                ON    (");
                
            if (mergeOnFields == Channel.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, BlogId, Name, Price, IsVisibleToNonSubscribers, CreationDate, PriceLastSetDate, IsDiscoverable)
                    VALUES  (Source.Id, Source.BlogId, Source.Name, Source.Price, Source.IsVisibleToNonSubscribers, Source.CreationDate, Source.PriceLastSetDate, Source.IsDiscoverable);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Channel.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Channels SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Channel.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(Channel.Fields.BlogId))
            {
                fieldNames.Add("BlogId");
            }
        
            if (fields.HasFlag(Channel.Fields.Name))
            {
                fieldNames.Add("Name");
            }
        
            if (fields.HasFlag(Channel.Fields.Price))
            {
                fieldNames.Add("Price");
            }
        
            if (fields.HasFlag(Channel.Fields.IsVisibleToNonSubscribers))
            {
                fieldNames.Add("IsVisibleToNonSubscribers");
            }
        
            if (fields.HasFlag(Channel.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            if (fields.HasFlag(Channel.Fields.PriceLastSetDate))
            {
                fieldNames.Add("PriceLastSetDate");
            }
        
            if (fields.HasFlag(Channel.Fields.IsDiscoverable))
            {
                fieldNames.Add("IsDiscoverable");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Channel entity, 
            Channel.Fields fields,
            Channel.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(Channel.Fields.BlogId) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.BlogId)))
            {
                parameters.Add("BlogId", entity.BlogId);
            }
        
            if (fields.HasFlag(Channel.Fields.Name) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.Name)))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (fields.HasFlag(Channel.Fields.Price) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.Price)))
            {
                parameters.Add("Price", entity.Price);
            }
        
            if (fields.HasFlag(Channel.Fields.IsVisibleToNonSubscribers) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.IsVisibleToNonSubscribers)))
            {
                parameters.Add("IsVisibleToNonSubscribers", entity.IsVisibleToNonSubscribers);
            }
        
            if (fields.HasFlag(Channel.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            if (fields.HasFlag(Channel.Fields.PriceLastSetDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.PriceLastSetDate)))
            {
                parameters.Add("PriceLastSetDate", entity.PriceLastSetDate);
            }
        
            if (fields.HasFlag(Channel.Fields.IsDiscoverable) && (excludedFields == null || !excludedFields.Value.HasFlag(Channel.Fields.IsDiscoverable)))
            {
                parameters.Add("IsDiscoverable", entity.IsDiscoverable);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Channel entity, 
            Channel.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(Channel.Fields.BlogId))
            {
                parameters.Add("BlogId", entity.BlogId);
            }
        
            if (!fields.HasFlag(Channel.Fields.Name))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (!fields.HasFlag(Channel.Fields.Price))
            {
                parameters.Add("Price", entity.Price);
            }
        
            if (!fields.HasFlag(Channel.Fields.IsVisibleToNonSubscribers))
            {
                parameters.Add("IsVisibleToNonSubscribers", entity.IsVisibleToNonSubscribers);
            }
        
            if (!fields.HasFlag(Channel.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            if (!fields.HasFlag(Channel.Fields.PriceLastSetDate))
            {
                parameters.Add("PriceLastSetDate", entity.PriceLastSetDate);
            }
        
            if (!fields.HasFlag(Channel.Fields.IsDiscoverable))
            {
                parameters.Add("IsDiscoverable", entity.IsDiscoverable);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;
    using System.Linq;

    public partial class ChannelSubscription  : IIdentityEquatable
    {
        public const string Table = "ChannelSubscriptions";
        
        public ChannelSubscription(
            System.Guid channelId,
            System.Guid userId)
        {
            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.ChannelId = channelId;
            this.UserId = userId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((ChannelSubscription)other);
        }
        
        protected bool IdentityEquals(ChannelSubscription other)
        {
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            ChannelId = 1, 
            UserId = 2, 
            AcceptedPrice = 4, 
            PriceLastAcceptedDate = 8, 
            SubscriptionStartDate = 16
        }
    }

    public static partial class ChannelSubscriptionExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<ChannelSubscription> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.ChannelId, entity.UserId, entity.AcceptedPrice, entity.PriceLastAcceptedDate, entity.SubscriptionStartDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            ChannelSubscription entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.ChannelId, entity.UserId, entity.AcceptedPrice, entity.PriceLastAcceptedDate, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<ChannelSubscription, ChannelSubscription.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.ChannelId, entity.UserId, entity.AcceptedPrice, entity.PriceLastAcceptedDate, entity.SubscriptionStartDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            ChannelSubscription entity, 
            ChannelSubscription.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(ChannelSubscription.Fields.Empty, fields), 
                new 
                {
                    entity.ChannelId, entity.UserId, entity.AcceptedPrice, entity.PriceLastAcceptedDate, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            ChannelSubscription entity, 
            ChannelSubscription.Fields mergeOnFields,
            ChannelSubscription.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.ChannelId, entity.UserId, entity.AcceptedPrice, entity.PriceLastAcceptedDate, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            ChannelSubscription entity, 
            ChannelSubscription.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<ChannelSubscription, ChannelSubscription.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO ChannelSubscriptions(ChannelId, UserId, AcceptedPrice, PriceLastAcceptedDate, SubscriptionStartDate) VALUES(@ChannelId, @UserId, @AcceptedPrice, @PriceLastAcceptedDate, @SubscriptionStartDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(ChannelSubscription.Fields mergeOnFields, ChannelSubscription.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE ChannelSubscriptions WITH (HOLDLOCK) as Target
                USING (VALUES (@ChannelId, @UserId, @AcceptedPrice, @PriceLastAcceptedDate, @SubscriptionStartDate)) AS Source (ChannelId, UserId, AcceptedPrice, PriceLastAcceptedDate, SubscriptionStartDate)
                ON    (");
                
            if (mergeOnFields == ChannelSubscription.Fields.Empty)
            {
                sql.Append(@"Target.ChannelId = Source.ChannelId AND Target.UserId = Source.UserId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (ChannelId, UserId, AcceptedPrice, PriceLastAcceptedDate, SubscriptionStartDate)
                    VALUES  (Source.ChannelId, Source.UserId, Source.AcceptedPrice, Source.PriceLastAcceptedDate, Source.SubscriptionStartDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(ChannelSubscription.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE ChannelSubscriptions SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE ChannelId = @ChannelId AND UserId = @UserId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(ChannelSubscription.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("ChannelId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(ChannelSubscription.Fields.AcceptedPrice))
            {
                fieldNames.Add("AcceptedPrice");
            }
        
            if (fields.HasFlag(ChannelSubscription.Fields.PriceLastAcceptedDate))
            {
                fieldNames.Add("PriceLastAcceptedDate");
            }
        
            if (fields.HasFlag(ChannelSubscription.Fields.SubscriptionStartDate))
            {
                fieldNames.Add("SubscriptionStartDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            ChannelSubscription entity, 
            ChannelSubscription.Fields fields,
            ChannelSubscription.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("ChannelId", entity.ChannelId);
            parameters.Add("UserId", entity.UserId);
            if (fields.HasFlag(ChannelSubscription.Fields.AcceptedPrice) && (excludedFields == null || !excludedFields.Value.HasFlag(ChannelSubscription.Fields.AcceptedPrice)))
            {
                parameters.Add("AcceptedPrice", entity.AcceptedPrice);
            }
        
            if (fields.HasFlag(ChannelSubscription.Fields.PriceLastAcceptedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(ChannelSubscription.Fields.PriceLastAcceptedDate)))
            {
                parameters.Add("PriceLastAcceptedDate", entity.PriceLastAcceptedDate);
            }
        
            if (fields.HasFlag(ChannelSubscription.Fields.SubscriptionStartDate) && (excludedFields == null || !excludedFields.Value.HasFlag(ChannelSubscription.Fields.SubscriptionStartDate)))
            {
                parameters.Add("SubscriptionStartDate", entity.SubscriptionStartDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            ChannelSubscription entity, 
            ChannelSubscription.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("ChannelId", entity.ChannelId);
            parameters.Add("UserId", entity.UserId);
            if (!fields.HasFlag(ChannelSubscription.Fields.AcceptedPrice))
            {
                parameters.Add("AcceptedPrice", entity.AcceptedPrice);
            }
        
            if (!fields.HasFlag(ChannelSubscription.Fields.PriceLastAcceptedDate))
            {
                parameters.Add("PriceLastAcceptedDate", entity.PriceLastAcceptedDate);
            }
        
            if (!fields.HasFlag(ChannelSubscription.Fields.SubscriptionStartDate))
            {
                parameters.Add("SubscriptionStartDate", entity.SubscriptionStartDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Queue  : IIdentityEquatable
    {
        public const string Table = "Queues";
        
        public Queue(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Queue)other);
        }
        
        protected bool IdentityEquals(Queue other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            BlogId = 2, 
            Name = 4, 
            CreationDate = 8
        }
    }

    public static partial class QueueExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Queue> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.CreationDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Queue entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Queue, Queue.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.BlogId, entity.Name, entity.CreationDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Queue entity, 
            Queue.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Queue.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Queue entity, 
            Queue.Fields mergeOnFields,
            Queue.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.BlogId, entity.Name, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Queue entity, 
            Queue.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Queue, Queue.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Queues(Id, BlogId, Name, CreationDate) VALUES(@Id, @BlogId, @Name, @CreationDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Queue.Fields mergeOnFields, Queue.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Queues WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @BlogId, @Name, @CreationDate)) AS Source (Id, BlogId, Name, CreationDate)
                ON    (");
                
            if (mergeOnFields == Queue.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, BlogId, Name, CreationDate)
                    VALUES  (Source.Id, Source.BlogId, Source.Name, Source.CreationDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Queue.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Queues SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Queue.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(Queue.Fields.BlogId))
            {
                fieldNames.Add("BlogId");
            }
        
            if (fields.HasFlag(Queue.Fields.Name))
            {
                fieldNames.Add("Name");
            }
        
            if (fields.HasFlag(Queue.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Queue entity, 
            Queue.Fields fields,
            Queue.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(Queue.Fields.BlogId) && (excludedFields == null || !excludedFields.Value.HasFlag(Queue.Fields.BlogId)))
            {
                parameters.Add("BlogId", entity.BlogId);
            }
        
            if (fields.HasFlag(Queue.Fields.Name) && (excludedFields == null || !excludedFields.Value.HasFlag(Queue.Fields.Name)))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (fields.HasFlag(Queue.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Queue.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Queue entity, 
            Queue.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(Queue.Fields.BlogId))
            {
                parameters.Add("BlogId", entity.BlogId);
            }
        
            if (!fields.HasFlag(Queue.Fields.Name))
            {
                parameters.Add("Name", entity.Name);
            }
        
            if (!fields.HasFlag(Queue.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class EndToEndTestEmail  : IIdentityEquatable
    {
        public const string Table = "EndToEndTestEmails";
        
        public EndToEndTestEmail(
            System.String mailbox)
        {
            if (mailbox == null)
            {
                throw new ArgumentNullException("mailbox");
            }

            this.Mailbox = mailbox;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((EndToEndTestEmail)other);
        }
        
        protected bool IdentityEquals(EndToEndTestEmail other)
        {
            if (!object.Equals(this.Mailbox, other.Mailbox))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Mailbox = 1, 
            Subject = 2, 
            Body = 4, 
            DateReceived = 8
        }
    }

    public static partial class EndToEndTestEmailExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<EndToEndTestEmail> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Mailbox, entity.Subject, entity.Body, entity.DateReceived
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            EndToEndTestEmail entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Mailbox, entity.Subject, entity.Body, entity.DateReceived
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<EndToEndTestEmail, EndToEndTestEmail.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Mailbox, entity.Subject, entity.Body, entity.DateReceived });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            EndToEndTestEmail entity, 
            EndToEndTestEmail.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(EndToEndTestEmail.Fields.Empty, fields), 
                new 
                {
                    entity.Mailbox, entity.Subject, entity.Body, entity.DateReceived
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            EndToEndTestEmail entity, 
            EndToEndTestEmail.Fields mergeOnFields,
            EndToEndTestEmail.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Mailbox, entity.Subject, entity.Body, entity.DateReceived
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            EndToEndTestEmail entity, 
            EndToEndTestEmail.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<EndToEndTestEmail, EndToEndTestEmail.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO EndToEndTestEmails(Mailbox, Subject, Body, DateReceived) VALUES(@Mailbox, @Subject, @Body, @DateReceived)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(EndToEndTestEmail.Fields mergeOnFields, EndToEndTestEmail.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE EndToEndTestEmails WITH (HOLDLOCK) as Target
                USING (VALUES (@Mailbox, @Subject, @Body, @DateReceived)) AS Source (Mailbox, Subject, Body, DateReceived)
                ON    (");
                
            if (mergeOnFields == EndToEndTestEmail.Fields.Empty)
            {
                sql.Append(@"Target.Mailbox = Source.Mailbox");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Mailbox, Subject, Body, DateReceived)
                    VALUES  (Source.Mailbox, Source.Subject, Source.Body, Source.DateReceived);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(EndToEndTestEmail.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE EndToEndTestEmails SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Mailbox = @Mailbox");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(EndToEndTestEmail.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Mailbox");
            }
        
            if (fields.HasFlag(EndToEndTestEmail.Fields.Subject))
            {
                fieldNames.Add("Subject");
            }
        
            if (fields.HasFlag(EndToEndTestEmail.Fields.Body))
            {
                fieldNames.Add("Body");
            }
        
            if (fields.HasFlag(EndToEndTestEmail.Fields.DateReceived))
            {
                fieldNames.Add("DateReceived");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            EndToEndTestEmail entity, 
            EndToEndTestEmail.Fields fields,
            EndToEndTestEmail.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Mailbox", entity.Mailbox);
            if (fields.HasFlag(EndToEndTestEmail.Fields.Subject) && (excludedFields == null || !excludedFields.Value.HasFlag(EndToEndTestEmail.Fields.Subject)))
            {
                parameters.Add("Subject", entity.Subject);
            }
        
            if (fields.HasFlag(EndToEndTestEmail.Fields.Body) && (excludedFields == null || !excludedFields.Value.HasFlag(EndToEndTestEmail.Fields.Body)))
            {
                parameters.Add("Body", entity.Body);
            }
        
            if (fields.HasFlag(EndToEndTestEmail.Fields.DateReceived) && (excludedFields == null || !excludedFields.Value.HasFlag(EndToEndTestEmail.Fields.DateReceived)))
            {
                parameters.Add("DateReceived", entity.DateReceived);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            EndToEndTestEmail entity, 
            EndToEndTestEmail.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Mailbox", entity.Mailbox);
            if (!fields.HasFlag(EndToEndTestEmail.Fields.Subject))
            {
                parameters.Add("Subject", entity.Subject);
            }
        
            if (!fields.HasFlag(EndToEndTestEmail.Fields.Body))
            {
                parameters.Add("Body", entity.Body);
            }
        
            if (!fields.HasFlag(EndToEndTestEmail.Fields.DateReceived))
            {
                parameters.Add("DateReceived", entity.DateReceived);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class File  : IIdentityEquatable
    {
        public const string Table = "Files";
        
        public File(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((File)other);
        }
        
        protected bool IdentityEquals(File other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            UserId = 2, 
            ChannelId = 4, 
            State = 8, 
            UploadStartedDate = 16, 
            UploadCompletedDate = 32, 
            ProcessingStartedDate = 64, 
            ProcessingCompletedDate = 128, 
            ProcessingAttempts = 256, 
            FileNameWithoutExtension = 512, 
            FileExtension = 1024, 
            BlobSizeBytes = 2048, 
            Purpose = 4096, 
            RenderWidth = 8192, 
            RenderHeight = 16384
        }
    }

    public static partial class FileExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<File> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.UserId, entity.ChannelId, entity.State, entity.UploadStartedDate, entity.UploadCompletedDate, entity.ProcessingStartedDate, entity.ProcessingCompletedDate, entity.ProcessingAttempts, entity.FileNameWithoutExtension, entity.FileExtension, entity.BlobSizeBytes, entity.Purpose, entity.RenderWidth, entity.RenderHeight
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            File entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.UserId, entity.ChannelId, entity.State, entity.UploadStartedDate, entity.UploadCompletedDate, entity.ProcessingStartedDate, entity.ProcessingCompletedDate, entity.ProcessingAttempts, entity.FileNameWithoutExtension, entity.FileExtension, entity.BlobSizeBytes, entity.Purpose, entity.RenderWidth, entity.RenderHeight
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<File, File.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.UserId, entity.ChannelId, entity.State, entity.UploadStartedDate, entity.UploadCompletedDate, entity.ProcessingStartedDate, entity.ProcessingCompletedDate, entity.ProcessingAttempts, entity.FileNameWithoutExtension, entity.FileExtension, entity.BlobSizeBytes, entity.Purpose, entity.RenderWidth, entity.RenderHeight });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            File entity, 
            File.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(File.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.UserId, entity.ChannelId, entity.State, entity.UploadStartedDate, entity.UploadCompletedDate, entity.ProcessingStartedDate, entity.ProcessingCompletedDate, entity.ProcessingAttempts, entity.FileNameWithoutExtension, entity.FileExtension, entity.BlobSizeBytes, entity.Purpose, entity.RenderWidth, entity.RenderHeight
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            File entity, 
            File.Fields mergeOnFields,
            File.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.UserId, entity.ChannelId, entity.State, entity.UploadStartedDate, entity.UploadCompletedDate, entity.ProcessingStartedDate, entity.ProcessingCompletedDate, entity.ProcessingAttempts, entity.FileNameWithoutExtension, entity.FileExtension, entity.BlobSizeBytes, entity.Purpose, entity.RenderWidth, entity.RenderHeight
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            File entity, 
            File.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<File, File.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Files(Id, UserId, ChannelId, State, UploadStartedDate, UploadCompletedDate, ProcessingStartedDate, ProcessingCompletedDate, ProcessingAttempts, FileNameWithoutExtension, FileExtension, BlobSizeBytes, Purpose, RenderWidth, RenderHeight) VALUES(@Id, @UserId, @ChannelId, @State, @UploadStartedDate, @UploadCompletedDate, @ProcessingStartedDate, @ProcessingCompletedDate, @ProcessingAttempts, @FileNameWithoutExtension, @FileExtension, @BlobSizeBytes, @Purpose, @RenderWidth, @RenderHeight)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(File.Fields mergeOnFields, File.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Files WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @UserId, @ChannelId, @State, @UploadStartedDate, @UploadCompletedDate, @ProcessingStartedDate, @ProcessingCompletedDate, @ProcessingAttempts, @FileNameWithoutExtension, @FileExtension, @BlobSizeBytes, @Purpose, @RenderWidth, @RenderHeight)) AS Source (Id, UserId, ChannelId, State, UploadStartedDate, UploadCompletedDate, ProcessingStartedDate, ProcessingCompletedDate, ProcessingAttempts, FileNameWithoutExtension, FileExtension, BlobSizeBytes, Purpose, RenderWidth, RenderHeight)
                ON    (");
                
            if (mergeOnFields == File.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, UserId, ChannelId, State, UploadStartedDate, UploadCompletedDate, ProcessingStartedDate, ProcessingCompletedDate, ProcessingAttempts, FileNameWithoutExtension, FileExtension, BlobSizeBytes, Purpose, RenderWidth, RenderHeight)
                    VALUES  (Source.Id, Source.UserId, Source.ChannelId, Source.State, Source.UploadStartedDate, Source.UploadCompletedDate, Source.ProcessingStartedDate, Source.ProcessingCompletedDate, Source.ProcessingAttempts, Source.FileNameWithoutExtension, Source.FileExtension, Source.BlobSizeBytes, Source.Purpose, Source.RenderWidth, Source.RenderHeight);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(File.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Files SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(File.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(File.Fields.UserId))
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(File.Fields.ChannelId))
            {
                fieldNames.Add("ChannelId");
            }
        
            if (fields.HasFlag(File.Fields.State))
            {
                fieldNames.Add("State");
            }
        
            if (fields.HasFlag(File.Fields.UploadStartedDate))
            {
                fieldNames.Add("UploadStartedDate");
            }
        
            if (fields.HasFlag(File.Fields.UploadCompletedDate))
            {
                fieldNames.Add("UploadCompletedDate");
            }
        
            if (fields.HasFlag(File.Fields.ProcessingStartedDate))
            {
                fieldNames.Add("ProcessingStartedDate");
            }
        
            if (fields.HasFlag(File.Fields.ProcessingCompletedDate))
            {
                fieldNames.Add("ProcessingCompletedDate");
            }
        
            if (fields.HasFlag(File.Fields.ProcessingAttempts))
            {
                fieldNames.Add("ProcessingAttempts");
            }
        
            if (fields.HasFlag(File.Fields.FileNameWithoutExtension))
            {
                fieldNames.Add("FileNameWithoutExtension");
            }
        
            if (fields.HasFlag(File.Fields.FileExtension))
            {
                fieldNames.Add("FileExtension");
            }
        
            if (fields.HasFlag(File.Fields.BlobSizeBytes))
            {
                fieldNames.Add("BlobSizeBytes");
            }
        
            if (fields.HasFlag(File.Fields.Purpose))
            {
                fieldNames.Add("Purpose");
            }
        
            if (fields.HasFlag(File.Fields.RenderWidth))
            {
                fieldNames.Add("RenderWidth");
            }
        
            if (fields.HasFlag(File.Fields.RenderHeight))
            {
                fieldNames.Add("RenderHeight");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            File entity, 
            File.Fields fields,
            File.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(File.Fields.UserId) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.UserId)))
            {
                parameters.Add("UserId", entity.UserId);
            }
        
            if (fields.HasFlag(File.Fields.ChannelId) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.ChannelId)))
            {
                parameters.Add("ChannelId", entity.ChannelId);
            }
        
            if (fields.HasFlag(File.Fields.State) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.State)))
            {
                parameters.Add("State", entity.State);
            }
        
            if (fields.HasFlag(File.Fields.UploadStartedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.UploadStartedDate)))
            {
                parameters.Add("UploadStartedDate", entity.UploadStartedDate);
            }
        
            if (fields.HasFlag(File.Fields.UploadCompletedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.UploadCompletedDate)))
            {
                parameters.Add("UploadCompletedDate", entity.UploadCompletedDate);
            }
        
            if (fields.HasFlag(File.Fields.ProcessingStartedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.ProcessingStartedDate)))
            {
                parameters.Add("ProcessingStartedDate", entity.ProcessingStartedDate);
            }
        
            if (fields.HasFlag(File.Fields.ProcessingCompletedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.ProcessingCompletedDate)))
            {
                parameters.Add("ProcessingCompletedDate", entity.ProcessingCompletedDate);
            }
        
            if (fields.HasFlag(File.Fields.ProcessingAttempts) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.ProcessingAttempts)))
            {
                parameters.Add("ProcessingAttempts", entity.ProcessingAttempts);
            }
        
            if (fields.HasFlag(File.Fields.FileNameWithoutExtension) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.FileNameWithoutExtension)))
            {
                parameters.Add("FileNameWithoutExtension", entity.FileNameWithoutExtension);
            }
        
            if (fields.HasFlag(File.Fields.FileExtension) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.FileExtension)))
            {
                parameters.Add("FileExtension", entity.FileExtension);
            }
        
            if (fields.HasFlag(File.Fields.BlobSizeBytes) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.BlobSizeBytes)))
            {
                parameters.Add("BlobSizeBytes", entity.BlobSizeBytes);
            }
        
            if (fields.HasFlag(File.Fields.Purpose) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.Purpose)))
            {
                parameters.Add("Purpose", entity.Purpose);
            }
        
            if (fields.HasFlag(File.Fields.RenderWidth) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.RenderWidth)))
            {
                parameters.Add("RenderWidth", entity.RenderWidth);
            }
        
            if (fields.HasFlag(File.Fields.RenderHeight) && (excludedFields == null || !excludedFields.Value.HasFlag(File.Fields.RenderHeight)))
            {
                parameters.Add("RenderHeight", entity.RenderHeight);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            File entity, 
            File.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(File.Fields.UserId))
            {
                parameters.Add("UserId", entity.UserId);
            }
        
            if (!fields.HasFlag(File.Fields.ChannelId))
            {
                parameters.Add("ChannelId", entity.ChannelId);
            }
        
            if (!fields.HasFlag(File.Fields.State))
            {
                parameters.Add("State", entity.State);
            }
        
            if (!fields.HasFlag(File.Fields.UploadStartedDate))
            {
                parameters.Add("UploadStartedDate", entity.UploadStartedDate);
            }
        
            if (!fields.HasFlag(File.Fields.UploadCompletedDate))
            {
                parameters.Add("UploadCompletedDate", entity.UploadCompletedDate);
            }
        
            if (!fields.HasFlag(File.Fields.ProcessingStartedDate))
            {
                parameters.Add("ProcessingStartedDate", entity.ProcessingStartedDate);
            }
        
            if (!fields.HasFlag(File.Fields.ProcessingCompletedDate))
            {
                parameters.Add("ProcessingCompletedDate", entity.ProcessingCompletedDate);
            }
        
            if (!fields.HasFlag(File.Fields.ProcessingAttempts))
            {
                parameters.Add("ProcessingAttempts", entity.ProcessingAttempts);
            }
        
            if (!fields.HasFlag(File.Fields.FileNameWithoutExtension))
            {
                parameters.Add("FileNameWithoutExtension", entity.FileNameWithoutExtension);
            }
        
            if (!fields.HasFlag(File.Fields.FileExtension))
            {
                parameters.Add("FileExtension", entity.FileExtension);
            }
        
            if (!fields.HasFlag(File.Fields.BlobSizeBytes))
            {
                parameters.Add("BlobSizeBytes", entity.BlobSizeBytes);
            }
        
            if (!fields.HasFlag(File.Fields.Purpose))
            {
                parameters.Add("Purpose", entity.Purpose);
            }
        
            if (!fields.HasFlag(File.Fields.RenderWidth))
            {
                parameters.Add("RenderWidth", entity.RenderWidth);
            }
        
            if (!fields.HasFlag(File.Fields.RenderHeight))
            {
                parameters.Add("RenderHeight", entity.RenderHeight);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreeAccessUser  : IIdentityEquatable
    {
        public const string Table = "FreeAccessUsers";
        
        public FreeAccessUser(
            System.Guid blogId,
            System.String email)
        {
            if (blogId == null)
            {
                throw new ArgumentNullException("blogId");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            this.BlogId = blogId;
            this.Email = email;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((FreeAccessUser)other);
        }
        
        protected bool IdentityEquals(FreeAccessUser other)
        {
            if (!object.Equals(this.BlogId, other.BlogId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            BlogId = 1, 
            Email = 2
        }
    }

    public static partial class FreeAccessUserExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<FreeAccessUser> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.BlogId, entity.Email
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreeAccessUser entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.BlogId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FreeAccessUser, FreeAccessUser.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.BlogId, entity.Email });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreeAccessUser entity, 
            FreeAccessUser.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(FreeAccessUser.Fields.Empty, fields), 
                new 
                {
                    entity.BlogId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreeAccessUser entity, 
            FreeAccessUser.Fields mergeOnFields,
            FreeAccessUser.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.BlogId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            FreeAccessUser entity, 
            FreeAccessUser.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FreeAccessUser, FreeAccessUser.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO FreeAccessUsers(BlogId, Email) VALUES(@BlogId, @Email)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(FreeAccessUser.Fields mergeOnFields, FreeAccessUser.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE FreeAccessUsers WITH (HOLDLOCK) as Target
                USING (VALUES (@BlogId, @Email)) AS Source (BlogId, Email)
                ON    (");
                
            if (mergeOnFields == FreeAccessUser.Fields.Empty)
            {
                sql.Append(@"Target.BlogId = Source.BlogId AND Target.Email = Source.Email");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (BlogId, Email)
                    VALUES  (Source.BlogId, Source.Email);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(FreeAccessUser.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE FreeAccessUsers SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE BlogId = @BlogId AND Email = @Email");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(FreeAccessUser.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("BlogId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Email");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            FreeAccessUser entity, 
            FreeAccessUser.Fields fields,
            FreeAccessUser.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("BlogId", entity.BlogId);
            parameters.Add("Email", entity.Email);
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            FreeAccessUser entity, 
            FreeAccessUser.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("BlogId", entity.BlogId);
            parameters.Add("Email", entity.Email);
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Post  : IIdentityEquatable
    {
        public const string Table = "Posts";
        
        public Post(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Post)other);
        }
        
        protected bool IdentityEquals(Post other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            ChannelId = 2, 
            QueueId = 4, 
            PreviewImageId = 8, 
            PreviewText = 16, 
            Content = 32, 
            PreviewWordCount = 64, 
            WordCount = 128, 
            ImageCount = 256, 
            FileCount = 512, 
            VideoCount = 1024, 
            LiveDate = 2048, 
            CreationDate = 4096
        }
    }

    public static partial class PostExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Post> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.ChannelId, entity.QueueId, entity.PreviewImageId, entity.PreviewText, entity.Content, entity.PreviewWordCount, entity.WordCount, entity.ImageCount, entity.FileCount, entity.VideoCount, entity.LiveDate, entity.CreationDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Post entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.ChannelId, entity.QueueId, entity.PreviewImageId, entity.PreviewText, entity.Content, entity.PreviewWordCount, entity.WordCount, entity.ImageCount, entity.FileCount, entity.VideoCount, entity.LiveDate, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Post, Post.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.ChannelId, entity.QueueId, entity.PreviewImageId, entity.PreviewText, entity.Content, entity.PreviewWordCount, entity.WordCount, entity.ImageCount, entity.FileCount, entity.VideoCount, entity.LiveDate, entity.CreationDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Post entity, 
            Post.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Post.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.ChannelId, entity.QueueId, entity.PreviewImageId, entity.PreviewText, entity.Content, entity.PreviewWordCount, entity.WordCount, entity.ImageCount, entity.FileCount, entity.VideoCount, entity.LiveDate, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Post entity, 
            Post.Fields mergeOnFields,
            Post.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.ChannelId, entity.QueueId, entity.PreviewImageId, entity.PreviewText, entity.Content, entity.PreviewWordCount, entity.WordCount, entity.ImageCount, entity.FileCount, entity.VideoCount, entity.LiveDate, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Post entity, 
            Post.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Post, Post.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Posts(Id, ChannelId, QueueId, PreviewImageId, PreviewText, Content, PreviewWordCount, WordCount, ImageCount, FileCount, VideoCount, LiveDate, CreationDate) VALUES(@Id, @ChannelId, @QueueId, @PreviewImageId, @PreviewText, @Content, @PreviewWordCount, @WordCount, @ImageCount, @FileCount, @VideoCount, @LiveDate, @CreationDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Post.Fields mergeOnFields, Post.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Posts WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @ChannelId, @QueueId, @PreviewImageId, @PreviewText, @Content, @PreviewWordCount, @WordCount, @ImageCount, @FileCount, @VideoCount, @LiveDate, @CreationDate)) AS Source (Id, ChannelId, QueueId, PreviewImageId, PreviewText, Content, PreviewWordCount, WordCount, ImageCount, FileCount, VideoCount, LiveDate, CreationDate)
                ON    (");
                
            if (mergeOnFields == Post.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, ChannelId, QueueId, PreviewImageId, PreviewText, Content, PreviewWordCount, WordCount, ImageCount, FileCount, VideoCount, LiveDate, CreationDate)
                    VALUES  (Source.Id, Source.ChannelId, Source.QueueId, Source.PreviewImageId, Source.PreviewText, Source.Content, Source.PreviewWordCount, Source.WordCount, Source.ImageCount, Source.FileCount, Source.VideoCount, Source.LiveDate, Source.CreationDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Post.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Posts SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Post.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(Post.Fields.ChannelId))
            {
                fieldNames.Add("ChannelId");
            }
        
            if (fields.HasFlag(Post.Fields.QueueId))
            {
                fieldNames.Add("QueueId");
            }
        
            if (fields.HasFlag(Post.Fields.PreviewImageId))
            {
                fieldNames.Add("PreviewImageId");
            }
        
            if (fields.HasFlag(Post.Fields.PreviewText))
            {
                fieldNames.Add("PreviewText");
            }
        
            if (fields.HasFlag(Post.Fields.Content))
            {
                fieldNames.Add("Content");
            }
        
            if (fields.HasFlag(Post.Fields.PreviewWordCount))
            {
                fieldNames.Add("PreviewWordCount");
            }
        
            if (fields.HasFlag(Post.Fields.WordCount))
            {
                fieldNames.Add("WordCount");
            }
        
            if (fields.HasFlag(Post.Fields.ImageCount))
            {
                fieldNames.Add("ImageCount");
            }
        
            if (fields.HasFlag(Post.Fields.FileCount))
            {
                fieldNames.Add("FileCount");
            }
        
            if (fields.HasFlag(Post.Fields.VideoCount))
            {
                fieldNames.Add("VideoCount");
            }
        
            if (fields.HasFlag(Post.Fields.LiveDate))
            {
                fieldNames.Add("LiveDate");
            }
        
            if (fields.HasFlag(Post.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Post entity, 
            Post.Fields fields,
            Post.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(Post.Fields.ChannelId) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.ChannelId)))
            {
                parameters.Add("ChannelId", entity.ChannelId);
            }
        
            if (fields.HasFlag(Post.Fields.QueueId) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.QueueId)))
            {
                parameters.Add("QueueId", entity.QueueId);
            }
        
            if (fields.HasFlag(Post.Fields.PreviewImageId) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.PreviewImageId)))
            {
                parameters.Add("PreviewImageId", entity.PreviewImageId);
            }
        
            if (fields.HasFlag(Post.Fields.PreviewText) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.PreviewText)))
            {
                parameters.Add("PreviewText", entity.PreviewText);
            }
        
            if (fields.HasFlag(Post.Fields.Content) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.Content)))
            {
                parameters.Add("Content", entity.Content);
            }
        
            if (fields.HasFlag(Post.Fields.PreviewWordCount) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.PreviewWordCount)))
            {
                parameters.Add("PreviewWordCount", entity.PreviewWordCount);
            }
        
            if (fields.HasFlag(Post.Fields.WordCount) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.WordCount)))
            {
                parameters.Add("WordCount", entity.WordCount);
            }
        
            if (fields.HasFlag(Post.Fields.ImageCount) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.ImageCount)))
            {
                parameters.Add("ImageCount", entity.ImageCount);
            }
        
            if (fields.HasFlag(Post.Fields.FileCount) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.FileCount)))
            {
                parameters.Add("FileCount", entity.FileCount);
            }
        
            if (fields.HasFlag(Post.Fields.VideoCount) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.VideoCount)))
            {
                parameters.Add("VideoCount", entity.VideoCount);
            }
        
            if (fields.HasFlag(Post.Fields.LiveDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.LiveDate)))
            {
                parameters.Add("LiveDate", entity.LiveDate);
            }
        
            if (fields.HasFlag(Post.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Post.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Post entity, 
            Post.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(Post.Fields.ChannelId))
            {
                parameters.Add("ChannelId", entity.ChannelId);
            }
        
            if (!fields.HasFlag(Post.Fields.QueueId))
            {
                parameters.Add("QueueId", entity.QueueId);
            }
        
            if (!fields.HasFlag(Post.Fields.PreviewImageId))
            {
                parameters.Add("PreviewImageId", entity.PreviewImageId);
            }
        
            if (!fields.HasFlag(Post.Fields.PreviewText))
            {
                parameters.Add("PreviewText", entity.PreviewText);
            }
        
            if (!fields.HasFlag(Post.Fields.Content))
            {
                parameters.Add("Content", entity.Content);
            }
        
            if (!fields.HasFlag(Post.Fields.PreviewWordCount))
            {
                parameters.Add("PreviewWordCount", entity.PreviewWordCount);
            }
        
            if (!fields.HasFlag(Post.Fields.WordCount))
            {
                parameters.Add("WordCount", entity.WordCount);
            }
        
            if (!fields.HasFlag(Post.Fields.ImageCount))
            {
                parameters.Add("ImageCount", entity.ImageCount);
            }
        
            if (!fields.HasFlag(Post.Fields.FileCount))
            {
                parameters.Add("FileCount", entity.FileCount);
            }
        
            if (!fields.HasFlag(Post.Fields.VideoCount))
            {
                parameters.Add("VideoCount", entity.VideoCount);
            }
        
            if (!fields.HasFlag(Post.Fields.LiveDate))
            {
                parameters.Add("LiveDate", entity.LiveDate);
            }
        
            if (!fields.HasFlag(Post.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Comment  : IIdentityEquatable
    {
        public const string Table = "Comments";
        
        public Comment(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Comment)other);
        }
        
        protected bool IdentityEquals(Comment other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            PostId = 2, 
            UserId = 4, 
            Content = 8, 
            CreationDate = 16
        }
    }

    public static partial class CommentExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Comment> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.PostId, entity.UserId, entity.Content, entity.CreationDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Comment entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.PostId, entity.UserId, entity.Content, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Comment, Comment.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.PostId, entity.UserId, entity.Content, entity.CreationDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Comment entity, 
            Comment.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Comment.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.PostId, entity.UserId, entity.Content, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Comment entity, 
            Comment.Fields mergeOnFields,
            Comment.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.PostId, entity.UserId, entity.Content, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Comment entity, 
            Comment.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Comment, Comment.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Comments(Id, PostId, UserId, Content, CreationDate) VALUES(@Id, @PostId, @UserId, @Content, @CreationDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Comment.Fields mergeOnFields, Comment.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Comments WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @PostId, @UserId, @Content, @CreationDate)) AS Source (Id, PostId, UserId, Content, CreationDate)
                ON    (");
                
            if (mergeOnFields == Comment.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, PostId, UserId, Content, CreationDate)
                    VALUES  (Source.Id, Source.PostId, Source.UserId, Source.Content, Source.CreationDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Comment.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Comments SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Comment.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(Comment.Fields.PostId))
            {
                fieldNames.Add("PostId");
            }
        
            if (fields.HasFlag(Comment.Fields.UserId))
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(Comment.Fields.Content))
            {
                fieldNames.Add("Content");
            }
        
            if (fields.HasFlag(Comment.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Comment entity, 
            Comment.Fields fields,
            Comment.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(Comment.Fields.PostId) && (excludedFields == null || !excludedFields.Value.HasFlag(Comment.Fields.PostId)))
            {
                parameters.Add("PostId", entity.PostId);
            }
        
            if (fields.HasFlag(Comment.Fields.UserId) && (excludedFields == null || !excludedFields.Value.HasFlag(Comment.Fields.UserId)))
            {
                parameters.Add("UserId", entity.UserId);
            }
        
            if (fields.HasFlag(Comment.Fields.Content) && (excludedFields == null || !excludedFields.Value.HasFlag(Comment.Fields.Content)))
            {
                parameters.Add("Content", entity.Content);
            }
        
            if (fields.HasFlag(Comment.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Comment.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Comment entity, 
            Comment.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(Comment.Fields.PostId))
            {
                parameters.Add("PostId", entity.PostId);
            }
        
            if (!fields.HasFlag(Comment.Fields.UserId))
            {
                parameters.Add("UserId", entity.UserId);
            }
        
            if (!fields.HasFlag(Comment.Fields.Content))
            {
                parameters.Add("Content", entity.Content);
            }
        
            if (!fields.HasFlag(Comment.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class Like  : IIdentityEquatable
    {
        public const string Table = "Likes";
        
        public Like(
            System.Guid postId,
            System.Guid userId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.PostId = postId;
            this.UserId = userId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((Like)other);
        }
        
        protected bool IdentityEquals(Like other)
        {
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            PostId = 1, 
            UserId = 2, 
            CreationDate = 4
        }
    }

    public static partial class LikeExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<Like> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.PostId, entity.UserId, entity.CreationDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            Like entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.PostId, entity.UserId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Like, Like.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.PostId, entity.UserId, entity.CreationDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Like entity, 
            Like.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(Like.Fields.Empty, fields), 
                new 
                {
                    entity.PostId, entity.UserId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            Like entity, 
            Like.Fields mergeOnFields,
            Like.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.PostId, entity.UserId, entity.CreationDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            Like entity, 
            Like.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<Like, Like.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO Likes(PostId, UserId, CreationDate) VALUES(@PostId, @UserId, @CreationDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(Like.Fields mergeOnFields, Like.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE Likes WITH (HOLDLOCK) as Target
                USING (VALUES (@PostId, @UserId, @CreationDate)) AS Source (PostId, UserId, CreationDate)
                ON    (");
                
            if (mergeOnFields == Like.Fields.Empty)
            {
                sql.Append(@"Target.PostId = Source.PostId AND Target.UserId = Source.UserId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (PostId, UserId, CreationDate)
                    VALUES  (Source.PostId, Source.UserId, Source.CreationDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(Like.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE Likes SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE PostId = @PostId AND UserId = @UserId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(Like.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("PostId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(Like.Fields.CreationDate))
            {
                fieldNames.Add("CreationDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            Like entity, 
            Like.Fields fields,
            Like.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("PostId", entity.PostId);
            parameters.Add("UserId", entity.UserId);
            if (fields.HasFlag(Like.Fields.CreationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(Like.Fields.CreationDate)))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            Like entity, 
            Like.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("PostId", entity.PostId);
            parameters.Add("UserId", entity.UserId);
            if (!fields.HasFlag(Like.Fields.CreationDate))
            {
                parameters.Add("CreationDate", entity.CreationDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class AppendOnlyLedgerRecord  : IIdentityEquatable
    {
        public const string Table = "AppendOnlyLedgerRecords";
        
        public AppendOnlyLedgerRecord(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((AppendOnlyLedgerRecord)other);
        }
        
        protected bool IdentityEquals(AppendOnlyLedgerRecord other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            AccountOwnerId = 2, 
            CounterpartyId = 4, 
            Timestamp = 8, 
            Amount = 16, 
            AccountType = 32, 
            TransactionType = 64, 
            TransactionReference = 128, 
            InputDataReference = 256, 
            Comment = 512, 
            StripeChargeId = 1024, 
            TaxamoTransactionKey = 2048
        }
    }

    public static partial class AppendOnlyLedgerRecordExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<AppendOnlyLedgerRecord> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.AccountOwnerId, entity.CounterpartyId, entity.Timestamp, entity.Amount, entity.AccountType, entity.TransactionType, entity.TransactionReference, entity.InputDataReference, entity.Comment, entity.StripeChargeId, entity.TaxamoTransactionKey
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            AppendOnlyLedgerRecord entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.AccountOwnerId, entity.CounterpartyId, entity.Timestamp, entity.Amount, entity.AccountType, entity.TransactionType, entity.TransactionReference, entity.InputDataReference, entity.Comment, entity.StripeChargeId, entity.TaxamoTransactionKey
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<AppendOnlyLedgerRecord, AppendOnlyLedgerRecord.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.AccountOwnerId, entity.CounterpartyId, entity.Timestamp, entity.Amount, entity.AccountType, entity.TransactionType, entity.TransactionReference, entity.InputDataReference, entity.Comment, entity.StripeChargeId, entity.TaxamoTransactionKey });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            AppendOnlyLedgerRecord entity, 
            AppendOnlyLedgerRecord.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(AppendOnlyLedgerRecord.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.AccountOwnerId, entity.CounterpartyId, entity.Timestamp, entity.Amount, entity.AccountType, entity.TransactionType, entity.TransactionReference, entity.InputDataReference, entity.Comment, entity.StripeChargeId, entity.TaxamoTransactionKey
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            AppendOnlyLedgerRecord entity, 
            AppendOnlyLedgerRecord.Fields mergeOnFields,
            AppendOnlyLedgerRecord.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.AccountOwnerId, entity.CounterpartyId, entity.Timestamp, entity.Amount, entity.AccountType, entity.TransactionType, entity.TransactionReference, entity.InputDataReference, entity.Comment, entity.StripeChargeId, entity.TaxamoTransactionKey
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            AppendOnlyLedgerRecord entity, 
            AppendOnlyLedgerRecord.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<AppendOnlyLedgerRecord, AppendOnlyLedgerRecord.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO AppendOnlyLedgerRecords(Id, AccountOwnerId, CounterpartyId, Timestamp, Amount, AccountType, TransactionType, TransactionReference, InputDataReference, Comment, StripeChargeId, TaxamoTransactionKey) VALUES(@Id, @AccountOwnerId, @CounterpartyId, @Timestamp, @Amount, @AccountType, @TransactionType, @TransactionReference, @InputDataReference, @Comment, @StripeChargeId, @TaxamoTransactionKey)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(AppendOnlyLedgerRecord.Fields mergeOnFields, AppendOnlyLedgerRecord.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE AppendOnlyLedgerRecords WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @AccountOwnerId, @CounterpartyId, @Timestamp, @Amount, @AccountType, @TransactionType, @TransactionReference, @InputDataReference, @Comment, @StripeChargeId, @TaxamoTransactionKey)) AS Source (Id, AccountOwnerId, CounterpartyId, Timestamp, Amount, AccountType, TransactionType, TransactionReference, InputDataReference, Comment, StripeChargeId, TaxamoTransactionKey)
                ON    (");
                
            if (mergeOnFields == AppendOnlyLedgerRecord.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, AccountOwnerId, CounterpartyId, Timestamp, Amount, AccountType, TransactionType, TransactionReference, InputDataReference, Comment, StripeChargeId, TaxamoTransactionKey)
                    VALUES  (Source.Id, Source.AccountOwnerId, Source.CounterpartyId, Source.Timestamp, Source.Amount, Source.AccountType, Source.TransactionType, Source.TransactionReference, Source.InputDataReference, Source.Comment, Source.StripeChargeId, Source.TaxamoTransactionKey);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(AppendOnlyLedgerRecord.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE AppendOnlyLedgerRecords SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(AppendOnlyLedgerRecord.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountOwnerId))
            {
                fieldNames.Add("AccountOwnerId");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.CounterpartyId))
            {
                fieldNames.Add("CounterpartyId");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Timestamp))
            {
                fieldNames.Add("Timestamp");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Amount))
            {
                fieldNames.Add("Amount");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountType))
            {
                fieldNames.Add("AccountType");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionType))
            {
                fieldNames.Add("TransactionType");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionReference))
            {
                fieldNames.Add("TransactionReference");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.InputDataReference))
            {
                fieldNames.Add("InputDataReference");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Comment))
            {
                fieldNames.Add("Comment");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.StripeChargeId))
            {
                fieldNames.Add("StripeChargeId");
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TaxamoTransactionKey))
            {
                fieldNames.Add("TaxamoTransactionKey");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            AppendOnlyLedgerRecord entity, 
            AppendOnlyLedgerRecord.Fields fields,
            AppendOnlyLedgerRecord.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountOwnerId) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.AccountOwnerId)))
            {
                parameters.Add("AccountOwnerId", entity.AccountOwnerId);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.CounterpartyId) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.CounterpartyId)))
            {
                parameters.Add("CounterpartyId", entity.CounterpartyId);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Timestamp) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.Timestamp)))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Amount) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.Amount)))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountType) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.AccountType)))
            {
                parameters.Add("AccountType", entity.AccountType);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionType) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionType)))
            {
                parameters.Add("TransactionType", entity.TransactionType);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionReference) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionReference)))
            {
                parameters.Add("TransactionReference", entity.TransactionReference);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.InputDataReference) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.InputDataReference)))
            {
                parameters.Add("InputDataReference", entity.InputDataReference);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.Comment) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.Comment)))
            {
                parameters.Add("Comment", entity.Comment);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.StripeChargeId) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.StripeChargeId)))
            {
                parameters.Add("StripeChargeId", entity.StripeChargeId);
            }
        
            if (fields.HasFlag(AppendOnlyLedgerRecord.Fields.TaxamoTransactionKey) && (excludedFields == null || !excludedFields.Value.HasFlag(AppendOnlyLedgerRecord.Fields.TaxamoTransactionKey)))
            {
                parameters.Add("TaxamoTransactionKey", entity.TaxamoTransactionKey);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            AppendOnlyLedgerRecord entity, 
            AppendOnlyLedgerRecord.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountOwnerId))
            {
                parameters.Add("AccountOwnerId", entity.AccountOwnerId);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.CounterpartyId))
            {
                parameters.Add("CounterpartyId", entity.CounterpartyId);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.Timestamp))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.Amount))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.AccountType))
            {
                parameters.Add("AccountType", entity.AccountType);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionType))
            {
                parameters.Add("TransactionType", entity.TransactionType);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.TransactionReference))
            {
                parameters.Add("TransactionReference", entity.TransactionReference);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.InputDataReference))
            {
                parameters.Add("InputDataReference", entity.InputDataReference);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.Comment))
            {
                parameters.Add("Comment", entity.Comment);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.StripeChargeId))
            {
                parameters.Add("StripeChargeId", entity.StripeChargeId);
            }
        
            if (!fields.HasFlag(AppendOnlyLedgerRecord.Fields.TaxamoTransactionKey))
            {
                parameters.Add("TaxamoTransactionKey", entity.TaxamoTransactionKey);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CalculatedAccountBalance  : IIdentityEquatable
    {
        public const string Table = "CalculatedAccountBalances";
        
        public CalculatedAccountBalance(
            System.Guid userId,
            Fifthweek.Api.Persistence.Payments.LedgerAccountType accountType,
            System.DateTime timestamp)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (accountType == null)
            {
                throw new ArgumentNullException("accountType");
            }

            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            this.UserId = userId;
            this.AccountType = accountType;
            this.Timestamp = timestamp;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CalculatedAccountBalance)other);
        }
        
        protected bool IdentityEquals(CalculatedAccountBalance other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.AccountType, other.AccountType))
            {
                return false;
            }
        
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            UserId = 1, 
            AccountType = 2, 
            Timestamp = 4, 
            Amount = 8
        }
    }

    public static partial class CalculatedAccountBalanceExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CalculatedAccountBalance> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.UserId, entity.AccountType, entity.Timestamp, entity.Amount
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CalculatedAccountBalance entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.UserId, entity.AccountType, entity.Timestamp, entity.Amount
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CalculatedAccountBalance, CalculatedAccountBalance.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.UserId, entity.AccountType, entity.Timestamp, entity.Amount });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CalculatedAccountBalance entity, 
            CalculatedAccountBalance.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CalculatedAccountBalance.Fields.Empty, fields), 
                new 
                {
                    entity.UserId, entity.AccountType, entity.Timestamp, entity.Amount
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CalculatedAccountBalance entity, 
            CalculatedAccountBalance.Fields mergeOnFields,
            CalculatedAccountBalance.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.UserId, entity.AccountType, entity.Timestamp, entity.Amount
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CalculatedAccountBalance entity, 
            CalculatedAccountBalance.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CalculatedAccountBalance, CalculatedAccountBalance.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CalculatedAccountBalances(UserId, AccountType, Timestamp, Amount) VALUES(@UserId, @AccountType, @Timestamp, @Amount)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CalculatedAccountBalance.Fields mergeOnFields, CalculatedAccountBalance.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CalculatedAccountBalances WITH (HOLDLOCK) as Target
                USING (VALUES (@UserId, @AccountType, @Timestamp, @Amount)) AS Source (UserId, AccountType, Timestamp, Amount)
                ON    (");
                
            if (mergeOnFields == CalculatedAccountBalance.Fields.Empty)
            {
                sql.Append(@"Target.UserId = Source.UserId AND Target.AccountType = Source.AccountType AND Target.Timestamp = Source.Timestamp");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (UserId, AccountType, Timestamp, Amount)
                    VALUES  (Source.UserId, Source.AccountType, Source.Timestamp, Source.Amount);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CalculatedAccountBalance.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CalculatedAccountBalances SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE UserId = @UserId AND AccountType = @AccountType AND Timestamp = @Timestamp");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CalculatedAccountBalance.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("AccountType");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Timestamp");
            }
        
            if (fields.HasFlag(CalculatedAccountBalance.Fields.Amount))
            {
                fieldNames.Add("Amount");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CalculatedAccountBalance entity, 
            CalculatedAccountBalance.Fields fields,
            CalculatedAccountBalance.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            parameters.Add("AccountType", entity.AccountType);
            parameters.Add("Timestamp", entity.Timestamp);
            if (fields.HasFlag(CalculatedAccountBalance.Fields.Amount) && (excludedFields == null || !excludedFields.Value.HasFlag(CalculatedAccountBalance.Fields.Amount)))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CalculatedAccountBalance entity, 
            CalculatedAccountBalance.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            parameters.Add("AccountType", entity.AccountType);
            parameters.Add("Timestamp", entity.Timestamp);
            if (!fields.HasFlag(CalculatedAccountBalance.Fields.Amount))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class CreatorPercentageOverride  : IIdentityEquatable
    {
        public const string Table = "CreatorPercentageOverrides";
        
        public CreatorPercentageOverride(
            System.Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.UserId = userId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CreatorPercentageOverride)other);
        }
        
        protected bool IdentityEquals(CreatorPercentageOverride other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            UserId = 1, 
            Percentage = 2, 
            ExpiryDate = 4
        }
    }

    public static partial class CreatorPercentageOverrideExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CreatorPercentageOverride> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.UserId, entity.Percentage, entity.ExpiryDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorPercentageOverride entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.UserId, entity.Percentage, entity.ExpiryDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorPercentageOverride, CreatorPercentageOverride.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.UserId, entity.Percentage, entity.ExpiryDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorPercentageOverride entity, 
            CreatorPercentageOverride.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CreatorPercentageOverride.Fields.Empty, fields), 
                new 
                {
                    entity.UserId, entity.Percentage, entity.ExpiryDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorPercentageOverride entity, 
            CreatorPercentageOverride.Fields mergeOnFields,
            CreatorPercentageOverride.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.UserId, entity.Percentage, entity.ExpiryDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorPercentageOverride entity, 
            CreatorPercentageOverride.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorPercentageOverride, CreatorPercentageOverride.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CreatorPercentageOverrides(UserId, Percentage, ExpiryDate) VALUES(@UserId, @Percentage, @ExpiryDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CreatorPercentageOverride.Fields mergeOnFields, CreatorPercentageOverride.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CreatorPercentageOverrides WITH (HOLDLOCK) as Target
                USING (VALUES (@UserId, @Percentage, @ExpiryDate)) AS Source (UserId, Percentage, ExpiryDate)
                ON    (");
                
            if (mergeOnFields == CreatorPercentageOverride.Fields.Empty)
            {
                sql.Append(@"Target.UserId = Source.UserId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (UserId, Percentage, ExpiryDate)
                    VALUES  (Source.UserId, Source.Percentage, Source.ExpiryDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CreatorPercentageOverride.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CreatorPercentageOverrides SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE UserId = @UserId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CreatorPercentageOverride.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(CreatorPercentageOverride.Fields.Percentage))
            {
                fieldNames.Add("Percentage");
            }
        
            if (fields.HasFlag(CreatorPercentageOverride.Fields.ExpiryDate))
            {
                fieldNames.Add("ExpiryDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CreatorPercentageOverride entity, 
            CreatorPercentageOverride.Fields fields,
            CreatorPercentageOverride.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            if (fields.HasFlag(CreatorPercentageOverride.Fields.Percentage) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorPercentageOverride.Fields.Percentage)))
            {
                parameters.Add("Percentage", entity.Percentage);
            }
        
            if (fields.HasFlag(CreatorPercentageOverride.Fields.ExpiryDate) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorPercentageOverride.Fields.ExpiryDate)))
            {
                parameters.Add("ExpiryDate", entity.ExpiryDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CreatorPercentageOverride entity, 
            CreatorPercentageOverride.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            if (!fields.HasFlag(CreatorPercentageOverride.Fields.Percentage))
            {
                parameters.Add("Percentage", entity.Percentage);
            }
        
            if (!fields.HasFlag(CreatorPercentageOverride.Fields.ExpiryDate))
            {
                parameters.Add("ExpiryDate", entity.ExpiryDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UncommittedSubscriptionPayment  : IIdentityEquatable
    {
        public const string Table = "UncommittedSubscriptionPayments";
        
        public UncommittedSubscriptionPayment(
            System.Guid subscriberId,
            System.Guid creatorId)
        {
            if (subscriberId == null)
            {
                throw new ArgumentNullException("subscriberId");
            }

            if (creatorId == null)
            {
                throw new ArgumentNullException("creatorId");
            }

            this.SubscriberId = subscriberId;
            this.CreatorId = creatorId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((UncommittedSubscriptionPayment)other);
        }
        
        protected bool IdentityEquals(UncommittedSubscriptionPayment other)
        {
            if (!object.Equals(this.SubscriberId, other.SubscriberId))
            {
                return false;
            }
        
            if (!object.Equals(this.CreatorId, other.CreatorId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            SubscriberId = 1, 
            CreatorId = 2, 
            StartTimestampInclusive = 4, 
            EndTimestampExclusive = 8, 
            Amount = 16, 
            InputDataReference = 32
        }
    }

    public static partial class UncommittedSubscriptionPaymentExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<UncommittedSubscriptionPayment> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.SubscriberId, entity.CreatorId, entity.StartTimestampInclusive, entity.EndTimestampExclusive, entity.Amount, entity.InputDataReference
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            UncommittedSubscriptionPayment entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.SubscriberId, entity.CreatorId, entity.StartTimestampInclusive, entity.EndTimestampExclusive, entity.Amount, entity.InputDataReference
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<UncommittedSubscriptionPayment, UncommittedSubscriptionPayment.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.SubscriberId, entity.CreatorId, entity.StartTimestampInclusive, entity.EndTimestampExclusive, entity.Amount, entity.InputDataReference });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            UncommittedSubscriptionPayment entity, 
            UncommittedSubscriptionPayment.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(UncommittedSubscriptionPayment.Fields.Empty, fields), 
                new 
                {
                    entity.SubscriberId, entity.CreatorId, entity.StartTimestampInclusive, entity.EndTimestampExclusive, entity.Amount, entity.InputDataReference
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            UncommittedSubscriptionPayment entity, 
            UncommittedSubscriptionPayment.Fields mergeOnFields,
            UncommittedSubscriptionPayment.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.SubscriberId, entity.CreatorId, entity.StartTimestampInclusive, entity.EndTimestampExclusive, entity.Amount, entity.InputDataReference
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            UncommittedSubscriptionPayment entity, 
            UncommittedSubscriptionPayment.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<UncommittedSubscriptionPayment, UncommittedSubscriptionPayment.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO UncommittedSubscriptionPayments(SubscriberId, CreatorId, StartTimestampInclusive, EndTimestampExclusive, Amount, InputDataReference) VALUES(@SubscriberId, @CreatorId, @StartTimestampInclusive, @EndTimestampExclusive, @Amount, @InputDataReference)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(UncommittedSubscriptionPayment.Fields mergeOnFields, UncommittedSubscriptionPayment.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE UncommittedSubscriptionPayments WITH (HOLDLOCK) as Target
                USING (VALUES (@SubscriberId, @CreatorId, @StartTimestampInclusive, @EndTimestampExclusive, @Amount, @InputDataReference)) AS Source (SubscriberId, CreatorId, StartTimestampInclusive, EndTimestampExclusive, Amount, InputDataReference)
                ON    (");
                
            if (mergeOnFields == UncommittedSubscriptionPayment.Fields.Empty)
            {
                sql.Append(@"Target.SubscriberId = Source.SubscriberId AND Target.CreatorId = Source.CreatorId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (SubscriberId, CreatorId, StartTimestampInclusive, EndTimestampExclusive, Amount, InputDataReference)
                    VALUES  (Source.SubscriberId, Source.CreatorId, Source.StartTimestampInclusive, Source.EndTimestampExclusive, Source.Amount, Source.InputDataReference);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(UncommittedSubscriptionPayment.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE UncommittedSubscriptionPayments SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE SubscriberId = @SubscriberId AND CreatorId = @CreatorId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(UncommittedSubscriptionPayment.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("SubscriberId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("CreatorId");
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.StartTimestampInclusive))
            {
                fieldNames.Add("StartTimestampInclusive");
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.EndTimestampExclusive))
            {
                fieldNames.Add("EndTimestampExclusive");
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.Amount))
            {
                fieldNames.Add("Amount");
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.InputDataReference))
            {
                fieldNames.Add("InputDataReference");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            UncommittedSubscriptionPayment entity, 
            UncommittedSubscriptionPayment.Fields fields,
            UncommittedSubscriptionPayment.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("SubscriberId", entity.SubscriberId);
            parameters.Add("CreatorId", entity.CreatorId);
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.StartTimestampInclusive) && (excludedFields == null || !excludedFields.Value.HasFlag(UncommittedSubscriptionPayment.Fields.StartTimestampInclusive)))
            {
                parameters.Add("StartTimestampInclusive", entity.StartTimestampInclusive);
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.EndTimestampExclusive) && (excludedFields == null || !excludedFields.Value.HasFlag(UncommittedSubscriptionPayment.Fields.EndTimestampExclusive)))
            {
                parameters.Add("EndTimestampExclusive", entity.EndTimestampExclusive);
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.Amount) && (excludedFields == null || !excludedFields.Value.HasFlag(UncommittedSubscriptionPayment.Fields.Amount)))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            if (fields.HasFlag(UncommittedSubscriptionPayment.Fields.InputDataReference) && (excludedFields == null || !excludedFields.Value.HasFlag(UncommittedSubscriptionPayment.Fields.InputDataReference)))
            {
                parameters.Add("InputDataReference", entity.InputDataReference);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            UncommittedSubscriptionPayment entity, 
            UncommittedSubscriptionPayment.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("SubscriberId", entity.SubscriberId);
            parameters.Add("CreatorId", entity.CreatorId);
            if (!fields.HasFlag(UncommittedSubscriptionPayment.Fields.StartTimestampInclusive))
            {
                parameters.Add("StartTimestampInclusive", entity.StartTimestampInclusive);
            }
        
            if (!fields.HasFlag(UncommittedSubscriptionPayment.Fields.EndTimestampExclusive))
            {
                parameters.Add("EndTimestampExclusive", entity.EndTimestampExclusive);
            }
        
            if (!fields.HasFlag(UncommittedSubscriptionPayment.Fields.Amount))
            {
                parameters.Add("Amount", entity.Amount);
            }
        
            if (!fields.HasFlag(UncommittedSubscriptionPayment.Fields.InputDataReference))
            {
                parameters.Add("InputDataReference", entity.InputDataReference);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Payments
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Api.Persistence.Identity;

    public partial class UserPaymentOrigin  : IIdentityEquatable
    {
        public const string Table = "UserPaymentOrigins";
        
        public UserPaymentOrigin(
            System.Guid userId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.UserId = userId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((UserPaymentOrigin)other);
        }
        
        protected bool IdentityEquals(UserPaymentOrigin other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            UserId = 1, 
            PaymentOriginKey = 2, 
            PaymentOriginKeyType = 4, 
            CountryCode = 8, 
            CreditCardPrefix = 16, 
            IpAddress = 32, 
            OriginalTaxamoTransactionKey = 64, 
            PaymentStatus = 128
        }
    }

    public static partial class UserPaymentOriginExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<UserPaymentOrigin> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.UserId, entity.PaymentOriginKey, entity.PaymentOriginKeyType, entity.CountryCode, entity.CreditCardPrefix, entity.IpAddress, entity.OriginalTaxamoTransactionKey, entity.PaymentStatus
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            UserPaymentOrigin entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.UserId, entity.PaymentOriginKey, entity.PaymentOriginKeyType, entity.CountryCode, entity.CreditCardPrefix, entity.IpAddress, entity.OriginalTaxamoTransactionKey, entity.PaymentStatus
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<UserPaymentOrigin, UserPaymentOrigin.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.UserId, entity.PaymentOriginKey, entity.PaymentOriginKeyType, entity.CountryCode, entity.CreditCardPrefix, entity.IpAddress, entity.OriginalTaxamoTransactionKey, entity.PaymentStatus });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            UserPaymentOrigin entity, 
            UserPaymentOrigin.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(UserPaymentOrigin.Fields.Empty, fields), 
                new 
                {
                    entity.UserId, entity.PaymentOriginKey, entity.PaymentOriginKeyType, entity.CountryCode, entity.CreditCardPrefix, entity.IpAddress, entity.OriginalTaxamoTransactionKey, entity.PaymentStatus
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            UserPaymentOrigin entity, 
            UserPaymentOrigin.Fields mergeOnFields,
            UserPaymentOrigin.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.UserId, entity.PaymentOriginKey, entity.PaymentOriginKeyType, entity.CountryCode, entity.CreditCardPrefix, entity.IpAddress, entity.OriginalTaxamoTransactionKey, entity.PaymentStatus
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            UserPaymentOrigin entity, 
            UserPaymentOrigin.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<UserPaymentOrigin, UserPaymentOrigin.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO UserPaymentOrigins(UserId, PaymentOriginKey, PaymentOriginKeyType, CountryCode, CreditCardPrefix, IpAddress, OriginalTaxamoTransactionKey, PaymentStatus) VALUES(@UserId, @PaymentOriginKey, @PaymentOriginKeyType, @CountryCode, @CreditCardPrefix, @IpAddress, @OriginalTaxamoTransactionKey, @PaymentStatus)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(UserPaymentOrigin.Fields mergeOnFields, UserPaymentOrigin.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE UserPaymentOrigins WITH (HOLDLOCK) as Target
                USING (VALUES (@UserId, @PaymentOriginKey, @PaymentOriginKeyType, @CountryCode, @CreditCardPrefix, @IpAddress, @OriginalTaxamoTransactionKey, @PaymentStatus)) AS Source (UserId, PaymentOriginKey, PaymentOriginKeyType, CountryCode, CreditCardPrefix, IpAddress, OriginalTaxamoTransactionKey, PaymentStatus)
                ON    (");
                
            if (mergeOnFields == UserPaymentOrigin.Fields.Empty)
            {
                sql.Append(@"Target.UserId = Source.UserId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (UserId, PaymentOriginKey, PaymentOriginKeyType, CountryCode, CreditCardPrefix, IpAddress, OriginalTaxamoTransactionKey, PaymentStatus)
                    VALUES  (Source.UserId, Source.PaymentOriginKey, Source.PaymentOriginKeyType, Source.CountryCode, Source.CreditCardPrefix, Source.IpAddress, Source.OriginalTaxamoTransactionKey, Source.PaymentStatus);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(UserPaymentOrigin.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE UserPaymentOrigins SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE UserId = @UserId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(UserPaymentOrigin.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKey))
            {
                fieldNames.Add("PaymentOriginKey");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKeyType))
            {
                fieldNames.Add("PaymentOriginKeyType");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.CountryCode))
            {
                fieldNames.Add("CountryCode");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.CreditCardPrefix))
            {
                fieldNames.Add("CreditCardPrefix");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.IpAddress))
            {
                fieldNames.Add("IpAddress");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.OriginalTaxamoTransactionKey))
            {
                fieldNames.Add("OriginalTaxamoTransactionKey");
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentStatus))
            {
                fieldNames.Add("PaymentStatus");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            UserPaymentOrigin entity, 
            UserPaymentOrigin.Fields fields,
            UserPaymentOrigin.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKey) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKey)))
            {
                parameters.Add("PaymentOriginKey", entity.PaymentOriginKey);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKeyType) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKeyType)))
            {
                parameters.Add("PaymentOriginKeyType", entity.PaymentOriginKeyType);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.CountryCode) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.CountryCode)))
            {
                parameters.Add("CountryCode", entity.CountryCode);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.CreditCardPrefix) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.CreditCardPrefix)))
            {
                parameters.Add("CreditCardPrefix", entity.CreditCardPrefix);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.IpAddress) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.IpAddress)))
            {
                parameters.Add("IpAddress", entity.IpAddress);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.OriginalTaxamoTransactionKey) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.OriginalTaxamoTransactionKey)))
            {
                parameters.Add("OriginalTaxamoTransactionKey", entity.OriginalTaxamoTransactionKey);
            }
        
            if (fields.HasFlag(UserPaymentOrigin.Fields.PaymentStatus) && (excludedFields == null || !excludedFields.Value.HasFlag(UserPaymentOrigin.Fields.PaymentStatus)))
            {
                parameters.Add("PaymentStatus", entity.PaymentStatus);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            UserPaymentOrigin entity, 
            UserPaymentOrigin.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            if (!fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKey))
            {
                parameters.Add("PaymentOriginKey", entity.PaymentOriginKey);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.PaymentOriginKeyType))
            {
                parameters.Add("PaymentOriginKeyType", entity.PaymentOriginKeyType);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.CountryCode))
            {
                parameters.Add("CountryCode", entity.CountryCode);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.CreditCardPrefix))
            {
                parameters.Add("CreditCardPrefix", entity.CreditCardPrefix);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.IpAddress))
            {
                parameters.Add("IpAddress", entity.IpAddress);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.OriginalTaxamoTransactionKey))
            {
                parameters.Add("OriginalTaxamoTransactionKey", entity.OriginalTaxamoTransactionKey);
            }
        
            if (!fields.HasFlag(UserPaymentOrigin.Fields.PaymentStatus))
            {
                parameters.Add("PaymentStatus", entity.PaymentStatus);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class PostFile  : IIdentityEquatable
    {
        public const string Table = "PostFiles";
        
        public PostFile(
            System.Guid postId,
            System.Guid fileId)
        {
            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            if (fileId == null)
            {
                throw new ArgumentNullException("fileId");
            }

            this.PostId = postId;
            this.FileId = fileId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((PostFile)other);
        }
        
        protected bool IdentityEquals(PostFile other)
        {
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            if (!object.Equals(this.FileId, other.FileId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            PostId = 1, 
            FileId = 2
        }
    }

    public static partial class PostFileExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<PostFile> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.PostId, entity.FileId
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            PostFile entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.PostId, entity.FileId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<PostFile, PostFile.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.PostId, entity.FileId });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            PostFile entity, 
            PostFile.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(PostFile.Fields.Empty, fields), 
                new 
                {
                    entity.PostId, entity.FileId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            PostFile entity, 
            PostFile.Fields mergeOnFields,
            PostFile.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.PostId, entity.FileId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            PostFile entity, 
            PostFile.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<PostFile, PostFile.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO PostFiles(PostId, FileId) VALUES(@PostId, @FileId)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(PostFile.Fields mergeOnFields, PostFile.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE PostFiles WITH (HOLDLOCK) as Target
                USING (VALUES (@PostId, @FileId)) AS Source (PostId, FileId)
                ON    (");
                
            if (mergeOnFields == PostFile.Fields.Empty)
            {
                sql.Append(@"Target.PostId = Source.PostId AND Target.FileId = Source.FileId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (PostId, FileId)
                    VALUES  (Source.PostId, Source.FileId);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(PostFile.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE PostFiles SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE PostId = @PostId AND FileId = @FileId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(PostFile.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("PostId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("FileId");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            PostFile entity, 
            PostFile.Fields fields,
            PostFile.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("PostId", entity.PostId);
            parameters.Add("FileId", entity.FileId);
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            PostFile entity, 
            PostFile.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("PostId", entity.PostId);
            parameters.Add("FileId", entity.FileId);
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class RefreshToken  : IIdentityEquatable
    {
        public const string Table = "RefreshTokens";
        
        public RefreshToken(
            System.String username,
            System.String clientId)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            if (clientId == null)
            {
                throw new ArgumentNullException("clientId");
            }

            this.Username = username;
            this.ClientId = clientId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((RefreshToken)other);
        }
        
        protected bool IdentityEquals(RefreshToken other)
        {
            if (!object.Equals(this.Username, other.Username))
            {
                return false;
            }
        
            if (!object.Equals(this.ClientId, other.ClientId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Username = 1, 
            ClientId = 2, 
            EncryptedId = 4, 
            IssuedDate = 8, 
            ExpiresDate = 16, 
            ProtectedTicket = 32
        }
    }

    public static partial class RefreshTokenExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<RefreshToken> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Username, entity.ClientId, entity.EncryptedId, entity.IssuedDate, entity.ExpiresDate, entity.ProtectedTicket
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            RefreshToken entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Username, entity.ClientId, entity.EncryptedId, entity.IssuedDate, entity.ExpiresDate, entity.ProtectedTicket
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<RefreshToken, RefreshToken.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Username, entity.ClientId, entity.EncryptedId, entity.IssuedDate, entity.ExpiresDate, entity.ProtectedTicket });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            RefreshToken entity, 
            RefreshToken.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(RefreshToken.Fields.Empty, fields), 
                new 
                {
                    entity.Username, entity.ClientId, entity.EncryptedId, entity.IssuedDate, entity.ExpiresDate, entity.ProtectedTicket
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            RefreshToken entity, 
            RefreshToken.Fields mergeOnFields,
            RefreshToken.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Username, entity.ClientId, entity.EncryptedId, entity.IssuedDate, entity.ExpiresDate, entity.ProtectedTicket
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            RefreshToken entity, 
            RefreshToken.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<RefreshToken, RefreshToken.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO RefreshTokens(Username, ClientId, EncryptedId, IssuedDate, ExpiresDate, ProtectedTicket) VALUES(@Username, @ClientId, @EncryptedId, @IssuedDate, @ExpiresDate, @ProtectedTicket)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(RefreshToken.Fields mergeOnFields, RefreshToken.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE RefreshTokens WITH (HOLDLOCK) as Target
                USING (VALUES (@Username, @ClientId, @EncryptedId, @IssuedDate, @ExpiresDate, @ProtectedTicket)) AS Source (Username, ClientId, EncryptedId, IssuedDate, ExpiresDate, ProtectedTicket)
                ON    (");
                
            if (mergeOnFields == RefreshToken.Fields.Empty)
            {
                sql.Append(@"Target.Username = Source.Username AND Target.ClientId = Source.ClientId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Username, ClientId, EncryptedId, IssuedDate, ExpiresDate, ProtectedTicket)
                    VALUES  (Source.Username, Source.ClientId, Source.EncryptedId, Source.IssuedDate, Source.ExpiresDate, Source.ProtectedTicket);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(RefreshToken.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE RefreshTokens SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Username = @Username AND ClientId = @ClientId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(RefreshToken.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Username");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("ClientId");
            }
        
            if (fields.HasFlag(RefreshToken.Fields.EncryptedId))
            {
                fieldNames.Add("EncryptedId");
            }
        
            if (fields.HasFlag(RefreshToken.Fields.IssuedDate))
            {
                fieldNames.Add("IssuedDate");
            }
        
            if (fields.HasFlag(RefreshToken.Fields.ExpiresDate))
            {
                fieldNames.Add("ExpiresDate");
            }
        
            if (fields.HasFlag(RefreshToken.Fields.ProtectedTicket))
            {
                fieldNames.Add("ProtectedTicket");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            RefreshToken entity, 
            RefreshToken.Fields fields,
            RefreshToken.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Username", entity.Username);
            parameters.Add("ClientId", entity.ClientId);
            if (fields.HasFlag(RefreshToken.Fields.EncryptedId) && (excludedFields == null || !excludedFields.Value.HasFlag(RefreshToken.Fields.EncryptedId)))
            {
                parameters.Add("EncryptedId", entity.EncryptedId);
            }
        
            if (fields.HasFlag(RefreshToken.Fields.IssuedDate) && (excludedFields == null || !excludedFields.Value.HasFlag(RefreshToken.Fields.IssuedDate)))
            {
                parameters.Add("IssuedDate", entity.IssuedDate);
            }
        
            if (fields.HasFlag(RefreshToken.Fields.ExpiresDate) && (excludedFields == null || !excludedFields.Value.HasFlag(RefreshToken.Fields.ExpiresDate)))
            {
                parameters.Add("ExpiresDate", entity.ExpiresDate);
            }
        
            if (fields.HasFlag(RefreshToken.Fields.ProtectedTicket) && (excludedFields == null || !excludedFields.Value.HasFlag(RefreshToken.Fields.ProtectedTicket)))
            {
                parameters.Add("ProtectedTicket", entity.ProtectedTicket);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            RefreshToken entity, 
            RefreshToken.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Username", entity.Username);
            parameters.Add("ClientId", entity.ClientId);
            if (!fields.HasFlag(RefreshToken.Fields.EncryptedId))
            {
                parameters.Add("EncryptedId", entity.EncryptedId);
            }
        
            if (!fields.HasFlag(RefreshToken.Fields.IssuedDate))
            {
                parameters.Add("IssuedDate", entity.IssuedDate);
            }
        
            if (!fields.HasFlag(RefreshToken.Fields.ExpiresDate))
            {
                parameters.Add("ExpiresDate", entity.ExpiresDate);
            }
        
            if (!fields.HasFlag(RefreshToken.Fields.ProtectedTicket))
            {
                parameters.Add("ProtectedTicket", entity.ProtectedTicket);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshot  : IIdentityEquatable
    {
        public const string Table = "CreatorChannelsSnapshots";
        
        public CreatorChannelsSnapshot(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CreatorChannelsSnapshot)other);
        }
        
        protected bool IdentityEquals(CreatorChannelsSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            Timestamp = 2, 
            CreatorId = 4
        }
    }

    public static partial class CreatorChannelsSnapshotExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CreatorChannelsSnapshot> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshot entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorChannelsSnapshot, CreatorChannelsSnapshot.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.Timestamp, entity.CreatorId });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshot entity, 
            CreatorChannelsSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CreatorChannelsSnapshot.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshot entity, 
            CreatorChannelsSnapshot.Fields mergeOnFields,
            CreatorChannelsSnapshot.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshot entity, 
            CreatorChannelsSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorChannelsSnapshot, CreatorChannelsSnapshot.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CreatorChannelsSnapshots(Id, Timestamp, CreatorId) VALUES(@Id, @Timestamp, @CreatorId)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CreatorChannelsSnapshot.Fields mergeOnFields, CreatorChannelsSnapshot.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CreatorChannelsSnapshots WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @Timestamp, @CreatorId)) AS Source (Id, Timestamp, CreatorId)
                ON    (");
                
            if (mergeOnFields == CreatorChannelsSnapshot.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, Timestamp, CreatorId)
                    VALUES  (Source.Id, Source.Timestamp, Source.CreatorId);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CreatorChannelsSnapshot.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CreatorChannelsSnapshots SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CreatorChannelsSnapshot.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(CreatorChannelsSnapshot.Fields.Timestamp))
            {
                fieldNames.Add("Timestamp");
            }
        
            if (fields.HasFlag(CreatorChannelsSnapshot.Fields.CreatorId))
            {
                fieldNames.Add("CreatorId");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CreatorChannelsSnapshot entity, 
            CreatorChannelsSnapshot.Fields fields,
            CreatorChannelsSnapshot.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(CreatorChannelsSnapshot.Fields.Timestamp) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorChannelsSnapshot.Fields.Timestamp)))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (fields.HasFlag(CreatorChannelsSnapshot.Fields.CreatorId) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorChannelsSnapshot.Fields.CreatorId)))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CreatorChannelsSnapshot entity, 
            CreatorChannelsSnapshot.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(CreatorChannelsSnapshot.Fields.Timestamp))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (!fields.HasFlag(CreatorChannelsSnapshot.Fields.CreatorId))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorChannelsSnapshotItem  : IIdentityEquatable
    {
        public const string Table = "CreatorChannelsSnapshotItems";
        
        public CreatorChannelsSnapshotItem(
            System.Guid creatorChannelsSnapshotId,
            System.Guid channelId)
        {
            if (creatorChannelsSnapshotId == null)
            {
                throw new ArgumentNullException("creatorChannelsSnapshotId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            this.CreatorChannelsSnapshotId = creatorChannelsSnapshotId;
            this.ChannelId = channelId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CreatorChannelsSnapshotItem)other);
        }
        
        protected bool IdentityEquals(CreatorChannelsSnapshotItem other)
        {
            if (!object.Equals(this.CreatorChannelsSnapshotId, other.CreatorChannelsSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            CreatorChannelsSnapshotId = 1, 
            ChannelId = 2, 
            Price = 4
        }
    }

    public static partial class CreatorChannelsSnapshotItemExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CreatorChannelsSnapshotItem> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.CreatorChannelsSnapshotId, entity.ChannelId, entity.Price
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshotItem entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.CreatorChannelsSnapshotId, entity.ChannelId, entity.Price
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorChannelsSnapshotItem, CreatorChannelsSnapshotItem.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.CreatorChannelsSnapshotId, entity.ChannelId, entity.Price });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshotItem entity, 
            CreatorChannelsSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CreatorChannelsSnapshotItem.Fields.Empty, fields), 
                new 
                {
                    entity.CreatorChannelsSnapshotId, entity.ChannelId, entity.Price
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshotItem entity, 
            CreatorChannelsSnapshotItem.Fields mergeOnFields,
            CreatorChannelsSnapshotItem.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.CreatorChannelsSnapshotId, entity.ChannelId, entity.Price
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorChannelsSnapshotItem entity, 
            CreatorChannelsSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorChannelsSnapshotItem, CreatorChannelsSnapshotItem.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CreatorChannelsSnapshotItems(CreatorChannelsSnapshotId, ChannelId, Price) VALUES(@CreatorChannelsSnapshotId, @ChannelId, @Price)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CreatorChannelsSnapshotItem.Fields mergeOnFields, CreatorChannelsSnapshotItem.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CreatorChannelsSnapshotItems WITH (HOLDLOCK) as Target
                USING (VALUES (@CreatorChannelsSnapshotId, @ChannelId, @Price)) AS Source (CreatorChannelsSnapshotId, ChannelId, Price)
                ON    (");
                
            if (mergeOnFields == CreatorChannelsSnapshotItem.Fields.Empty)
            {
                sql.Append(@"Target.CreatorChannelsSnapshotId = Source.CreatorChannelsSnapshotId AND Target.ChannelId = Source.ChannelId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (CreatorChannelsSnapshotId, ChannelId, Price)
                    VALUES  (Source.CreatorChannelsSnapshotId, Source.ChannelId, Source.Price);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CreatorChannelsSnapshotItem.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CreatorChannelsSnapshotItems SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE CreatorChannelsSnapshotId = @CreatorChannelsSnapshotId AND ChannelId = @ChannelId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CreatorChannelsSnapshotItem.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("CreatorChannelsSnapshotId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("ChannelId");
            }
        
            if (fields.HasFlag(CreatorChannelsSnapshotItem.Fields.Price))
            {
                fieldNames.Add("Price");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CreatorChannelsSnapshotItem entity, 
            CreatorChannelsSnapshotItem.Fields fields,
            CreatorChannelsSnapshotItem.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("CreatorChannelsSnapshotId", entity.CreatorChannelsSnapshotId);
            parameters.Add("ChannelId", entity.ChannelId);
            if (fields.HasFlag(CreatorChannelsSnapshotItem.Fields.Price) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorChannelsSnapshotItem.Fields.Price)))
            {
                parameters.Add("Price", entity.Price);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CreatorChannelsSnapshotItem entity, 
            CreatorChannelsSnapshotItem.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("CreatorChannelsSnapshotId", entity.CreatorChannelsSnapshotId);
            parameters.Add("ChannelId", entity.ChannelId);
            if (!fields.HasFlag(CreatorChannelsSnapshotItem.Fields.Price))
            {
                parameters.Add("Price", entity.Price);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshot  : IIdentityEquatable
    {
        public const string Table = "CreatorFreeAccessUsersSnapshots";
        
        public CreatorFreeAccessUsersSnapshot(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CreatorFreeAccessUsersSnapshot)other);
        }
        
        protected bool IdentityEquals(CreatorFreeAccessUsersSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            Timestamp = 2, 
            CreatorId = 4
        }
    }

    public static partial class CreatorFreeAccessUsersSnapshotExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CreatorFreeAccessUsersSnapshot> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshot entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorFreeAccessUsersSnapshot, CreatorFreeAccessUsersSnapshot.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.Timestamp, entity.CreatorId });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshot entity, 
            CreatorFreeAccessUsersSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CreatorFreeAccessUsersSnapshot.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshot entity, 
            CreatorFreeAccessUsersSnapshot.Fields mergeOnFields,
            CreatorFreeAccessUsersSnapshot.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.CreatorId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshot entity, 
            CreatorFreeAccessUsersSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorFreeAccessUsersSnapshot, CreatorFreeAccessUsersSnapshot.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CreatorFreeAccessUsersSnapshots(Id, Timestamp, CreatorId) VALUES(@Id, @Timestamp, @CreatorId)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CreatorFreeAccessUsersSnapshot.Fields mergeOnFields, CreatorFreeAccessUsersSnapshot.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CreatorFreeAccessUsersSnapshots WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @Timestamp, @CreatorId)) AS Source (Id, Timestamp, CreatorId)
                ON    (");
                
            if (mergeOnFields == CreatorFreeAccessUsersSnapshot.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, Timestamp, CreatorId)
                    VALUES  (Source.Id, Source.Timestamp, Source.CreatorId);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CreatorFreeAccessUsersSnapshot.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CreatorFreeAccessUsersSnapshots SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CreatorFreeAccessUsersSnapshot.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.Timestamp))
            {
                fieldNames.Add("Timestamp");
            }
        
            if (fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.CreatorId))
            {
                fieldNames.Add("CreatorId");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CreatorFreeAccessUsersSnapshot entity, 
            CreatorFreeAccessUsersSnapshot.Fields fields,
            CreatorFreeAccessUsersSnapshot.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.Timestamp) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.Timestamp)))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.CreatorId) && (excludedFields == null || !excludedFields.Value.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.CreatorId)))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CreatorFreeAccessUsersSnapshot entity, 
            CreatorFreeAccessUsersSnapshot.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.Timestamp))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (!fields.HasFlag(CreatorFreeAccessUsersSnapshot.Fields.CreatorId))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class CreatorFreeAccessUsersSnapshotItem  : IIdentityEquatable
    {
        public const string Table = "CreatorFreeAccessUsersSnapshotItems";
        
        public CreatorFreeAccessUsersSnapshotItem(
            System.Guid creatorFreeAccessUsersSnapshotId,
            System.String email)
        {
            if (creatorFreeAccessUsersSnapshotId == null)
            {
                throw new ArgumentNullException("creatorFreeAccessUsersSnapshotId");
            }

            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            this.CreatorFreeAccessUsersSnapshotId = creatorFreeAccessUsersSnapshotId;
            this.Email = email;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((CreatorFreeAccessUsersSnapshotItem)other);
        }
        
        protected bool IdentityEquals(CreatorFreeAccessUsersSnapshotItem other)
        {
            if (!object.Equals(this.CreatorFreeAccessUsersSnapshotId, other.CreatorFreeAccessUsersSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.Email, other.Email))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            CreatorFreeAccessUsersSnapshotId = 1, 
            Email = 2
        }
    }

    public static partial class CreatorFreeAccessUsersSnapshotItemExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<CreatorFreeAccessUsersSnapshotItem> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.CreatorFreeAccessUsersSnapshotId, entity.Email
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshotItem entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.CreatorFreeAccessUsersSnapshotId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorFreeAccessUsersSnapshotItem, CreatorFreeAccessUsersSnapshotItem.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.CreatorFreeAccessUsersSnapshotId, entity.Email });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshotItem entity, 
            CreatorFreeAccessUsersSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(CreatorFreeAccessUsersSnapshotItem.Fields.Empty, fields), 
                new 
                {
                    entity.CreatorFreeAccessUsersSnapshotId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshotItem entity, 
            CreatorFreeAccessUsersSnapshotItem.Fields mergeOnFields,
            CreatorFreeAccessUsersSnapshotItem.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.CreatorFreeAccessUsersSnapshotId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            CreatorFreeAccessUsersSnapshotItem entity, 
            CreatorFreeAccessUsersSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<CreatorFreeAccessUsersSnapshotItem, CreatorFreeAccessUsersSnapshotItem.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO CreatorFreeAccessUsersSnapshotItems(CreatorFreeAccessUsersSnapshotId, Email) VALUES(@CreatorFreeAccessUsersSnapshotId, @Email)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(CreatorFreeAccessUsersSnapshotItem.Fields mergeOnFields, CreatorFreeAccessUsersSnapshotItem.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE CreatorFreeAccessUsersSnapshotItems WITH (HOLDLOCK) as Target
                USING (VALUES (@CreatorFreeAccessUsersSnapshotId, @Email)) AS Source (CreatorFreeAccessUsersSnapshotId, Email)
                ON    (");
                
            if (mergeOnFields == CreatorFreeAccessUsersSnapshotItem.Fields.Empty)
            {
                sql.Append(@"Target.CreatorFreeAccessUsersSnapshotId = Source.CreatorFreeAccessUsersSnapshotId AND Target.Email = Source.Email");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (CreatorFreeAccessUsersSnapshotId, Email)
                    VALUES  (Source.CreatorFreeAccessUsersSnapshotId, Source.Email);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(CreatorFreeAccessUsersSnapshotItem.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE CreatorFreeAccessUsersSnapshotItems SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE CreatorFreeAccessUsersSnapshotId = @CreatorFreeAccessUsersSnapshotId AND Email = @Email");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(CreatorFreeAccessUsersSnapshotItem.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("CreatorFreeAccessUsersSnapshotId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Email");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            CreatorFreeAccessUsersSnapshotItem entity, 
            CreatorFreeAccessUsersSnapshotItem.Fields fields,
            CreatorFreeAccessUsersSnapshotItem.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("CreatorFreeAccessUsersSnapshotId", entity.CreatorFreeAccessUsersSnapshotId);
            parameters.Add("Email", entity.Email);
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            CreatorFreeAccessUsersSnapshotItem entity, 
            CreatorFreeAccessUsersSnapshotItem.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("CreatorFreeAccessUsersSnapshotId", entity.CreatorFreeAccessUsersSnapshotId);
            parameters.Add("Email", entity.Email);
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshot  : IIdentityEquatable
    {
        public const string Table = "SubscriberChannelsSnapshots";
        
        public SubscriberChannelsSnapshot(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((SubscriberChannelsSnapshot)other);
        }
        
        protected bool IdentityEquals(SubscriberChannelsSnapshot other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            Timestamp = 2, 
            SubscriberId = 4
        }
    }

    public static partial class SubscriberChannelsSnapshotExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<SubscriberChannelsSnapshot> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.Timestamp, entity.SubscriberId
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshot entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.SubscriberId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberChannelsSnapshot, SubscriberChannelsSnapshot.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.Timestamp, entity.SubscriberId });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshot entity, 
            SubscriberChannelsSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(SubscriberChannelsSnapshot.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.SubscriberId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshot entity, 
            SubscriberChannelsSnapshot.Fields mergeOnFields,
            SubscriberChannelsSnapshot.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.Timestamp, entity.SubscriberId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshot entity, 
            SubscriberChannelsSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberChannelsSnapshot, SubscriberChannelsSnapshot.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO SubscriberChannelsSnapshots(Id, Timestamp, SubscriberId) VALUES(@Id, @Timestamp, @SubscriberId)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(SubscriberChannelsSnapshot.Fields mergeOnFields, SubscriberChannelsSnapshot.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE SubscriberChannelsSnapshots WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @Timestamp, @SubscriberId)) AS Source (Id, Timestamp, SubscriberId)
                ON    (");
                
            if (mergeOnFields == SubscriberChannelsSnapshot.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, Timestamp, SubscriberId)
                    VALUES  (Source.Id, Source.Timestamp, Source.SubscriberId);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(SubscriberChannelsSnapshot.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE SubscriberChannelsSnapshots SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(SubscriberChannelsSnapshot.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshot.Fields.Timestamp))
            {
                fieldNames.Add("Timestamp");
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshot.Fields.SubscriberId))
            {
                fieldNames.Add("SubscriberId");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            SubscriberChannelsSnapshot entity, 
            SubscriberChannelsSnapshot.Fields fields,
            SubscriberChannelsSnapshot.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(SubscriberChannelsSnapshot.Fields.Timestamp) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberChannelsSnapshot.Fields.Timestamp)))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshot.Fields.SubscriberId) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberChannelsSnapshot.Fields.SubscriberId)))
            {
                parameters.Add("SubscriberId", entity.SubscriberId);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            SubscriberChannelsSnapshot entity, 
            SubscriberChannelsSnapshot.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(SubscriberChannelsSnapshot.Fields.Timestamp))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            if (!fields.HasFlag(SubscriberChannelsSnapshot.Fields.SubscriberId))
            {
                parameters.Add("SubscriberId", entity.SubscriberId);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberChannelsSnapshotItem  : IIdentityEquatable
    {
        public const string Table = "SubscriberChannelsSnapshotItems";
        
        public SubscriberChannelsSnapshotItem(
            System.Guid subscriberChannelsSnapshotId,
            System.Guid channelId)
        {
            if (subscriberChannelsSnapshotId == null)
            {
                throw new ArgumentNullException("subscriberChannelsSnapshotId");
            }

            if (channelId == null)
            {
                throw new ArgumentNullException("channelId");
            }

            this.SubscriberChannelsSnapshotId = subscriberChannelsSnapshotId;
            this.ChannelId = channelId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((SubscriberChannelsSnapshotItem)other);
        }
        
        protected bool IdentityEquals(SubscriberChannelsSnapshotItem other)
        {
            if (!object.Equals(this.SubscriberChannelsSnapshotId, other.SubscriberChannelsSnapshotId))
            {
                return false;
            }
        
            if (!object.Equals(this.ChannelId, other.ChannelId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            SubscriberChannelsSnapshotId = 1, 
            ChannelId = 2, 
            CreatorId = 4, 
            AcceptedPrice = 8, 
            SubscriptionStartDate = 16
        }
    }

    public static partial class SubscriberChannelsSnapshotItemExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<SubscriberChannelsSnapshotItem> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.SubscriberChannelsSnapshotId, entity.ChannelId, entity.CreatorId, entity.AcceptedPrice, entity.SubscriptionStartDate
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshotItem entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.SubscriberChannelsSnapshotId, entity.ChannelId, entity.CreatorId, entity.AcceptedPrice, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberChannelsSnapshotItem, SubscriberChannelsSnapshotItem.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.SubscriberChannelsSnapshotId, entity.ChannelId, entity.CreatorId, entity.AcceptedPrice, entity.SubscriptionStartDate });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshotItem entity, 
            SubscriberChannelsSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(SubscriberChannelsSnapshotItem.Fields.Empty, fields), 
                new 
                {
                    entity.SubscriberChannelsSnapshotId, entity.ChannelId, entity.CreatorId, entity.AcceptedPrice, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshotItem entity, 
            SubscriberChannelsSnapshotItem.Fields mergeOnFields,
            SubscriberChannelsSnapshotItem.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.SubscriberChannelsSnapshotId, entity.ChannelId, entity.CreatorId, entity.AcceptedPrice, entity.SubscriptionStartDate
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberChannelsSnapshotItem entity, 
            SubscriberChannelsSnapshotItem.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberChannelsSnapshotItem, SubscriberChannelsSnapshotItem.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO SubscriberChannelsSnapshotItems(SubscriberChannelsSnapshotId, ChannelId, CreatorId, AcceptedPrice, SubscriptionStartDate) VALUES(@SubscriberChannelsSnapshotId, @ChannelId, @CreatorId, @AcceptedPrice, @SubscriptionStartDate)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(SubscriberChannelsSnapshotItem.Fields mergeOnFields, SubscriberChannelsSnapshotItem.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE SubscriberChannelsSnapshotItems WITH (HOLDLOCK) as Target
                USING (VALUES (@SubscriberChannelsSnapshotId, @ChannelId, @CreatorId, @AcceptedPrice, @SubscriptionStartDate)) AS Source (SubscriberChannelsSnapshotId, ChannelId, CreatorId, AcceptedPrice, SubscriptionStartDate)
                ON    (");
                
            if (mergeOnFields == SubscriberChannelsSnapshotItem.Fields.Empty)
            {
                sql.Append(@"Target.SubscriberChannelsSnapshotId = Source.SubscriberChannelsSnapshotId AND Target.ChannelId = Source.ChannelId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (SubscriberChannelsSnapshotId, ChannelId, CreatorId, AcceptedPrice, SubscriptionStartDate)
                    VALUES  (Source.SubscriberChannelsSnapshotId, Source.ChannelId, Source.CreatorId, Source.AcceptedPrice, Source.SubscriptionStartDate);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(SubscriberChannelsSnapshotItem.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE SubscriberChannelsSnapshotItems SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE SubscriberChannelsSnapshotId = @SubscriberChannelsSnapshotId AND ChannelId = @ChannelId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(SubscriberChannelsSnapshotItem.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("SubscriberChannelsSnapshotId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("ChannelId");
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.CreatorId))
            {
                fieldNames.Add("CreatorId");
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.AcceptedPrice))
            {
                fieldNames.Add("AcceptedPrice");
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.SubscriptionStartDate))
            {
                fieldNames.Add("SubscriptionStartDate");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            SubscriberChannelsSnapshotItem entity, 
            SubscriberChannelsSnapshotItem.Fields fields,
            SubscriberChannelsSnapshotItem.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("SubscriberChannelsSnapshotId", entity.SubscriberChannelsSnapshotId);
            parameters.Add("ChannelId", entity.ChannelId);
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.CreatorId) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberChannelsSnapshotItem.Fields.CreatorId)))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.AcceptedPrice) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberChannelsSnapshotItem.Fields.AcceptedPrice)))
            {
                parameters.Add("AcceptedPrice", entity.AcceptedPrice);
            }
        
            if (fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.SubscriptionStartDate) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberChannelsSnapshotItem.Fields.SubscriptionStartDate)))
            {
                parameters.Add("SubscriptionStartDate", entity.SubscriptionStartDate);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            SubscriberChannelsSnapshotItem entity, 
            SubscriberChannelsSnapshotItem.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("SubscriberChannelsSnapshotId", entity.SubscriberChannelsSnapshotId);
            parameters.Add("ChannelId", entity.ChannelId);
            if (!fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.CreatorId))
            {
                parameters.Add("CreatorId", entity.CreatorId);
            }
        
            if (!fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.AcceptedPrice))
            {
                parameters.Add("AcceptedPrice", entity.AcceptedPrice);
            }
        
            if (!fields.HasFlag(SubscriberChannelsSnapshotItem.Fields.SubscriptionStartDate))
            {
                parameters.Add("SubscriptionStartDate", entity.SubscriptionStartDate);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Snapshots
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.CodeGeneration;

    public partial class SubscriberSnapshot  : IIdentityEquatable
    {
        public const string Table = "SubscriberSnapshots";
        
        public SubscriberSnapshot(
            System.DateTime timestamp,
            System.Guid subscriberId)
        {
            if (timestamp == null)
            {
                throw new ArgumentNullException("timestamp");
            }

            if (subscriberId == null)
            {
                throw new ArgumentNullException("subscriberId");
            }

            this.Timestamp = timestamp;
            this.SubscriberId = subscriberId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((SubscriberSnapshot)other);
        }
        
        protected bool IdentityEquals(SubscriberSnapshot other)
        {
            if (!object.Equals(this.Timestamp, other.Timestamp))
            {
                return false;
            }
        
            if (!object.Equals(this.SubscriberId, other.SubscriberId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Timestamp = 1, 
            SubscriberId = 2, 
            Email = 4
        }
    }

    public static partial class SubscriberSnapshotExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<SubscriberSnapshot> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Timestamp, entity.SubscriberId, entity.Email
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberSnapshot entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Timestamp, entity.SubscriberId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberSnapshot, SubscriberSnapshot.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Timestamp, entity.SubscriberId, entity.Email });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberSnapshot entity, 
            SubscriberSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(SubscriberSnapshot.Fields.Empty, fields), 
                new 
                {
                    entity.Timestamp, entity.SubscriberId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberSnapshot entity, 
            SubscriberSnapshot.Fields mergeOnFields,
            SubscriberSnapshot.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Timestamp, entity.SubscriberId, entity.Email
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            SubscriberSnapshot entity, 
            SubscriberSnapshot.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<SubscriberSnapshot, SubscriberSnapshot.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO SubscriberSnapshots(Timestamp, SubscriberId, Email) VALUES(@Timestamp, @SubscriberId, @Email)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(SubscriberSnapshot.Fields mergeOnFields, SubscriberSnapshot.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE SubscriberSnapshots WITH (HOLDLOCK) as Target
                USING (VALUES (@Timestamp, @SubscriberId, @Email)) AS Source (Timestamp, SubscriberId, Email)
                ON    (");
                
            if (mergeOnFields == SubscriberSnapshot.Fields.Empty)
            {
                sql.Append(@"Target.Timestamp = Source.Timestamp AND Target.SubscriberId = Source.SubscriberId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Timestamp, SubscriberId, Email)
                    VALUES  (Source.Timestamp, Source.SubscriberId, Source.Email);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(SubscriberSnapshot.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE SubscriberSnapshots SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Timestamp = @Timestamp AND SubscriberId = @SubscriberId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(SubscriberSnapshot.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Timestamp");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("SubscriberId");
            }
        
            if (fields.HasFlag(SubscriberSnapshot.Fields.Email))
            {
                fieldNames.Add("Email");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            SubscriberSnapshot entity, 
            SubscriberSnapshot.Fields fields,
            SubscriberSnapshot.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Timestamp", entity.Timestamp);
            parameters.Add("SubscriberId", entity.SubscriberId);
            if (fields.HasFlag(SubscriberSnapshot.Fields.Email) && (excludedFields == null || !excludedFields.Value.HasFlag(SubscriberSnapshot.Fields.Email)))
            {
                parameters.Add("Email", entity.Email);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            SubscriberSnapshot entity, 
            SubscriberSnapshot.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Timestamp", entity.Timestamp);
            parameters.Add("SubscriberId", entity.SubscriberId);
            if (!fields.HasFlag(SubscriberSnapshot.Fields.Email))
            {
                parameters.Add("Email", entity.Email);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class WeeklyReleaseTime  : IIdentityEquatable
    {
        public const string Table = "WeeklyReleaseTimes";
        
        public WeeklyReleaseTime(
            System.Guid queueId,
            System.Byte hourOfWeek)
        {
            if (queueId == null)
            {
                throw new ArgumentNullException("queueId");
            }

            if (hourOfWeek == null)
            {
                throw new ArgumentNullException("hourOfWeek");
            }

            this.QueueId = queueId;
            this.HourOfWeek = hourOfWeek;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((WeeklyReleaseTime)other);
        }
        
        protected bool IdentityEquals(WeeklyReleaseTime other)
        {
            if (!object.Equals(this.QueueId, other.QueueId))
            {
                return false;
            }
        
            if (!object.Equals(this.HourOfWeek, other.HourOfWeek))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            QueueId = 1, 
            HourOfWeek = 2
        }
    }

    public static partial class WeeklyReleaseTimeExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<WeeklyReleaseTime> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.QueueId, entity.HourOfWeek
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            WeeklyReleaseTime entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.QueueId, entity.HourOfWeek
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<WeeklyReleaseTime, WeeklyReleaseTime.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.QueueId, entity.HourOfWeek });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            WeeklyReleaseTime entity, 
            WeeklyReleaseTime.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(WeeklyReleaseTime.Fields.Empty, fields), 
                new 
                {
                    entity.QueueId, entity.HourOfWeek
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            WeeklyReleaseTime entity, 
            WeeklyReleaseTime.Fields mergeOnFields,
            WeeklyReleaseTime.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.QueueId, entity.HourOfWeek
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            WeeklyReleaseTime entity, 
            WeeklyReleaseTime.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<WeeklyReleaseTime, WeeklyReleaseTime.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO WeeklyReleaseTimes(QueueId, HourOfWeek) VALUES(@QueueId, @HourOfWeek)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(WeeklyReleaseTime.Fields mergeOnFields, WeeklyReleaseTime.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE WeeklyReleaseTimes WITH (HOLDLOCK) as Target
                USING (VALUES (@QueueId, @HourOfWeek)) AS Source (QueueId, HourOfWeek)
                ON    (");
                
            if (mergeOnFields == WeeklyReleaseTime.Fields.Empty)
            {
                sql.Append(@"Target.QueueId = Source.QueueId AND Target.HourOfWeek = Source.HourOfWeek");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (QueueId, HourOfWeek)
                    VALUES  (Source.QueueId, Source.HourOfWeek);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(WeeklyReleaseTime.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE WeeklyReleaseTimes SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE QueueId = @QueueId AND HourOfWeek = @HourOfWeek");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(WeeklyReleaseTime.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("QueueId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("HourOfWeek");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            WeeklyReleaseTime entity, 
            WeeklyReleaseTime.Fields fields,
            WeeklyReleaseTime.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("QueueId", entity.QueueId);
            parameters.Add("HourOfWeek", entity.HourOfWeek);
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            WeeklyReleaseTime entity, 
            WeeklyReleaseTime.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("QueueId", entity.QueueId);
            parameters.Add("HourOfWeek", entity.HourOfWeek);
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.CodeGeneration;

    public partial class FreePost  : IIdentityEquatable
    {
        public const string Table = "FreePosts";
        
        public FreePost(
            System.Guid userId,
            System.Guid postId)
        {
            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (postId == null)
            {
                throw new ArgumentNullException("postId");
            }

            this.UserId = userId;
            this.PostId = postId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((FreePost)other);
        }
        
        protected bool IdentityEquals(FreePost other)
        {
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.PostId, other.PostId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            UserId = 1, 
            PostId = 2, 
            Timestamp = 4
        }
    }

    public static partial class FreePostExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<FreePost> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.UserId, entity.PostId, entity.Timestamp
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreePost entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.UserId, entity.PostId, entity.Timestamp
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FreePost, FreePost.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.UserId, entity.PostId, entity.Timestamp });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreePost entity, 
            FreePost.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(FreePost.Fields.Empty, fields), 
                new 
                {
                    entity.UserId, entity.PostId, entity.Timestamp
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FreePost entity, 
            FreePost.Fields mergeOnFields,
            FreePost.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.UserId, entity.PostId, entity.Timestamp
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            FreePost entity, 
            FreePost.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FreePost, FreePost.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO FreePosts(UserId, PostId, Timestamp) VALUES(@UserId, @PostId, @Timestamp)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(FreePost.Fields mergeOnFields, FreePost.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE FreePosts WITH (HOLDLOCK) as Target
                USING (VALUES (@UserId, @PostId, @Timestamp)) AS Source (UserId, PostId, Timestamp)
                ON    (");
                
            if (mergeOnFields == FreePost.Fields.Empty)
            {
                sql.Append(@"Target.UserId = Source.UserId AND Target.PostId = Source.PostId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (UserId, PostId, Timestamp)
                    VALUES  (Source.UserId, Source.PostId, Source.Timestamp);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(FreePost.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE FreePosts SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE UserId = @UserId AND PostId = @PostId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(FreePost.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("PostId");
            }
        
            if (fields.HasFlag(FreePost.Fields.Timestamp))
            {
                fieldNames.Add("Timestamp");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            FreePost entity, 
            FreePost.Fields fields,
            FreePost.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            parameters.Add("PostId", entity.PostId);
            if (fields.HasFlag(FreePost.Fields.Timestamp) && (excludedFields == null || !excludedFields.Value.HasFlag(FreePost.Fields.Timestamp)))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            FreePost entity, 
            FreePost.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("UserId", entity.UserId);
            parameters.Add("PostId", entity.PostId);
            if (!fields.HasFlag(FreePost.Fields.Timestamp))
            {
                parameters.Add("Timestamp", entity.Timestamp);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekRole  : IIdentityEquatable
    {
        public const string Table = "AspNetRoles";
        
        public FifthweekRole(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((FifthweekRole)other);
        }
        
        protected bool IdentityEquals(FifthweekRole other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            Id = 1, 
            Name = 2
        }
    }

    public static partial class FifthweekRoleExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<FifthweekRole> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.Id, entity.Name
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekRole entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.Id, entity.Name
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekRole, FifthweekRole.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.Id, entity.Name });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekRole entity, 
            FifthweekRole.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(FifthweekRole.Fields.Empty, fields), 
                new 
                {
                    entity.Id, entity.Name
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekRole entity, 
            FifthweekRole.Fields mergeOnFields,
            FifthweekRole.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.Id, entity.Name
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekRole entity, 
            FifthweekRole.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekRole, FifthweekRole.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO AspNetRoles(Id, Name) VALUES(@Id, @Name)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(FifthweekRole.Fields mergeOnFields, FifthweekRole.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE AspNetRoles WITH (HOLDLOCK) as Target
                USING (VALUES (@Id, @Name)) AS Source (Id, Name)
                ON    (");
                
            if (mergeOnFields == FifthweekRole.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (Id, Name)
                    VALUES  (Source.Id, Source.Name);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(FifthweekRole.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE AspNetRoles SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(FifthweekRole.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(FifthweekRole.Fields.Name))
            {
                fieldNames.Add("Name");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            FifthweekRole entity, 
            FifthweekRole.Fields fields,
            FifthweekRole.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(FifthweekRole.Fields.Name) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekRole.Fields.Name)))
            {
                parameters.Add("Name", entity.Name);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            FifthweekRole entity, 
            FifthweekRole.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(FifthweekRole.Fields.Name))
            {
                parameters.Add("Name", entity.Name);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekUser  : IIdentityEquatable
    {
        public const string Table = "AspNetUsers";
        
        public FifthweekUser(
            System.Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            this.Id = id;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((FifthweekUser)other);
        }
        
        protected bool IdentityEquals(FifthweekUser other)
        {
            if (!object.Equals(this.Id, other.Id))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            ExampleWork = 1, 
            RegistrationDate = 2, 
            LastSignInDate = 4, 
            LastAccessTokenDate = 8, 
            ProfileImageFileId = 16, 
            Email = 32, 
            Name = 64, 
            Id = 128, 
            AccessFailedCount = 256, 
            EmailConfirmed = 512, 
            LockoutEnabled = 1024, 
            LockoutEndDateUtc = 2048, 
            PasswordHash = 4096, 
            PhoneNumber = 8192, 
            PhoneNumberConfirmed = 16384, 
            SecurityStamp = 32768, 
            TwoFactorEnabled = 65536, 
            UserName = 131072
        }
    }

    public static partial class FifthweekUserExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<FifthweekUser> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.ExampleWork, entity.RegistrationDate, entity.LastSignInDate, entity.LastAccessTokenDate, entity.ProfileImageFileId, entity.Email, entity.Name, entity.Id, entity.AccessFailedCount, entity.EmailConfirmed, entity.LockoutEnabled, entity.LockoutEndDateUtc, entity.PasswordHash, entity.PhoneNumber, entity.PhoneNumberConfirmed, entity.SecurityStamp, entity.TwoFactorEnabled, entity.UserName
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUser entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.ExampleWork, entity.RegistrationDate, entity.LastSignInDate, entity.LastAccessTokenDate, entity.ProfileImageFileId, entity.Email, entity.Name, entity.Id, entity.AccessFailedCount, entity.EmailConfirmed, entity.LockoutEnabled, entity.LockoutEndDateUtc, entity.PasswordHash, entity.PhoneNumber, entity.PhoneNumberConfirmed, entity.SecurityStamp, entity.TwoFactorEnabled, entity.UserName
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekUser, FifthweekUser.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.ExampleWork, entity.RegistrationDate, entity.LastSignInDate, entity.LastAccessTokenDate, entity.ProfileImageFileId, entity.Email, entity.Name, entity.Id, entity.AccessFailedCount, entity.EmailConfirmed, entity.LockoutEnabled, entity.LockoutEndDateUtc, entity.PasswordHash, entity.PhoneNumber, entity.PhoneNumberConfirmed, entity.SecurityStamp, entity.TwoFactorEnabled, entity.UserName });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUser entity, 
            FifthweekUser.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(FifthweekUser.Fields.Empty, fields), 
                new 
                {
                    entity.ExampleWork, entity.RegistrationDate, entity.LastSignInDate, entity.LastAccessTokenDate, entity.ProfileImageFileId, entity.Email, entity.Name, entity.Id, entity.AccessFailedCount, entity.EmailConfirmed, entity.LockoutEnabled, entity.LockoutEndDateUtc, entity.PasswordHash, entity.PhoneNumber, entity.PhoneNumberConfirmed, entity.SecurityStamp, entity.TwoFactorEnabled, entity.UserName
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUser entity, 
            FifthweekUser.Fields mergeOnFields,
            FifthweekUser.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.ExampleWork, entity.RegistrationDate, entity.LastSignInDate, entity.LastAccessTokenDate, entity.ProfileImageFileId, entity.Email, entity.Name, entity.Id, entity.AccessFailedCount, entity.EmailConfirmed, entity.LockoutEnabled, entity.LockoutEndDateUtc, entity.PasswordHash, entity.PhoneNumber, entity.PhoneNumberConfirmed, entity.SecurityStamp, entity.TwoFactorEnabled, entity.UserName
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUser entity, 
            FifthweekUser.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekUser, FifthweekUser.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO AspNetUsers(ExampleWork, RegistrationDate, LastSignInDate, LastAccessTokenDate, ProfileImageFileId, Email, Name, Id, AccessFailedCount, EmailConfirmed, LockoutEnabled, LockoutEndDateUtc, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName) VALUES(@ExampleWork, @RegistrationDate, @LastSignInDate, @LastAccessTokenDate, @ProfileImageFileId, @Email, @Name, @Id, @AccessFailedCount, @EmailConfirmed, @LockoutEnabled, @LockoutEndDateUtc, @PasswordHash, @PhoneNumber, @PhoneNumberConfirmed, @SecurityStamp, @TwoFactorEnabled, @UserName)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(FifthweekUser.Fields mergeOnFields, FifthweekUser.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE AspNetUsers WITH (HOLDLOCK) as Target
                USING (VALUES (@ExampleWork, @RegistrationDate, @LastSignInDate, @LastAccessTokenDate, @ProfileImageFileId, @Email, @Name, @Id, @AccessFailedCount, @EmailConfirmed, @LockoutEnabled, @LockoutEndDateUtc, @PasswordHash, @PhoneNumber, @PhoneNumberConfirmed, @SecurityStamp, @TwoFactorEnabled, @UserName)) AS Source (ExampleWork, RegistrationDate, LastSignInDate, LastAccessTokenDate, ProfileImageFileId, Email, Name, Id, AccessFailedCount, EmailConfirmed, LockoutEnabled, LockoutEndDateUtc, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName)
                ON    (");
                
            if (mergeOnFields == FifthweekUser.Fields.Empty)
            {
                sql.Append(@"Target.Id = Source.Id");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (ExampleWork, RegistrationDate, LastSignInDate, LastAccessTokenDate, ProfileImageFileId, Email, Name, Id, AccessFailedCount, EmailConfirmed, LockoutEnabled, LockoutEndDateUtc, PasswordHash, PhoneNumber, PhoneNumberConfirmed, SecurityStamp, TwoFactorEnabled, UserName)
                    VALUES  (Source.ExampleWork, Source.RegistrationDate, Source.LastSignInDate, Source.LastAccessTokenDate, Source.ProfileImageFileId, Source.Email, Source.Name, Source.Id, Source.AccessFailedCount, Source.EmailConfirmed, Source.LockoutEnabled, Source.LockoutEndDateUtc, Source.PasswordHash, Source.PhoneNumber, Source.PhoneNumberConfirmed, Source.SecurityStamp, Source.TwoFactorEnabled, Source.UserName);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(FifthweekUser.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE AspNetUsers SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE Id = @Id");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(FifthweekUser.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (fields.HasFlag(FifthweekUser.Fields.ExampleWork))
            {
                fieldNames.Add("ExampleWork");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.RegistrationDate))
            {
                fieldNames.Add("RegistrationDate");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LastSignInDate))
            {
                fieldNames.Add("LastSignInDate");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LastAccessTokenDate))
            {
                fieldNames.Add("LastAccessTokenDate");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.ProfileImageFileId))
            {
                fieldNames.Add("ProfileImageFileId");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.Email))
            {
                fieldNames.Add("Email");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.Name))
            {
                fieldNames.Add("Name");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("Id");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.AccessFailedCount))
            {
                fieldNames.Add("AccessFailedCount");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.EmailConfirmed))
            {
                fieldNames.Add("EmailConfirmed");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LockoutEnabled))
            {
                fieldNames.Add("LockoutEnabled");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LockoutEndDateUtc))
            {
                fieldNames.Add("LockoutEndDateUtc");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PasswordHash))
            {
                fieldNames.Add("PasswordHash");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PhoneNumber))
            {
                fieldNames.Add("PhoneNumber");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PhoneNumberConfirmed))
            {
                fieldNames.Add("PhoneNumberConfirmed");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.SecurityStamp))
            {
                fieldNames.Add("SecurityStamp");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.TwoFactorEnabled))
            {
                fieldNames.Add("TwoFactorEnabled");
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.UserName))
            {
                fieldNames.Add("UserName");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            FifthweekUser entity, 
            FifthweekUser.Fields fields,
            FifthweekUser.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            if (fields.HasFlag(FifthweekUser.Fields.ExampleWork) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.ExampleWork)))
            {
                parameters.Add("ExampleWork", entity.ExampleWork);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.RegistrationDate) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.RegistrationDate)))
            {
                parameters.Add("RegistrationDate", entity.RegistrationDate);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LastSignInDate) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.LastSignInDate)))
            {
                parameters.Add("LastSignInDate", entity.LastSignInDate);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LastAccessTokenDate) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.LastAccessTokenDate)))
            {
                parameters.Add("LastAccessTokenDate", entity.LastAccessTokenDate);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.ProfileImageFileId) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.ProfileImageFileId)))
            {
                parameters.Add("ProfileImageFileId", entity.ProfileImageFileId);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.Email) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.Email)))
            {
                parameters.Add("Email", entity.Email);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.Name) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.Name)))
            {
                parameters.Add("Name", entity.Name);
            }
        
            parameters.Add("Id", entity.Id);
            if (fields.HasFlag(FifthweekUser.Fields.AccessFailedCount) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.AccessFailedCount)))
            {
                parameters.Add("AccessFailedCount", entity.AccessFailedCount);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.EmailConfirmed) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.EmailConfirmed)))
            {
                parameters.Add("EmailConfirmed", entity.EmailConfirmed);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LockoutEnabled) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.LockoutEnabled)))
            {
                parameters.Add("LockoutEnabled", entity.LockoutEnabled);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.LockoutEndDateUtc) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.LockoutEndDateUtc)))
            {
                parameters.Add("LockoutEndDateUtc", entity.LockoutEndDateUtc);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PasswordHash) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.PasswordHash)))
            {
                parameters.Add("PasswordHash", entity.PasswordHash);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PhoneNumber) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.PhoneNumber)))
            {
                parameters.Add("PhoneNumber", entity.PhoneNumber);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.PhoneNumberConfirmed) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.PhoneNumberConfirmed)))
            {
                parameters.Add("PhoneNumberConfirmed", entity.PhoneNumberConfirmed);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.SecurityStamp) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.SecurityStamp)))
            {
                parameters.Add("SecurityStamp", entity.SecurityStamp);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.TwoFactorEnabled) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.TwoFactorEnabled)))
            {
                parameters.Add("TwoFactorEnabled", entity.TwoFactorEnabled);
            }
        
            if (fields.HasFlag(FifthweekUser.Fields.UserName) && (excludedFields == null || !excludedFields.Value.HasFlag(FifthweekUser.Fields.UserName)))
            {
                parameters.Add("UserName", entity.UserName);
            }
        
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            FifthweekUser entity, 
            FifthweekUser.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            if (!fields.HasFlag(FifthweekUser.Fields.ExampleWork))
            {
                parameters.Add("ExampleWork", entity.ExampleWork);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.RegistrationDate))
            {
                parameters.Add("RegistrationDate", entity.RegistrationDate);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.LastSignInDate))
            {
                parameters.Add("LastSignInDate", entity.LastSignInDate);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.LastAccessTokenDate))
            {
                parameters.Add("LastAccessTokenDate", entity.LastAccessTokenDate);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.ProfileImageFileId))
            {
                parameters.Add("ProfileImageFileId", entity.ProfileImageFileId);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.Email))
            {
                parameters.Add("Email", entity.Email);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.Name))
            {
                parameters.Add("Name", entity.Name);
            }
        
            parameters.Add("Id", entity.Id);
            if (!fields.HasFlag(FifthweekUser.Fields.AccessFailedCount))
            {
                parameters.Add("AccessFailedCount", entity.AccessFailedCount);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.EmailConfirmed))
            {
                parameters.Add("EmailConfirmed", entity.EmailConfirmed);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.LockoutEnabled))
            {
                parameters.Add("LockoutEnabled", entity.LockoutEnabled);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.LockoutEndDateUtc))
            {
                parameters.Add("LockoutEndDateUtc", entity.LockoutEndDateUtc);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.PasswordHash))
            {
                parameters.Add("PasswordHash", entity.PasswordHash);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.PhoneNumber))
            {
                parameters.Add("PhoneNumber", entity.PhoneNumber);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.PhoneNumberConfirmed))
            {
                parameters.Add("PhoneNumberConfirmed", entity.PhoneNumberConfirmed);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.SecurityStamp))
            {
                parameters.Add("SecurityStamp", entity.SecurityStamp);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.TwoFactorEnabled))
            {
                parameters.Add("TwoFactorEnabled", entity.TwoFactorEnabled);
            }
        
            if (!fields.HasFlag(FifthweekUser.Fields.UserName))
            {
                parameters.Add("UserName", entity.UserName);
            }
        
            return parameters;
        }
        
    }
}
namespace Fifthweek.Api.Persistence.Identity
{
    using System;
    using System.Linq;
    using System.ComponentModel.DataAnnotations;
    using Fifthweek.CodeGeneration;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class FifthweekUserRole  : IIdentityEquatable
    {
        public const string Table = "AspNetUserRoles";
        
        public FifthweekUserRole(
            System.Guid roleId,
            System.Guid userId)
        {
            if (roleId == null)
            {
                throw new ArgumentNullException("roleId");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.RoleId = roleId;
            this.UserId = userId;
        }
        
        public bool IdentityEquals(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
        
            if (ReferenceEquals(this, other))
            {
                return true;
            }
        
            if (other.GetType() != this.GetType())
            {
                return false;
            }
        
            return this.IdentityEquals((FifthweekUserRole)other);
        }
        
        protected bool IdentityEquals(FifthweekUserRole other)
        {
            if (!object.Equals(this.RoleId, other.RoleId))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            return true;
        }
        
        [Flags]
        public enum Fields
        {
            Empty = 0,
            RoleId = 1, 
            UserId = 2
        }
    }

    public static partial class FifthweekUserRoleExtensions
    {
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            System.Collections.Generic.IEnumerable<FifthweekUserRole> entities, 
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                entities.Select(entity => new 
                {
                    entity.RoleId, entity.UserId
                }).ToArray(),
                transaction);
        }
        
        public static System.Threading.Tasks.Task InsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUserRole entity,
            bool idempotent = true, 
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                InsertStatement(idempotent), 
                new 
                {
                    entity.RoleId, entity.UserId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> InsertAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekUserRole, FifthweekUserRole.Fields> parameters)
        {
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(InsertStatement(parameters.IdempotentInsert));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var entity = parameters.Entity;
            var parameterObject = parameters.ExcludedFromInput != null
                ? AllExceptSpecifiedParameters(entity, parameters.ExcludedFromInput.Value)
                : new Dapper.DynamicParameters(new { entity.RoleId, entity.UserId });
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUserRole entity, 
            FifthweekUserRole.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(FifthweekUserRole.Fields.Empty, fields), 
                new 
                {
                    entity.RoleId, entity.UserId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task UpsertAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUserRole entity, 
            FifthweekUserRole.Fields mergeOnFields,
            FifthweekUserRole.Fields updateFields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(
                connection, 
                UpsertStatement(mergeOnFields, updateFields), 
                new 
                {
                    entity.RoleId, entity.UserId
                },
                transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection, 
            FifthweekUserRole entity, 
            FifthweekUserRole.Fields fields,
            System.Data.IDbTransaction transaction = null)
        {
            return Dapper.SqlMapper.ExecuteAsync(connection, UpdateStatement(fields), OnlySpecifiedParameters(entity, fields), transaction);
        }
        
        public static System.Threading.Tasks.Task<int> UpdateAsync(
            this System.Data.Common.DbConnection connection,
            SqlGenerationParameters<FifthweekUserRole, FifthweekUserRole.Fields> parameters)
        {
            if (parameters.UpdateMask == null)
            {
                throw new ArgumentException("Must contain update mask", "parameters");
            }
        
            var sql = new System.Text.StringBuilder();
        
            if (parameters.Declarations != null)
            {
                sql.AppendLine(parameters.Declarations);
            }
            
            int currentIndex = 0;
            if (parameters.Conditions != null)
            {
                foreach (var condition in parameters.Conditions)
                {
                    sql.Append("IF ");
                    sql.AppendLine(condition); // Remember to use `WITH (UPDLOCK, HOLDLOCK)` in your conditions! See: http://samsaffron.com/blog/archive/2007/04/04/14.aspx
                    sql.AppendLine("BEGIN");
                    ++currentIndex;
                }
            }
        
            sql.AppendLine(UpdateStatement(parameters.UpdateMask.Value));
        
            if (parameters.Conditions != null)
            {
                sql.AppendLine("SELECT -1 AS FailedConditionIndex"); // Indicates all conditions passed and operation was attempted.
                    
                foreach (var condition in parameters.Conditions)
                {
                    sql.AppendLine("END");
                    sql.AppendLine("ELSE");
                    sql.Append("SELECT ").Append(--currentIndex).AppendLine(" AS FailedConditionIndex");
                }
            }
        
            var parameterObject = OnlySpecifiedParameters(parameters.Entity, parameters.UpdateMask.Value, parameters.ExcludedFromInput);
        
            if (parameters.AdditionalParameters != null)
            {
                parameterObject.AddDynamicParams(parameters.AdditionalParameters);
            }
        
            return Dapper.SqlMapper.ExecuteScalarAsync<int>(
                connection,
                sql.ToString(),
                parameterObject);
        }
        
        public static string InsertStatement(bool idempotent = true)
        {
            const string insert = "INSERT INTO AspNetUserRoles(RoleId, UserId) VALUES(@RoleId, @UserId)";
            return idempotent ? SqlStatementTemplates.IdempotentInsert(insert) : insert;
        }
        
        public static string UpsertStatement(FifthweekUserRole.Fields mergeOnFields, FifthweekUserRole.Fields updateFields)
        {
            // HOLDLOCK ensures operation is concurrent by not releasing the U lock on the row after determining
            // it does not exist. See: http://weblogs.sqlteam.com/dang/archive/2009/01/31/UPSERT-Race-Condition-With-MERGE.aspx
            var sql = new System.Text.StringBuilder();
            sql.Append(
                @"MERGE AspNetUserRoles WITH (HOLDLOCK) as Target
                USING (VALUES (@RoleId, @UserId)) AS Source (RoleId, UserId)
                ON    (");
                
            if (mergeOnFields == FifthweekUserRole.Fields.Empty)
            {
                sql.Append(@"Target.RoleId = Source.RoleId AND Target.UserId = Source.UserId");
            }
            else
            {
                sql.AppendMergeOnParameters(GetFieldNames(mergeOnFields, false));
            }
                
            sql.Append(@")
                WHEN MATCHED THEN
                    UPDATE
                    SET        ");
            sql.AppendUpdateParameters(GetFieldNames(updateFields));
            sql.Append(
                @" WHEN NOT MATCHED THEN
                    INSERT  (RoleId, UserId)
                    VALUES  (Source.RoleId, Source.UserId);");
            return sql.ToString();
        }
        
        public static string UpdateStatement(FifthweekUserRole.Fields fields)
        {
            var sql = new System.Text.StringBuilder();
            sql.Append("UPDATE AspNetUserRoles SET ");
            sql.AppendUpdateParameters(GetFieldNames(fields));
            sql.Append(" WHERE RoleId = @RoleId AND UserId = @UserId");
            return sql.ToString();
        }
        
        private static System.Collections.Generic.IReadOnlyList<string> GetFieldNames(FifthweekUserRole.Fields fields, bool autoIncludePrimaryKeys = true)
        {
            var fieldNames = new System.Collections.Generic.List<string>();
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("RoleId");
            }
        
            if (autoIncludePrimaryKeys)
            {
                fieldNames.Add("UserId");
            }
        
            return fieldNames;
        }
        
        private static Dapper.DynamicParameters OnlySpecifiedParameters(
            FifthweekUserRole entity, 
            FifthweekUserRole.Fields fields,
            FifthweekUserRole.Fields? excludedFields = null)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("RoleId", entity.RoleId);
            parameters.Add("UserId", entity.UserId);
            return parameters;
        }
        
        private static Dapper.DynamicParameters AllExceptSpecifiedParameters(
            FifthweekUserRole entity, 
            FifthweekUserRole.Fields fields)
        {
            var parameters = new Dapper.DynamicParameters();
        
            // Assume we never want to exclude primary key field(s) from our input.
            parameters.Add("RoleId", entity.RoleId);
            parameters.Add("UserId", entity.UserId);
            return parameters;
        }
        
    }
}

