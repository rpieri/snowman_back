using Snowman.Tourist.Spots.Shared.Domain.Models;
using System.Collections.Generic;

namespace Snowman.Tourist.Spots.Domain.Categories.Models
{
    public class Category : Entity
    {
        public string Name { get; private set; }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Name;
        }
    }
}
