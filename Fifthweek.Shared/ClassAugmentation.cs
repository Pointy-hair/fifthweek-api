﻿using System;
using System.Linq;



namespace Fifthweek.Shared
{
	public partial class FilePurpose 
	{
        public FilePurpose(
            System.String name, 
            System.Boolean isPublic)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (isPublic == null)
            {
                throw new ArgumentNullException("isPublic");
            }

            this.Name = name;
            this.IsPublic = isPublic;
        }
	}

}

namespace Fifthweek.Shared
{
	public partial class FilePurpose 
	{
		public override string ToString()
        {
			return string.Format("FilePurpose(\"{0}\", {1})", this.Name == null ? "null" : this.Name.ToString(), this.IsPublic == null ? "null" : this.IsPublic.ToString());
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

            return this.Equals((FilePurpose)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = 0;
                hashCode = (hashCode * 397) ^ (this.Name != null ? this.Name.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (this.IsPublic != null ? this.IsPublic.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(FilePurpose other)
        {
            if (!object.Equals(this.Name, other.Name))
            {
                return false;
            }

            if (!object.Equals(this.IsPublic, other.IsPublic))
            {
                return false;
            }

            return true;
        }
	}

}


