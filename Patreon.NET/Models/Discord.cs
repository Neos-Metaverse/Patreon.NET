using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Discord
    {
        [JsonProperty("url")]
        public object Url { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}