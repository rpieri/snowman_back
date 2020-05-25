using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Snowman.Tourist.Spots.Shared.Domain.Models
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
            Removed = false;
            Valid = true;
            CreatedDate = DateTime.UtcNow;

            var random = new Random();
            Code = $"{CreatedDate:yyyyMMddhhmmsstt}-{random.Next(1,50000)}";
        }
        public Guid Id { get; private set; }
        public string Code { get; private set; }
        public bool Removed { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public void Remove() => Removed = true;

        #region Validation
        public bool Valid { get; private set; }
        public ValidationResult ValidationResult { get; private set; }
        public bool Invalid => !Valid;        
        
        public void Validate<TEntity>(TEntity entity, AbstractValidator<TEntity> validator) where TEntity : Entity
        {
            ValidationResult = validator.Validate(entity);
            Valid = ValidationResult.IsValid;
        }
        #endregion

        #region comparative
        protected abstract IEnumerable<object> GetEqualityComponents();

        public bool Equal(Entity obj) => this == obj;
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (!(obj is Entity)) return false;

            return this == (obj as Entity);
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

        public static bool operator ==(Entity a, Entity b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (a is null || b is null)
                return false;

            return a.GetType() == b.GetType() &&
                a.GetEqualityComponents().SequenceEqual(b.GetEqualityComponents());
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);
        #endregion
    }
}
