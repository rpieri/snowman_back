using System;
using System.Collections.Generic;
using System.Linq;

namespace Snowman.Tourist.Spots.Shared.Domain.ValueObjects
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equal(ValueObject obj) => this == obj;
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (!(obj is ValueObject)) return false;

            return this == (obj as ValueObject);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 30;

                foreach (var item in GetEqualityComponents())
                {
                    hash = HashCode.Combine(hash, item) * 31;
                }

                return hash;
            }
        }

        public static bool operator ==(ValueObject a, ValueObject b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.GetType() == b.GetType() &&
                a.GetEqualityComponents().SequenceEqual(b.GetEqualityComponents());
        }

        public static bool operator !=(ValueObject a, ValueObject b) => !(a == b);
    }
}
