﻿using System;
using System.Linq;



namespace Fifthweek.Api.Channels
{
    using System;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class ChannelId 
    {
		public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (ChannelId)value;
                serializer.Serialize(writer, valueType.Value);
            }

            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(ChannelId))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(ChannelId).Name, "objectType");
                }

                var value = serializer.Deserialize<System.Guid>(reader);
                return new ChannelId(value);
            }

            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(ChannelId);
            }
        }

		public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<ChannelId>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<ChannelId>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, ChannelId value)
            {
                parameter.DbType = System.Data.DbType.Guid;
                parameter.Value = value.Value;
            }

            public override ChannelId Parse(object value)
            {
                return new ChannelId((System.Guid)value);
            }
        }
    }

}

namespace Fifthweek.Api.Channels
{
    using System;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    public partial class ChannelId 
    {
        public ChannelId(
            System.Guid value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Value = value;
        }
    }

}
namespace Fifthweek.Api.Channels
{
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using Fifthweek.CodeGeneration;
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public partial class ChannelOwnership 
    {
        public ChannelOwnership(
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
namespace Fifthweek.Api.Channels
{
    using System.Threading.Tasks;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.CodeGeneration;
    using System;
    using System.Linq;
    using Dapper;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    public partial class ChannelSecurity 
    {
        public ChannelSecurity(
            Fifthweek.Api.Channels.IChannelOwnership channelOwnership)
        {
            if (channelOwnership == null)
            {
                throw new ArgumentNullException("channelOwnership");
            }

            this.channelOwnership = channelOwnership;
        }
    }

}
namespace Fifthweek.Api.Channels.Controllers
{
    using System.Web.Http;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.OAuth;
    using Fifthweek.CodeGeneration;
    public partial class ChannelController 
    {
        public ChannelController(
            Fifthweek.Api.Identity.OAuth.IUserContext userContext, 
            Fifthweek.Api.Core.IGuidCreator guidCreator)
        {
            if (userContext == null)
            {
                throw new ArgumentNullException("userContext");
            }

            if (guidCreator == null)
            {
                throw new ArgumentNullException("guidCreator");
            }

            this.userContext = userContext;
            this.guidCreator = guidCreator;
        }
    }

}

namespace Fifthweek.Api.Channels
{
    using System;
    using Fifthweek.CodeGeneration;
    using System.Linq;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    public partial class ChannelId 
    {
        public override string ToString()
        {
            return string.Format("ChannelId({0})", this.Value == null ? "null" : this.Value.ToString());
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

            return this.Equals((ChannelId)obj);
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

        protected bool Equals(ChannelId other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Channels
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    public partial class ValidChannelName 
    {
        public override string ToString()
        {
            return string.Format("ValidChannelName(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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

            return this.Equals((ValidChannelName)obj);
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

        protected bool Equals(ValidChannelName other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }

            return true;
        }
    }

}
namespace Fifthweek.Api.Channels
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Threading.Tasks;
    using Dapper;
    using Fifthweek.Api.Core;
    using Fifthweek.Api.Identity.Membership;
    using Fifthweek.Api.Persistence;
    using System.Collections.Generic;
    public partial class ValidChannelPriceInUsCentsPerWeek 
    {
        public override string ToString()
        {
            return string.Format("ValidChannelPriceInUsCentsPerWeek({0})", this.Value == null ? "null" : this.Value.ToString());
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

            return this.Equals((ValidChannelPriceInUsCentsPerWeek)obj);
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

        protected bool Equals(ValidChannelPriceInUsCentsPerWeek other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }

            return true;
        }
    }

}

