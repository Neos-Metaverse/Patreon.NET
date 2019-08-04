using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Pledge
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public PledgeAttributes Attributes { get; set; }

        [JsonProperty(PropertyName = "relationships")]
        public PledgeRelationships Relationships { get; set; }
    }

    public class PledgeAttributes
    {
        [JsonProperty(PropertyName = "amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "declined_since")]
        public DateTime? DeclinedSince { get; set; }

        [JsonProperty(PropertyName = "pledge_cap_cents")]
        public int PledgeCapCents { get; set; }

        [JsonProperty(PropertyName = "patron_pays_fees")]
        public bool PatronPaysFees { get; set; }

        [JsonProperty(PropertyName = "total_historical_amount_cents")]
        public int? TotalHistoricalAmountCents { get; set; }

        [JsonProperty(PropertyName = "is_paused")]
        public bool? IsPaused { get; set; }

        [JsonProperty(PropertyName = "has_shipping_address")]
        public bool? HasShippingAddress { get; set; }
    }

    public class PledgeRelationships
    {
        [JsonProperty(PropertyName = "patron")]
        public User Patron { get; set; }

        [JsonProperty(PropertyName = "reward")]
        public Reward Reward { get; set; }

        [JsonProperty(PropertyName = "creator")]
        public User Creator { get; set; }

        [JsonProperty(PropertyName = "address")]
        public Address Address { get; set; }
    }
}
