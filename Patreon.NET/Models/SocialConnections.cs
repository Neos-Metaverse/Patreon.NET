using Newtonsoft.Json;

namespace Patreon.NET
{
    public class SocialConnections
    {
        [JsonProperty("deviantart")]
        public object Deviantart { get; set; }

        [JsonProperty("discord")]
        public Discord Discord { get; set; }

        [JsonProperty("facebook")]
        public object Facebook { get; set; }

        [JsonProperty("google")]
        public object Google { get; set; }

        [JsonProperty("instagram")]
        public object Instagram { get; set; }

        [JsonProperty("reddit")]
        public object Reddit { get; set; }

        [JsonProperty("spotify")]
        public object Spotify { get; set; }

        [JsonProperty("twitch")]
        public object Twitch { get; set; }

        [JsonProperty("twitter")]
        public object Twitter { get; set; }

        [JsonProperty("youtube")]
        public object Youtube { get; set; }
    }
}