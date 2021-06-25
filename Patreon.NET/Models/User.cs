using System;
using Newtonsoft.Json;

namespace Patreon.NET
{
    public class User
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "attributes")]
        public UserAttributes Attributes { get; set; }
    }

    public class UserData
    {
        [JsonProperty(PropertyName = "data")]
        public User User { get; set; }

        [JsonProperty(PropertyName = "links")]
        public Links Links { get; set; }
    }

    public class UserAttributes
    {
        [JsonProperty(PropertyName = "about")]
        public string About { get; set; }

        [JsonProperty(PropertyName = "can_see_nsfw")]
        public bool? CanSeeNSFW { get; set; }

        [JsonProperty(PropertyName = "created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "first_name")]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }

        [JsonProperty(PropertyName = "hide_pledges")]
        public bool? HidePledges { get; set; }

        [JsonProperty(PropertyName = "image_url")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "is_email_verified")]
        public bool IsEmailVerified { get; set; }

        [JsonProperty(PropertyName = "last_name")]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "like_count")]
        public int? LikeCount { get; set; }

        [JsonProperty(PropertyName = "thumb_url")]
        public string ThumbnailUrl { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "vanity")]
        public string Vanity { get; set; }

        [JsonProperty(PropertyName = "social_connections")]
        public SocialConnections SocialConnections { get; set; }
    }
}
