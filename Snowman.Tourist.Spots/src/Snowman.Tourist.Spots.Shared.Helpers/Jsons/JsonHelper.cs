using Newtonsoft.Json;
using Snowman.Tourist.Spots.Shared.Helpers.Jsons.Resolver;

namespace Snowman.Tourist.Spots.Shared.Helpers.Jsons
{
    public static class JsonHelper
    {
        public static string JsonSerialize<T>(this T item) where T : class =>
            JsonConvert.SerializeObject(item, new JsonSerializerSettings()
            {
                ContractResolver = new PrivateSetterContractResolver()
            });

        public static T JsonDeserialize<T>(this string json) where T : class => JsonConvert.DeserializeObject<T>(json);
    }
}
