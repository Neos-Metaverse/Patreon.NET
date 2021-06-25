using System;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class PledgeEvent
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public PledgeEventAttributes Attributes { get; set; }

        [JsonProperty(PropertyName = "relationships")]
        public PledgeEventRelationships Relationships { get; set; }
    }

    public class PledgeEventAttributes
    {
        [JsonProperty(PropertyName = "amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty(PropertyName = "currency_code")]
        public string CurrencyCode { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        [JsonProperty(PropertyName = "payment_status")]
        public string PaymentStatus { get; set; }

        [JsonProperty(PropertyName = "tier_id")]
        public string TierId { get; set; }

        [JsonProperty(PropertyName = "tier_title")]
        public string TierTitle { get; set; }

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
    }

    public class PledgeEventRelationships
    {

    }
}
