using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Snowman.Tourist.Spots.Domain.Users.Models;
using Snowman.Tourist.Spots.Shared.Repository.Mappings;

namespace Snowman.Tourist.Spots.Repository.Mappings.Users
{
    public class UserMapping : Mapping<User>
    {
        public UserMapping(string tableName) : base(tableName)
        {
        }

        protected override void EntityMapping(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.ExternalId).HasColumnName("externalId");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.PhoneNumber).HasColumnName("phoneNumber");
        }
    }
}
