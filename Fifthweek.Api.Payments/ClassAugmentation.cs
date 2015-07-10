﻿using System;
using System.Linq;

//// Generated on 10/07/2015 09:01:01 (UTC)
//// Mapped solution in 44.62s


namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class ApplyCreditRequestCommand 
    {
        public ApplyCreditRequestCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Identity.Shared.Membership.UserId userId,
            Fifthweek.Shared.PositiveInt amount,
            Fifthweek.Shared.PositiveInt expectedTotalAmount)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            if (expectedTotalAmount == null)
            {
                throw new ArgumentNullException("expectedTotalAmount");
            }

            this.Requester = requester;
            this.UserId = userId;
            this.Amount = amount;
            this.ExpectedTotalAmount = expectedTotalAmount;
        }
    }
}
namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;
    using System.Runtime.ExceptionServices;

    public partial class ApplyCreditRequestCommandHandler 
    {
        public ApplyCreditRequestCommandHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Shared.IFifthweekRetryOnTransientErrorHandler retryOnTransientFailure,
            Fifthweek.Payments.Services.Credit.IApplyStandardUserCredit applyStandardUserCredit,
            Fifthweek.Api.Payments.Commands.ICommitTestUserCreditToDatabase commitTestUserCreditToDatabase,
            Fifthweek.Payments.Services.Credit.IFailPaymentStatusDbStatement failPaymentStatus)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (retryOnTransientFailure == null)
            {
                throw new ArgumentNullException("retryOnTransientFailure");
            }

            if (applyStandardUserCredit == null)
            {
                throw new ArgumentNullException("applyStandardUserCredit");
            }

            if (commitTestUserCreditToDatabase == null)
            {
                throw new ArgumentNullException("commitTestUserCreditToDatabase");
            }

            if (failPaymentStatus == null)
            {
                throw new ArgumentNullException("failPaymentStatus");
            }

            this.requesterSecurity = requesterSecurity;
            this.retryOnTransientFailure = retryOnTransientFailure;
            this.applyStandardUserCredit = applyStandardUserCredit;
            this.commitTestUserCreditToDatabase = commitTestUserCreditToDatabase;
            this.failPaymentStatus = failPaymentStatus;
        }
    }
}
namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class UpdatePaymentOriginCommand 
    {
        public UpdatePaymentOriginCommand(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Identity.Shared.Membership.UserId userId,
            Fifthweek.Api.Payments.ValidStripeToken stripeToken,
            Fifthweek.Api.Payments.ValidCountryCode countryCode,
            Fifthweek.Api.Payments.ValidCreditCardPrefix creditCardPrefix,
            Fifthweek.Api.Payments.ValidIpAddress ipAddress)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.Requester = requester;
            this.UserId = userId;
            this.StripeToken = stripeToken;
            this.CountryCode = countryCode;
            this.CreditCardPrefix = creditCardPrefix;
            this.IpAddress = ipAddress;
        }
    }
}
namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class UpdatePaymentOriginCommandHandler 
    {
        public UpdatePaymentOriginCommandHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Api.Payments.ISetUserPaymentOriginDbStatement setUserPaymentOrigin,
            Fifthweek.Payments.Services.Credit.IGetUserPaymentOriginDbStatement getUserPaymentOrigin,
            Fifthweek.Payments.Services.Credit.Stripe.ICreateStripeCustomer createStripeCustomer,
            Fifthweek.Payments.Services.Credit.Stripe.IUpdateStripeCustomerCreditCard updateStripeCustomerCreditCard)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (setUserPaymentOrigin == null)
            {
                throw new ArgumentNullException("setUserPaymentOrigin");
            }

            if (getUserPaymentOrigin == null)
            {
                throw new ArgumentNullException("getUserPaymentOrigin");
            }

            if (createStripeCustomer == null)
            {
                throw new ArgumentNullException("createStripeCustomer");
            }

            if (updateStripeCustomerCreditCard == null)
            {
                throw new ArgumentNullException("updateStripeCustomerCreditCard");
            }

            this.requesterSecurity = requesterSecurity;
            this.setUserPaymentOrigin = setUserPaymentOrigin;
            this.getUserPaymentOrigin = getUserPaymentOrigin;
            this.createStripeCustomer = createStripeCustomer;
            this.updateStripeCustomerCreditCard = updateStripeCustomerCreditCard;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class CreditRequestData 
    {
        public CreditRequestData(
            System.Int32 amount,
            System.Int32 expectedTotalAmount)
        {
            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            if (expectedTotalAmount == null)
            {
                throw new ArgumentNullException("expectedTotalAmount");
            }

            this.Amount = amount;
            this.ExpectedTotalAmount = expectedTotalAmount;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class CreditRequestSummary 
    {
        public CreditRequestSummary(
            System.Int32 amount,
            System.Int32 totalAmount,
            System.Int32 taxAmount,
            System.Decimal taxRate,
            System.String taxName,
            System.String taxEntityName,
            System.String countryName)
        {
            if (amount == null)
            {
                throw new ArgumentNullException("amount");
            }

            if (totalAmount == null)
            {
                throw new ArgumentNullException("totalAmount");
            }

            if (taxAmount == null)
            {
                throw new ArgumentNullException("taxAmount");
            }

            if (taxRate == null)
            {
                throw new ArgumentNullException("taxRate");
            }

            if (taxName == null)
            {
                throw new ArgumentNullException("taxName");
            }

            if (taxEntityName == null)
            {
                throw new ArgumentNullException("taxEntityName");
            }

            if (countryName == null)
            {
                throw new ArgumentNullException("countryName");
            }

            this.Amount = amount;
            this.TotalAmount = totalAmount;
            this.TaxAmount = taxAmount;
            this.TaxRate = taxRate;
            this.TaxName = taxName;
            this.TaxEntityName = taxEntityName;
            this.CountryName = countryName;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class PaymentOriginData 
    {
        public PaymentOriginData(
            System.String stripeToken,
            System.String countryCode,
            System.String creditCardPrefix,
            System.String ipAddress)
        {
            this.StripeToken = stripeToken;
            this.CountryCode = countryCode;
            this.CreditCardPrefix = creditCardPrefix;
            this.IpAddress = ipAddress;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class PaymentsController 
    {
        public PaymentsController(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterContext requesterContext,
            Fifthweek.Api.Core.IQueryHandler<Fifthweek.Api.Payments.Queries.GetCreditRequestSummaryQuery,Fifthweek.Api.Payments.Controllers.CreditRequestSummary> getCreditRequestSummary,
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Payments.Commands.UpdatePaymentOriginCommand> updatePaymentsOrigin,
            Fifthweek.Api.Core.ICommandHandler<Fifthweek.Api.Payments.Commands.ApplyCreditRequestCommand> applyCreditRequest)
        {
            if (requesterContext == null)
            {
                throw new ArgumentNullException("requesterContext");
            }

            if (getCreditRequestSummary == null)
            {
                throw new ArgumentNullException("getCreditRequestSummary");
            }

            if (updatePaymentsOrigin == null)
            {
                throw new ArgumentNullException("updatePaymentsOrigin");
            }

            if (applyCreditRequest == null)
            {
                throw new ArgumentNullException("applyCreditRequest");
            }

            this.requesterContext = requesterContext;
            this.getCreditRequestSummary = getCreditRequestSummary;
            this.updatePaymentsOrigin = updatePaymentsOrigin;
            this.applyCreditRequest = applyCreditRequest;
        }
    }
}
namespace Fifthweek.Api.Payments.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Controllers;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Taxamo;

    public partial class GetCreditRequestSummaryQuery 
    {
        public GetCreditRequestSummaryQuery(
            Fifthweek.Api.Identity.Shared.Membership.Requester requester,
            Fifthweek.Api.Identity.Shared.Membership.UserId userId)
        {
            if (requester == null)
            {
                throw new ArgumentNullException("requester");
            }

            if (userId == null)
            {
                throw new ArgumentNullException("userId");
            }

            this.Requester = requester;
            this.UserId = userId;
        }
    }
}
namespace Fifthweek.Api.Payments.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Controllers;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Taxamo;

    public partial class GetCreditRequestSummaryQueryHandler 
    {
        public GetCreditRequestSummaryQueryHandler(
            Fifthweek.Api.Identity.Shared.Membership.IRequesterSecurity requesterSecurity,
            Fifthweek.Payments.Services.Credit.IGetUserPaymentOriginDbStatement getUserPaymentOrigin,
            Fifthweek.Payments.Services.Credit.Taxamo.IGetTaxInformation getTaxInformation,
            Fifthweek.Payments.Services.Credit.IGetUserWeeklySubscriptionsCost getUserWeeklySubscriptionsCost)
        {
            if (requesterSecurity == null)
            {
                throw new ArgumentNullException("requesterSecurity");
            }

            if (getUserPaymentOrigin == null)
            {
                throw new ArgumentNullException("getUserPaymentOrigin");
            }

            if (getTaxInformation == null)
            {
                throw new ArgumentNullException("getTaxInformation");
            }

            if (getUserWeeklySubscriptionsCost == null)
            {
                throw new ArgumentNullException("getUserWeeklySubscriptionsCost");
            }

            this.requesterSecurity = requesterSecurity;
            this.getUserPaymentOrigin = getUserPaymentOrigin;
            this.getTaxInformation = getTaxInformation;
            this.getUserWeeklySubscriptionsCost = getUserWeeklySubscriptionsCost;
        }
    }
}
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class SetUserPaymentOriginDbStatement 
    {
        public SetUserPaymentOriginDbStatement(
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
namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class CommitTestUserCreditToDatabase 
    {
        public CommitTestUserCreditToDatabase(
            Fifthweek.Shared.ITimestampCreator timestampCreator,
            Fifthweek.Api.Payments.ISetTestUserAccountBalanceDbStatement setTestUserAccountBalance)
        {
            if (timestampCreator == null)
            {
                throw new ArgumentNullException("timestampCreator");
            }

            if (setTestUserAccountBalance == null)
            {
                throw new ArgumentNullException("setTestUserAccountBalance");
            }

            this.timestampCreator = timestampCreator;
            this.setTestUserAccountBalance = setTestUserAccountBalance;
        }
    }
}
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class SetTestUserAccountBalanceDbStatement 
    {
        public SetTestUserAccountBalanceDbStatement(
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

namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class ApplyCreditRequestCommand 
    {
        public override string ToString()
        {
            return string.Format("ApplyCreditRequestCommand({0}, {1}, {2}, {3})", this.Requester == null ? "null" : this.Requester.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.Amount == null ? "null" : this.Amount.ToString(), this.ExpectedTotalAmount == null ? "null" : this.ExpectedTotalAmount.ToString());
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
        
            return this.Equals((ApplyCreditRequestCommand)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ExpectedTotalAmount != null ? this.ExpectedTotalAmount.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ApplyCreditRequestCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            if (!object.Equals(this.ExpectedTotalAmount, other.ExpectedTotalAmount))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Commands
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Newtonsoft.Json;
    using Fifthweek.Payments.Services;
    using Fifthweek.Api.Persistence.Identity;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Stripe;

    public partial class UpdatePaymentOriginCommand 
    {
        public override string ToString()
        {
            return string.Format("UpdatePaymentOriginCommand({0}, {1}, {2}, {3}, {4}, {5})", this.Requester == null ? "null" : this.Requester.ToString(), this.UserId == null ? "null" : this.UserId.ToString(), this.StripeToken == null ? "null" : this.StripeToken.ToString(), this.CountryCode == null ? "null" : this.CountryCode.ToString(), this.CreditCardPrefix == null ? "null" : this.CreditCardPrefix.ToString(), this.IpAddress == null ? "null" : this.IpAddress.ToString());
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
        
            return this.Equals((UpdatePaymentOriginCommand)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.StripeToken != null ? this.StripeToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CountryCode != null ? this.CountryCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreditCardPrefix != null ? this.CreditCardPrefix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IpAddress != null ? this.IpAddress.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(UpdatePaymentOriginCommand other)
        {
            if (!object.Equals(this.Requester, other.Requester))
            {
                return false;
            }
        
            if (!object.Equals(this.UserId, other.UserId))
            {
                return false;
            }
        
            if (!object.Equals(this.StripeToken, other.StripeToken))
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
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class CreditRequestData 
    {
        public override string ToString()
        {
            return string.Format("CreditRequestData({0}, {1})", this.Amount == null ? "null" : this.Amount.ToString(), this.ExpectedTotalAmount == null ? "null" : this.ExpectedTotalAmount.ToString());
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
        
            return this.Equals((CreditRequestData)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.ExpectedTotalAmount != null ? this.ExpectedTotalAmount.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreditRequestData other)
        {
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            if (!object.Equals(this.ExpectedTotalAmount, other.ExpectedTotalAmount))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class CreditRequestSummary 
    {
        public override string ToString()
        {
            return string.Format("CreditRequestSummary({0}, {1}, {2}, {3}, \"{4}\", \"{5}\", \"{6}\")", this.Amount == null ? "null" : this.Amount.ToString(), this.TotalAmount == null ? "null" : this.TotalAmount.ToString(), this.TaxAmount == null ? "null" : this.TaxAmount.ToString(), this.TaxRate == null ? "null" : this.TaxRate.ToString(), this.TaxName == null ? "null" : this.TaxName.ToString(), this.TaxEntityName == null ? "null" : this.TaxEntityName.ToString(), this.CountryName == null ? "null" : this.CountryName.ToString());
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
        
            return this.Equals((CreditRequestSummary)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Amount != null ? this.Amount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TotalAmount != null ? this.TotalAmount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaxAmount != null ? this.TaxAmount.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaxRate != null ? this.TaxRate.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaxName != null ? this.TaxName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.TaxEntityName != null ? this.TaxEntityName.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CountryName != null ? this.CountryName.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(CreditRequestSummary other)
        {
            if (!object.Equals(this.Amount, other.Amount))
            {
                return false;
            }
        
            if (!object.Equals(this.TotalAmount, other.TotalAmount))
            {
                return false;
            }
        
            if (!object.Equals(this.TaxAmount, other.TaxAmount))
            {
                return false;
            }
        
            if (!object.Equals(this.TaxRate, other.TaxRate))
            {
                return false;
            }
        
            if (!object.Equals(this.TaxName, other.TaxName))
            {
                return false;
            }
        
            if (!object.Equals(this.TaxEntityName, other.TaxEntityName))
            {
                return false;
            }
        
            if (!object.Equals(this.CountryName, other.CountryName))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class PaymentOriginData 
    {
        public override string ToString()
        {
            return string.Format("PaymentOriginData(\"{0}\", \"{1}\", \"{2}\", \"{3}\")", this.StripeToken == null ? "null" : this.StripeToken.ToString(), this.CountryCode == null ? "null" : this.CountryCode.ToString(), this.CreditCardPrefix == null ? "null" : this.CreditCardPrefix.ToString(), this.IpAddress == null ? "null" : this.IpAddress.ToString());
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
        
            return this.Equals((PaymentOriginData)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.StripeToken != null ? this.StripeToken.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CountryCode != null ? this.CountryCode.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.CreditCardPrefix != null ? this.CreditCardPrefix.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IpAddress != null ? this.IpAddress.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(PaymentOriginData other)
        {
            if (!object.Equals(this.StripeToken, other.StripeToken))
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
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Queries
{
    using System;
    using System.Linq;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Controllers;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using Fifthweek.Payments.Services.Credit;
    using Fifthweek.Payments.Services.Credit.Taxamo;

    public partial class GetCreditRequestSummaryQuery 
    {
        public override string ToString()
        {
            return string.Format("GetCreditRequestSummaryQuery({0}, {1})", this.Requester == null ? "null" : this.Requester.ToString(), this.UserId == null ? "null" : this.UserId.ToString());
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
        
            return this.Equals((GetCreditRequestSummaryQuery)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Requester != null ? this.Requester.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.UserId != null ? this.UserId.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(GetCreditRequestSummaryQuery other)
        {
            if (!object.Equals(this.Requester, other.Requester))
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
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class ValidCountryCode 
    {
        public override string ToString()
        {
            return string.Format("ValidCountryCode(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ValidCountryCode)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ValidCountryCode other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class ValidCreditCardPrefix 
    {
        public override string ToString()
        {
            return string.Format("ValidCreditCardPrefix(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ValidCreditCardPrefix)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ValidCreditCardPrefix other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class ValidIpAddress 
    {
        public override string ToString()
        {
            return string.Format("ValidIpAddress(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ValidIpAddress)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ValidIpAddress other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.Api.Persistence.Payments;
    using Fifthweek.Shared;
    using System.Collections.Generic;
    using System.Net;

    public partial class ValidStripeToken 
    {
        public override string ToString()
        {
            return string.Format("ValidStripeToken(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ValidStripeToken)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ValidStripeToken other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class CreditRequestData 
    {
        public class Parsed
        {
            public Parsed(
                PositiveInt amount,
                PositiveInt expectedTotalAmount)
            {
                if (amount == null)
                {
                    throw new ArgumentNullException("amount");
                }

                if (expectedTotalAmount == null)
                {
                    throw new ArgumentNullException("expectedTotalAmount");
                }

                this.Amount = amount;
                this.ExpectedTotalAmount = expectedTotalAmount;
            }
        
            public PositiveInt Amount { get; private set; }
        
            public PositiveInt ExpectedTotalAmount { get; private set; }
        }
    }

    public static partial class CreditRequestDataExtensions
    {
        public static CreditRequestData.Parsed Parse(this CreditRequestData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();
        
            PositiveInt parsed0 = null;
            System.Collections.Generic.IReadOnlyCollection<string> parsed0Errors;
            if (!PositiveInt.TryParse(target.Amount, out parsed0, out parsed0Errors))
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                foreach (var errorMessage in parsed0Errors)
                {
                    modelState.Errors.Add(errorMessage);
                }

                modelStateDictionary.Add("Amount", modelState);
            }

            PositiveInt parsed1 = null;
            System.Collections.Generic.IReadOnlyCollection<string> parsed1Errors;
            if (!PositiveInt.TryParse(target.ExpectedTotalAmount, out parsed1, out parsed1Errors))
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                foreach (var errorMessage in parsed1Errors)
                {
                    modelState.Errors.Add(errorMessage);
                }

                modelStateDictionary.Add("ExpectedTotalAmount", modelState);
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        
            return new CreditRequestData.Parsed(
                parsed0,
                parsed1);
        }    
    }
}
namespace Fifthweek.Api.Payments.Controllers
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using Fifthweek.Shared;
    using System.Threading.Tasks;
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Shared.Membership;
    using Fifthweek.Api.Payments.Commands;
    using Fifthweek.Api.Payments.Queries;

    public partial class PaymentOriginData 
    {
        public class Parsed
        {
            public Parsed(
                ValidStripeToken stripeToken,
                ValidCountryCode countryCode,
                ValidCreditCardPrefix creditCardPrefix,
                ValidIpAddress ipAddress)
            {
                this.StripeToken = stripeToken;
                this.CountryCode = countryCode;
                this.CreditCardPrefix = creditCardPrefix;
                this.IpAddress = ipAddress;
            }
        
            public ValidStripeToken StripeToken { get; private set; }
        
            public ValidCountryCode CountryCode { get; private set; }
        
            public ValidCreditCardPrefix CreditCardPrefix { get; private set; }
        
            public ValidIpAddress IpAddress { get; private set; }
        }
    }

    public static partial class PaymentOriginDataExtensions
    {
        public static PaymentOriginData.Parsed Parse(this PaymentOriginData target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();
        
            ValidStripeToken parsed0 = null;
            if (!ValidStripeToken.IsEmpty(target.StripeToken))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed0Errors;
                if (!ValidStripeToken.TryParse(target.StripeToken, out parsed0, out parsed0Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed0Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("StripeToken", modelState);
                }
            }

            ValidCountryCode parsed1 = null;
            if (!ValidCountryCode.IsEmpty(target.CountryCode))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed1Errors;
                if (!ValidCountryCode.TryParse(target.CountryCode, out parsed1, out parsed1Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed1Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("CountryCode", modelState);
                }
            }

            ValidCreditCardPrefix parsed2 = null;
            if (!ValidCreditCardPrefix.IsEmpty(target.CreditCardPrefix))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed2Errors;
                if (!ValidCreditCardPrefix.TryParse(target.CreditCardPrefix, out parsed2, out parsed2Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed2Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("CreditCardPrefix", modelState);
                }
            }

            ValidIpAddress parsed3 = null;
            if (!ValidIpAddress.IsEmpty(target.IpAddress))
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed3Errors;
                if (!ValidIpAddress.TryParse(target.IpAddress, out parsed3, out parsed3Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed3Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("IpAddress", modelState);
                }
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        
            return new PaymentOriginData.Parsed(
                parsed0,
                parsed1,
                parsed2,
                parsed3);
        }    
    }
}


