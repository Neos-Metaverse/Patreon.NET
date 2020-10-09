using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Reward
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public RewardAttributes Attributes { get; set; }
    }

    public class RewardAttributes
    {
        [JsonProperty(PropertyName = "amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "patron_count")]
        public int PatronCount { get; set; }

        [JsonProperty(PropertyName = "user_limit")]
        public int? UserLimit { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }

    public class RewardListData
    {
        [JsonProperty(PropertyName = "included")]
        public List<Reward> Rewards { get; set; }
    }

    public class RewardData
    {
        [JsonProperty(PropertyName = "data")]
        public Reward Reward { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }
    }
}
