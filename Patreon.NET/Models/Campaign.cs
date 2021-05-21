using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Campaign
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public CampaignAttributes Attributes { get; set; }

        [JsonProperty(PropertyName = "relationships")]
        public CampaignRelationships Relationships { get; set; }
    }

    public class CampaignAttributes
    {
        [JsonProperty(PropertyName = "created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty(PropertyName = "creation_name")]
        public string CreationName { get; set; }

        [JsonProperty(PropertyName = "discord_server_id")]
        public string DiscordServerID { get; set; }

        [JsonProperty(PropertyName = "google_analytics_id")]
        public string GoogleAnalyticsID { get; set; }

        [JsonProperty(PropertyName = "has_rss")]
        public bool HasRSS { get; set; }

        [JsonProperty(PropertyName = "has_sent_rss_notify")]
        public bool HasSentRSSNotify { get; set; }

        [JsonProperty(PropertyName = "image_small_url")]
        public string ImageSmallUrl { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "is_charged_immediately")]
        public bool IsChargedImmediatelly { get; set; }

        [JsonProperty(PropertyName = "is_monthly")]
        public bool IsMonthly { get; set; }

        [JsonProperty(PropertyName = "is_nsfw")]
        public bool IsNSFW { get; set; }

        [JsonProperty(PropertyName = "main_video_embed")]
        public string MainVideoEmbed { get; set; }

        [JsonProperty(PropertyName = "main_video_url")]
        public string MainVideoUrl { get; set; }

        [JsonProperty(PropertyName = "one_liner")]
        public string OneLiner { get; set; }

        [JsonProperty(PropertyName = "patron_count")]
        public int PatronCount { get; set; }

        [JsonProperty(PropertyName = "pay_per_name")]
        public string PayPerName { get; set; }

        [JsonProperty(PropertyName = "pledge_url")]
        public string PledgeUrl { get; set; }

        [JsonProperty(PropertyName = "published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty(PropertyName = "rss_artwork_url")]
        public string RSSArtworkURL { get; set; }

        [JsonProperty(PropertyName = "rss_feed_title")]
        public string RSSFeedTitle { get; set; }

        [JsonProperty(PropertyName = "show_earnings")]
        public bool ShowEarnings { get; set; }

        [JsonProperty(PropertyName = "summary")]
        public string Summary { get; set; }

        [JsonProperty(PropertyName = "thanks_embed")]
        public string ThanksEmbed { get; set; }

        [JsonProperty(PropertyName = "thanks_msg")]
        public string ThanksMsg { get; set; }

        [JsonProperty(PropertyName = "thanks_video_url")]
        public string ThanksVideoUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }

        [JsonProperty(PropertyName = "vanity")]
        public string Vanity { get; set; }
    }

    public class CampaignRelationships
    {
        [JsonProperty(PropertyName = "creator")]
        public User Creator { get; set; }

        [JsonProperty(PropertyName = "tiers")]
        public List<Tier> Tiers { get; set; }
    }
}
