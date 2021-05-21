using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class Member
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public MemberAttributes Attributes { get; set; }

        [JsonProperty(PropertyName = "relationships")]
        public MemberRelationships Relationships { get; set; }
    }

    public class MemberAttributes
    {
        [JsonProperty(PropertyName = "campaign_lifetime_support_cents")]
        public int CampaignLifetimeSupportCents { get; set; }

        [JsonProperty(PropertyName = "currently_entitled_amount_cents")]
        public int EntitledAmountCents { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "is_follower")]
        public bool IsFollower { get; set; }

        [JsonProperty(PropertyName = "last_charge_date")]
        public DateTime LastChargeDate { get; set; }

        [JsonProperty(PropertyName = "last_charge_status")]
        public string LastChargeStatus { get; set; }

        [JsonProperty(PropertyName = "lifetime_support_cents")]
        public int LifetimeSupportCents { get; set; }

        [JsonProperty(PropertyName = "next_charge_date")]
        public DateTime NextChargeDate { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }

        [JsonProperty(PropertyName = "patron_status")]
        public string PatreonStatus { get; set; }

        [JsonProperty(PropertyName = "pledge_cadence")]
        public int PledgeCadence { get; set; }

        [JsonProperty(PropertyName = "pledge_relationship_start")]
        public DateTime PledgeRelationshipStart { get; set; }

        [JsonProperty(PropertyName = "will_pay_amount_cents")]
        public int WillPayAmountCents { get; set; }
    }

    public class MemberRelationships
    {
        [JsonProperty(PropertyName = "user")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "pledge_history")]
        public List<PledgeEvent> PledgeHistory { get; set; }

        [JsonProperty(PropertyName = "currently_entitled_tiers")]
        public List<Tier> CurrentlyEntitledTiers { get; set; }
    }
}
