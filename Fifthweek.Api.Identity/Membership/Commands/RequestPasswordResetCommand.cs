﻿namespace Fifthweek.Api.Identity.Membership.Commands
{
    public class RequestPasswordResetCommand
    {
        public RequestPasswordResetCommand(NormalizedEmail email, NormalizedUsername username)
        {
            this.Email = email;
            this.Username = username;
        }

        public NormalizedEmail Email { get; private set; }

        public NormalizedUsername Username { get; private set; }

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

            return this.Equals((RequestPasswordResetCommand)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = this.Email != null ? this.Email.GetHashCode() : 0;
                hashCode = (hashCode * 397) ^ (this.Username != null ? this.Username.GetHashCode() : 0);
                return hashCode;
            }
        }

        protected bool Equals(RequestPasswordResetCommand other)
        {
            return object.Equals(this.Email, other.Email) &&
                object.Equals(this.Username, other.Username);
        }
    }
}