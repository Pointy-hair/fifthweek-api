﻿using System;
using System.Linq;

//// Generated on 29/01/2015 18:11:04 (UTC)
//// Mapped solution in 3.16s

namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class PrimitiveGuidDummy 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (PrimitiveGuidDummy)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(PrimitiveGuidDummy))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(PrimitiveGuidDummy).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.Guid>(reader);
                return new PrimitiveGuidDummy(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(PrimitiveGuidDummy);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<PrimitiveGuidDummy>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<PrimitiveGuidDummy>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, PrimitiveGuidDummy value)
            {
                parameter.DbType = System.Data.DbType.Guid;
                parameter.Value = value.Value;
            }
        
            public override PrimitiveGuidDummy Parse(object value)
            {
                return new PrimitiveGuidDummy((System.Guid)value);
            }
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class PrimitiveIntDummy 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (PrimitiveIntDummy)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(PrimitiveIntDummy))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(PrimitiveIntDummy).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.Int32>(reader);
                return new PrimitiveIntDummy(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(PrimitiveIntDummy);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<PrimitiveIntDummy>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<PrimitiveIntDummy>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, PrimitiveIntDummy value)
            {
                parameter.DbType = System.Data.DbType.Int32;
                parameter.Value = value.Value;
            }
        
            public override PrimitiveIntDummy Parse(object value)
            {
                return new PrimitiveIntDummy((System.Int32)value);
            }
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    [Newtonsoft.Json.JsonConverter(typeof(JsonConverter))]
    public partial class PrimitiveStringDummy 
    {
        public class JsonConverter : Newtonsoft.Json.JsonConverter
        {
            public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
            {
                var valueType = (PrimitiveStringDummy)value;
                serializer.Serialize(writer, valueType.Value);
            }
        
            public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
            {
                if (objectType != typeof(PrimitiveStringDummy))
                {
                    throw new ArgumentException("Expected to deserialize JSON for type " + typeof(PrimitiveStringDummy).Name, "objectType");
                }
        
                var value = serializer.Deserialize<System.String>(reader);
                return new PrimitiveStringDummy(value);
            }
        
            public override bool CanConvert(Type objectType)
            {
                return objectType == typeof(PrimitiveStringDummy);
            }
        }
        
        public class DapperTypeHandler : Dapper.SqlMapper.TypeHandler<PrimitiveStringDummy>, Fifthweek.Api.Persistence.IAutoRegisteredTypeHandler<PrimitiveStringDummy>
        {
            public override void SetValue(System.Data.IDbDataParameter parameter, PrimitiveStringDummy value)
            {
                parameter.DbType = System.Data.DbType.String;
                parameter.Value = value.Value;
            }
        
            public override PrimitiveStringDummy Parse(object value)
            {
                return new PrimitiveStringDummy((System.String)value);
            }
        }
    }
}

namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveGuidDummy 
    {
        public PrimitiveGuidDummy(
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
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveIntDummy 
    {
        public PrimitiveIntDummy(
            System.Int32 value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            this.Value = value;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveStringDummy 
    {
        public PrimitiveStringDummy(
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
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ClassAugmentationDummy
    {
        public partial class ComplexType 
        {
            public ComplexType(
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
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ClassAugmentationDummy 
    {
        public ClassAugmentationDummy(
            System.Guid someGuid,
            System.Int32 someInt,
            System.Nullable<System.Guid> optionalGuid,
            System.Nullable<System.Int32> optionalInt,
            System.String someString,
            System.String optionalString,
            System.Collections.Generic.IEnumerable<System.String> someCollection,
            System.Collections.Generic.IEnumerable<System.String> optionalCollection,
            Fifthweek.CodeGeneration.Tests.ClassAugmentationDummy.ComplexType someComplexType,
            Fifthweek.CodeGeneration.Tests.ClassAugmentationDummy.ComplexType optionalComplexType,
            System.String someStringField,
            System.String optionalStringField)
        {
            if (someGuid == null)
            {
                throw new ArgumentNullException("someGuid");
            }

            if (someInt == null)
            {
                throw new ArgumentNullException("someInt");
            }

            if (someString == null)
            {
                throw new ArgumentNullException("someString");
            }

            if (someCollection == null)
            {
                throw new ArgumentNullException("someCollection");
            }

            if (someComplexType == null)
            {
                throw new ArgumentNullException("someComplexType");
            }

            if (someStringField == null)
            {
                throw new ArgumentNullException("someStringField");
            }

            this.SomeGuid = someGuid;
            this.SomeInt = someInt;
            this.OptionalGuid = optionalGuid;
            this.OptionalInt = optionalInt;
            this.SomeString = someString;
            this.OptionalString = optionalString;
            this.SomeCollection = someCollection;
            this.OptionalCollection = optionalCollection;
            this.SomeComplexType = someComplexType;
            this.OptionalComplexType = optionalComplexType;
            this.someStringField = someStringField;
            this.optionalStringField = optionalStringField;
        }
    }
}

namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveGuidDummy 
    {
        public override string ToString()
        {
            return string.Format("PrimitiveGuidDummy({0})", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((PrimitiveGuidDummy)obj);
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
        
        protected bool Equals(PrimitiveGuidDummy other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveIntDummy 
    {
        public override string ToString()
        {
            return string.Format("PrimitiveIntDummy({0})", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((PrimitiveIntDummy)obj);
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
        
        protected bool Equals(PrimitiveIntDummy other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class PrimitiveStringDummy 
    {
        public override string ToString()
        {
            return string.Format("PrimitiveStringDummy(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((PrimitiveStringDummy)obj);
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
        
        protected bool Equals(PrimitiveStringDummy other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ClassAugmentationDummy
    {
        public partial class ComplexType 
        {
            public override string ToString()
            {
                return string.Format("ComplexType(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
            
                return this.Equals((ComplexType)obj);
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
            
            protected bool Equals(ComplexType other)
            {
                if (!object.Equals(this.Value, other.Value))
                {
                    return false;
                }
            
                return true;
            }
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ClassAugmentationDummy 
    {
        public override string ToString()
        {
            return string.Format("ClassAugmentationDummy({0}, {1}, {2}, {3}, \"{4}\", \"{5}\", {6}, {7}, {8}, {9})", this.SomeGuid == null ? "null" : this.SomeGuid.ToString(), this.SomeInt == null ? "null" : this.SomeInt.ToString(), this.OptionalGuid == null ? "null" : this.OptionalGuid.ToString(), this.OptionalInt == null ? "null" : this.OptionalInt.ToString(), this.SomeString == null ? "null" : this.SomeString.ToString(), this.OptionalString == null ? "null" : this.OptionalString.ToString(), this.SomeCollection == null ? "null" : this.SomeCollection.ToString(), this.OptionalCollection == null ? "null" : this.OptionalCollection.ToString(), this.SomeComplexType == null ? "null" : this.SomeComplexType.ToString(), this.OptionalComplexType == null ? "null" : this.OptionalComplexType.ToString());
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
        
            return this.Equals((ClassAugmentationDummy)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SomeGuid != null ? this.SomeGuid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeInt != null ? this.SomeInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalGuid != null ? this.OptionalGuid.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalInt != null ? this.OptionalInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeString != null ? this.SomeString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalString != null ? this.OptionalString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeCollection != null 
        			? this.SomeCollection.Aggregate(0, (previous, current) => 
        				{ 
        				    unchecked
        				    {
        				        return (previous * 397) ^ (current != null ? current.GetHashCode() : 0);
        				    }
        				})
        			: 0);
                hashCode = (hashCode * 397) ^ (this.OptionalCollection != null 
        			? this.OptionalCollection.Aggregate(0, (previous, current) => 
        				{ 
        				    unchecked
        				    {
        				        return (previous * 397) ^ (current != null ? current.GetHashCode() : 0);
        				    }
        				})
        			: 0);
                hashCode = (hashCode * 397) ^ (this.SomeComplexType != null ? this.SomeComplexType.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalComplexType != null ? this.OptionalComplexType.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(ClassAugmentationDummy other)
        {
            if (!object.Equals(this.SomeGuid, other.SomeGuid))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeInt, other.SomeInt))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalGuid, other.OptionalGuid))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalInt, other.OptionalInt))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeString, other.SomeString))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalString, other.OptionalString))
            {
                return false;
            }
        
            if (this.SomeCollection != null && other.SomeCollection != null)
            {
                if (!this.SomeCollection.SequenceEqual(other.SomeCollection))
                {
                    return false;    
                }
            }
            else if (this.SomeCollection != null || other.SomeCollection != null)
            {
                return false;
            }
        
            if (this.OptionalCollection != null && other.OptionalCollection != null)
            {
                if (!this.OptionalCollection.SequenceEqual(other.OptionalCollection))
                {
                    return false;    
                }
            }
            else if (this.OptionalCollection != null || other.OptionalCollection != null)
            {
                return false;
            }
        
            if (!object.Equals(this.SomeComplexType, other.SomeComplexType))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalComplexType, other.OptionalComplexType))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests.Parsing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class AutoCounterpart 
    {
        public override string ToString()
        {
            return string.Format("AutoCounterpart(\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\", \"{5}\", {6}, {7}, {8}, {9})", this.SomeWeaklyTypedString == null ? "null" : this.SomeWeaklyTypedString.ToString(), this.OptionalWeaklyTypedString == null ? "null" : this.OptionalWeaklyTypedString.ToString(), this.SomeParsedString == null ? "null" : this.SomeParsedString.ToString(), this.OptionalParsedString == null ? "null" : this.OptionalParsedString.ToString(), this.SomeParsedNormalizedString == null ? "null" : this.SomeParsedNormalizedString.ToString(), this.OptionalParsedNormalizedString == null ? "null" : this.OptionalParsedNormalizedString.ToString(), this.SomeWeaklyTypedInt == null ? "null" : this.SomeWeaklyTypedInt.ToString(), this.OptionalWeaklyTypedInt == null ? "null" : this.OptionalWeaklyTypedInt.ToString(), this.SomeParsedInt == null ? "null" : this.SomeParsedInt.ToString(), this.OptionalParsedInt == null ? "null" : this.OptionalParsedInt.ToString());
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
        
            return this.Equals((AutoCounterpart)obj);
        }
        
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.SomeWeaklyTypedString != null ? this.SomeWeaklyTypedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalWeaklyTypedString != null ? this.OptionalWeaklyTypedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeParsedString != null ? this.SomeParsedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalParsedString != null ? this.OptionalParsedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeParsedNormalizedString != null ? this.SomeParsedNormalizedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalParsedNormalizedString != null ? this.OptionalParsedNormalizedString.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeWeaklyTypedInt != null ? this.SomeWeaklyTypedInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalWeaklyTypedInt != null ? this.OptionalWeaklyTypedInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.SomeParsedInt != null ? this.SomeParsedInt.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.OptionalParsedInt != null ? this.OptionalParsedInt.GetHashCode() : 0);
                return hashCode;
            }
        }
        
        protected bool Equals(AutoCounterpart other)
        {
            if (!object.Equals(this.SomeWeaklyTypedString, other.SomeWeaklyTypedString))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalWeaklyTypedString, other.OptionalWeaklyTypedString))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeParsedString, other.SomeParsedString))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalParsedString, other.OptionalParsedString))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeParsedNormalizedString, other.SomeParsedNormalizedString))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalParsedNormalizedString, other.OptionalParsedNormalizedString))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeWeaklyTypedInt, other.SomeWeaklyTypedInt))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalWeaklyTypedInt, other.OptionalWeaklyTypedInt))
            {
                return false;
            }
        
            if (!object.Equals(this.SomeParsedInt, other.SomeParsedInt))
            {
                return false;
            }
        
            if (!object.Equals(this.OptionalParsedInt, other.OptionalParsedInt))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests.Parsing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ParsedInt 
    {
        public override string ToString()
        {
            return string.Format("ParsedInt({0})", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ParsedInt)obj);
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
        
        protected bool Equals(ParsedInt other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests.Parsing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ParsedNormalizedString 
    {
        public override string ToString()
        {
            return string.Format("ParsedNormalizedString(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ParsedNormalizedString)obj);
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
        
        protected bool Equals(ParsedNormalizedString other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests.Parsing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ParsedString 
    {
        public override string ToString()
        {
            return string.Format("ParsedString(\"{0}\")", this.Value == null ? "null" : this.Value.ToString());
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
        
            return this.Equals((ParsedString)obj);
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
        
        protected bool Equals(ParsedString other)
        {
            if (!object.Equals(this.Value, other.Value))
            {
                return false;
            }
        
            return true;
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class ClassAugmentationDummy 
    {
        public Builder ToBuilder()
        {
            var builder = new Builder();
            builder.SomeGuid = this.SomeGuid;
            builder.SomeInt = this.SomeInt;
            builder.OptionalGuid = this.OptionalGuid;
            builder.OptionalInt = this.OptionalInt;
            builder.SomeString = this.SomeString;
            builder.OptionalString = this.OptionalString;
            builder.SomeCollection = this.SomeCollection;
            builder.OptionalCollection = this.OptionalCollection;
            builder.SomeComplexType = this.SomeComplexType;
            builder.OptionalComplexType = this.OptionalComplexType;
            builder.someStringField = this.someStringField;
            builder.optionalStringField = this.optionalStringField;
            return builder;
        }
        
        public ClassAugmentationDummy Copy(Action<Builder> applyDelta)
        {
            var builder = this.ToBuilder();
            applyDelta(builder);
            return builder.Build();
        }
        
        public partial class Builder
        {
            public System.Guid SomeGuid { get; set; }
            public System.Int32 SomeInt { get; set; }
            public System.Nullable<System.Guid> OptionalGuid { get; set; }
            public System.Nullable<System.Int32> OptionalInt { get; set; }
            public System.String SomeString { get; set; }
            public System.String OptionalString { get; set; }
            public System.Collections.Generic.IEnumerable<System.String> SomeCollection { get; set; }
            public System.Collections.Generic.IEnumerable<System.String> OptionalCollection { get; set; }
            public Fifthweek.CodeGeneration.Tests.ClassAugmentationDummy.ComplexType SomeComplexType { get; set; }
            public Fifthweek.CodeGeneration.Tests.ClassAugmentationDummy.ComplexType OptionalComplexType { get; set; }
            public System.String someStringField { get; set; }
            public System.String optionalStringField { get; set; }
        
            public ClassAugmentationDummy Build()
            {
                return new ClassAugmentationDummy(
                    this.SomeGuid, 
                    this.SomeInt, 
                    this.OptionalGuid, 
                    this.OptionalInt, 
                    this.SomeString, 
                    this.OptionalString, 
                    this.SomeCollection, 
                    this.OptionalCollection, 
                    this.SomeComplexType, 
                    this.OptionalComplexType, 
                    this.someStringField, 
                    this.optionalStringField);
            }
        }
    }
}
namespace Fifthweek.CodeGeneration.Tests.Parsing
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class AutoCounterpart 
    {
        public class Parsed
        {
            public Parsed(
                System.String someWeaklyTypedString,
                System.String optionalWeaklyTypedString,
                ParsedString someParsedString,
                ParsedString optionalParsedString,
                ParsedNormalizedString someParsedNormalizedString,
                ParsedNormalizedString optionalParsedNormalizedString,
                System.Int32 someWeaklyTypedInt,
                System.Nullable<System.Int32> optionalWeaklyTypedInt,
                ParsedInt someParsedInt,
                ParsedInt optionalParsedInt)
            {
                if (someWeaklyTypedString == null)
                {
                    throw new ArgumentNullException("someWeaklyTypedString");
                }

                if (someParsedString == null)
                {
                    throw new ArgumentNullException("someParsedString");
                }

                if (someParsedNormalizedString == null)
                {
                    throw new ArgumentNullException("someParsedNormalizedString");
                }

                if (someWeaklyTypedInt == null)
                {
                    throw new ArgumentNullException("someWeaklyTypedInt");
                }

                if (someParsedInt == null)
                {
                    throw new ArgumentNullException("someParsedInt");
                }

                this.SomeWeaklyTypedString = someWeaklyTypedString;
                this.OptionalWeaklyTypedString = optionalWeaklyTypedString;
                this.SomeParsedString = someParsedString;
                this.OptionalParsedString = optionalParsedString;
                this.SomeParsedNormalizedString = someParsedNormalizedString;
                this.OptionalParsedNormalizedString = optionalParsedNormalizedString;
                this.SomeWeaklyTypedInt = someWeaklyTypedInt;
                this.OptionalWeaklyTypedInt = optionalWeaklyTypedInt;
                this.SomeParsedInt = someParsedInt;
                this.OptionalParsedInt = optionalParsedInt;
            }
        
            public System.String SomeWeaklyTypedString { get; private set; }
        
            public System.String OptionalWeaklyTypedString { get; private set; }
        
            public ParsedString SomeParsedString { get; private set; }
        
            public ParsedString OptionalParsedString { get; private set; }
        
            public ParsedNormalizedString SomeParsedNormalizedString { get; private set; }
        
            public ParsedNormalizedString OptionalParsedNormalizedString { get; private set; }
        
            public System.Int32 SomeWeaklyTypedInt { get; private set; }
        
            public System.Nullable<System.Int32> OptionalWeaklyTypedInt { get; private set; }
        
            public ParsedInt SomeParsedInt { get; private set; }
        
            public ParsedInt OptionalParsedInt { get; private set; }
        }
    }

    public static partial class AutoCounterpartExtensions
    {
        public static AutoCounterpart.Parsed Parse(this AutoCounterpart target)
        {
            var modelStateDictionary = new System.Web.Http.ModelBinding.ModelStateDictionary();
        
            ParsedString parsed0 = null;
            if (target.SomeParsedString != null)
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed0Errors;
                if (!ParsedString.TryParse(target.SomeParsedString, out parsed0, out parsed0Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed0Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("SomeParsedString", modelState);
                }
            }
            else
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                modelState.Errors.Add("Value required");
                modelStateDictionary.Add("SomeParsedString", modelState);
            }

            ParsedString parsed1 = null;
            if (target.OptionalParsedString != null)
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed1Errors;
                if (!ParsedString.TryParse(target.OptionalParsedString, out parsed1, out parsed1Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed1Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("OptionalParsedString", modelState);
                }
            }

            ParsedNormalizedString parsed2 = null;
            if (target.SomeParsedNormalizedString != null)
            {
                var parsed2Normalized = ParsedNormalizedString.Normalize(target.SomeParsedNormalizedString);
                if (parsed2Normalized != null)
                {
                    System.Collections.Generic.IReadOnlyCollection<string> parsed2Errors;
                    if (!ParsedNormalizedString.TryParse(parsed2Normalized, out parsed2, out parsed2Errors))
                    {
                        var modelState = new System.Web.Http.ModelBinding.ModelState();
                        foreach (var errorMessage in parsed2Errors)
                        {
                            modelState.Errors.Add(errorMessage);
                        }

                        modelStateDictionary.Add("SomeParsedNormalizedString", modelState);
                    }
                }
                else
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    modelState.Errors.Add("Value required");
                    modelStateDictionary.Add("SomeParsedNormalizedString", modelState);
                }
            }
            else
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                modelState.Errors.Add("Value required");
                modelStateDictionary.Add("SomeParsedNormalizedString", modelState);
            }

            ParsedNormalizedString parsed3 = null;
            if (target.OptionalParsedNormalizedString != null)
            {
                var parsed3Normalized = ParsedNormalizedString.Normalize(target.OptionalParsedNormalizedString);
                if (parsed3Normalized != null)
                {
                    System.Collections.Generic.IReadOnlyCollection<string> parsed3Errors;
                    if (!ParsedNormalizedString.TryParse(parsed3Normalized, out parsed3, out parsed3Errors))
                    {
                        var modelState = new System.Web.Http.ModelBinding.ModelState();
                        foreach (var errorMessage in parsed3Errors)
                        {
                            modelState.Errors.Add(errorMessage);
                        }

                        modelStateDictionary.Add("OptionalParsedNormalizedString", modelState);
                    }
                }
            }

            ParsedInt parsed4 = null;
            System.Collections.Generic.IReadOnlyCollection<string> parsed4Errors;
            if (!ParsedInt.TryParse(target.SomeParsedInt, out parsed4, out parsed4Errors))
            {
                var modelState = new System.Web.Http.ModelBinding.ModelState();
                foreach (var errorMessage in parsed4Errors)
                {
                    modelState.Errors.Add(errorMessage);
                }

                modelStateDictionary.Add("SomeParsedInt", modelState);
            }

            ParsedInt parsed5 = null;
            if (target.OptionalParsedInt != null)
            {
                System.Collections.Generic.IReadOnlyCollection<string> parsed5Errors;
                if (!ParsedInt.TryParse(target.OptionalParsedInt.Value, out parsed5, out parsed5Errors))
                {
                    var modelState = new System.Web.Http.ModelBinding.ModelState();
                    foreach (var errorMessage in parsed5Errors)
                    {
                        modelState.Errors.Add(errorMessage);
                    }

                    modelStateDictionary.Add("OptionalParsedInt", modelState);
                }
            }

            if (!modelStateDictionary.IsValid)
            {
                throw new Fifthweek.Api.Core.ModelValidationException(modelStateDictionary);
            }
        
        	return new AutoCounterpart.Parsed(
                target.SomeWeaklyTypedString,
                target.OptionalWeaklyTypedString,
                parsed0,
                parsed1,
                parsed2,
                parsed3,
                target.SomeWeaklyTypedInt,
                target.OptionalWeaklyTypedInt,
                parsed4,
                parsed5);
        }    
    }
}


