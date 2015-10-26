﻿using System;
using System.Linq;

//// Generated on 23/10/2015 18:33:52 (UTC)
//// Mapped solution in 15.19s

namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class Comment 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (Comment)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(Comment))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(Comment).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.String>(reader);
                return new Comment(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(Comment);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<Comment>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<Comment>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, Comment value)
            {
                parameter.DbType = System.Data.DbType.String;
                parameter.Value = value.Value;
            }
        
            public override Comment Parse(object value)
            {
                return new Comment((System.String)value);
            }
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class PostId 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (PostId)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(PostId))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(PostId).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.Guid>(reader);
                return new PostId(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(PostId);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<PostId>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<PostId>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, PostId value)
            {
                parameter.DbType = System.Data.DbType.Guid;
                parameter.Value = value.Value;
            }
        
            public override PostId Parse(object value)
            {
                return new PostId((System.Guid)value);
            }
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class CommentId 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (CommentId)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(CommentId))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(CommentId).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.Guid>(reader);
                return new CommentId(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(CommentId);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<CommentId>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<CommentId>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, CommentId value)
            {
                parameter.DbType = System.Data.DbType.Guid;
                parameter.Value = value.Value;
            }
        
            public override CommentId Parse(object value)
            {
                return new CommentId((System.Guid)value);
            }
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using Fifthweek.CodeGeneration;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class PreviewText 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (PreviewText)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(PreviewText))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(PreviewText).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.String>(reader);
                return new PreviewText(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(PreviewText);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<PreviewText>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<PreviewText>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, PreviewText value)
            {
                parameter.DbType = System.Data.DbType.String;
                parameter.Value = value.Value;
            }
        
            public override PreviewText Parse(object value)
            {
                return new PreviewText((System.String)value);
            }
        }
    }
}

namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class Comment 
    {
        public Comment(
            System.String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Value = value;
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class PostId 
    {
        public PostId(
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
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class CommentId 
    {
        public CommentId(
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
namespace Fifthweek.Api.Posts.Shared
{
    using Fifthweek.CodeGeneration;

    public partial class PreviewText 
    {
        public PreviewText(
            System.String value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Value = value;
        }
    }
}

namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class Comment 
    {
        public override string ToString()
        {
            return string.Format("Comment(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
                hashCode = (hashCode * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(Comment other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class PostId 
    {
        public override string ToString()
        {
            return string.Format("PostId({0})", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((PostId)obj);
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
        
        protected bool Equals(PostId other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using System;
    using System.Linq;
    using Fifthweek.CodeGeneration;
    using System.Collections.Generic;

    public partial class CommentId 
    {
        public override string ToString()
        {
            return string.Format("CommentId({0})", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((CommentId)obj);
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
        
        protected bool Equals(CommentId other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.Api.Posts.Shared
{
    using Fifthweek.CodeGeneration;

    public partial class PreviewText 
    {
        public override string ToString()
        {
            return string.Format("PreviewText(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((PreviewText)obj);
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
        
        protected bool Equals(PreviewText other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}


