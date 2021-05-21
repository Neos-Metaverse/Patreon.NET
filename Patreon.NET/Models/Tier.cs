using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Tier
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public TierAttributes Attributes { get; set; }
    }

    public class TierAttributes
    {
        [JsonProperty(PropertyName = "amount_cents")]
        public int AmountCents { get; set; }

        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "edited_at")]
        public DateTime EditedAt { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageURL { get; set; }

        [JsonProperty(PropertyName = "patron_count")]
        public int PatronCount { get; set; }

        [JsonProperty(PropertyName = "post_count")]
        public int? PostCount { get; set; }

        [JsonProperty(PropertyName = "published")]
        public bool Published { get; set; }

        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty(PropertyName = "remaining")]
        public int? Remaining { get; set; }

        [JsonProperty(PropertyName = "requires_shipping")]
        public bool RequiresShipping { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "unpublished_at")]
        public DateTime UnpublishedAt { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "user_limit")]
        public int? UserLimit { get; set; }
    }
}
