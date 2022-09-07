using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Domain
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetAttributesToIncludeInEqualityCheck();
        public override bool Equals(object other)
        {
            return Equals(other as ValueObject);
        }
        public virtual bool Equals(ValueObject other)
        {
            if (other == null) return false;
            if (other.GetType() != GetType()) return false;
            return GetAttributesToIncludeInEqualityCheck().SequenceEqual(other.GetAttributesToIncludeInEqualityCheck());
        }
        public static bool operator ==(ValueObject left, ValueObject right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(ValueObject left, ValueObject right)
        {
            return !(left == right);
        }
        public override int GetHashCode()
        {
            var hash = 17;
            foreach (var obj in this.GetAttributesToIncludeInEqualityCheck())
                hash = hash * 31 + (obj == null ? 0 : obj.GetHashCode());
            return hash;
        }
    }
}
