using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowman.Tourist.Spots.Shared.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Snowman.Tourist.Spots.Shared.Repository.Mappings
{
    public abstract class Mapping<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : Entity
    {
        private readonly string tableName;

        public Mapping(string tableName) => this.tableName = tableName;

        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(tableName);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Code).HasColumnName("code");
            builder.Property(x => x.Removed).HasColumnName("removed");
            builder.Property(x => x.CreatedDate).HasColumnName("createdDate");

            EntityMapping(builder);

            builder.Ignore(x => x.ValidationResult);
            builder.Ignore(x => x.Valid);
            builder.Ignore(x => x.Invalid);
        }

        protected virtual void OneToMany<TRelatedEntity>(EntityTypeBuilder<TEntity> builder,
            string constraintName,
            Expression<Func<TEntity, object>> foreignKeyExpression,
            bool requerid = false,
            Expression<Func<TEntity, TRelatedEntity>> navigationExpression = null,
            Expression<Func<TRelatedEntity, IEnumerable<TEntity>>> navigationChildExpression = null) where TRelatedEntity : Entity
        {
            builder.HasOne(navigationExpression)
                .WithMany(navigationChildExpression)
                .HasForeignKey(foreignKeyExpression)
                .HasConstraintName(constraintName)
                .IsRequired(requerid);
        }

        protected virtual void OneToOne<TRelatedEntity>(EntityTypeBuilder<TEntity> builder, string constraintName,
            Expression<Func<TEntity, object>> foreignKeyExpression,
            bool required = false,
            Expression<Func<TEntity, TRelatedEntity>> navigationExpression = null,
            Expression<Func<TRelatedEntity, TEntity>> navigationChildExpression = null) where TRelatedEntity : Entity
        {
            builder.HasOne(navigationExpression)
                .WithOne(navigationChildExpression)
                .HasForeignKey(foreignKeyExpression)
                .HasConstraintName(constraintName)
                .IsRequired(required);
        }
        protected abstract void EntityMapping(EntityTypeBuilder<TEntity> builder);
    }
}
