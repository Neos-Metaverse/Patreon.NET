using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using JsonApiSerializer;
using JsonApiSerializer.JsonApi;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace Patreon.NET
{
    public class PatreonClient : IDisposable
    {
        public const string SAFE_ROOT = "https://www.patreon.com/api/oauth2/v2/";
        public const string PUBLIC_ROOT = "https://www.patreon.com/api/";

        public static string CampaignURL(string campaignId) => SAFE_ROOT + $"campaigns/{campaignId}";
        public static string PledgesURL(string campaignId) => CampaignURL(campaignId) + "/pledges";
        public static string MembersURL(string campaignId) => CampaignURL(campaignId) + "/members";
        public static string MemberURL(string memberId) => SAFE_ROOT + $"members/{memberId}";

        public static string UserURL(string userId) => PUBLIC_ROOT + "user/" + userId;

        HttpClient httpClient;

        public PatreonClient(string accessToken)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
        }

        static string GenerateFieldsAndIncludes(Type includes, params Type[] fields)
        {
            var str = new StringBuilder();

            foreach (var field in fields)
            {
                GenerateFields(field, str);
                str.Append("&");
            }

            GenerateIncludes(includes, str);

            return str.ToString();
        }

        static void GenerateFields(Type type, StringBuilder str)
        {
            str.Append("fields%5B");

            var name = type.Name.Replace("Attributes", "");

            for(int i = 0; i < name.Length; i++)
            {
                var ch = name[i];

                if (char.IsUpper(ch) && i != 0)
                    str.Append("_");

                str.Append(char.ToLower(ch));
            }

            str.Append("%5D=");

            GenerateFieldList(type, str);
        }

        static void GenerateIncludes(Type type, StringBuilder str)
        {
            str.Append($"include=");

            GenerateFieldList(type, str);
        }

        static void GenerateFieldList(Type type, StringBuilder str)
        {
            foreach (var property in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                var attributes = property.GetCustomAttributes(typeof(JsonPropertyAttribute), true);

                if (attributes == null || attributes.Length == 0)
                    continue;             

                foreach (var attribute in attributes)
                {
                    str.Append(((JsonPropertyAttribute)attribute).PropertyName);
                    str.Append(",");
                }
            }

            // remove the last comma
            str.Length -= 1;
        }

        public static string AppendQuery(string url, string query)
        {
            if (url.Contains("?"))
                url += "&" + query;
            else
                url += "?" + query;

            return url;
        }

        public async Task<HttpResponseMessage> GET(string url) => await httpClient.GetAsync(url);

        public async Task<T> GET<T>(string url)
            where T : class
        {
            var response = await GET(url);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var settings = new JsonApiSerializerSettings();
                    return JsonConvert.DeserializeObject<T>(json, settings);
                }
                catch(Exception ex)
                {
#if DEBUG
                    Console.WriteLine(ex.ToString());
#endif
                }
            }

            return null;
        }

        public async Task<Campaign> GetCampaign(string campaignId)
        {
            var url = CampaignURL(campaignId);

            url = AppendQuery(url, GenerateFieldsAndIncludes(typeof(CampaignRelationships), 
                typeof(CampaignAttributes), typeof(UserAttributes), typeof(TierAttributes)));

            var document = await GET<DocumentRoot<Campaign>>(url).ConfigureAwait(false);

            return document.Data;
        }

        public async Task<List<Tier>> GetCampaignTiers(string campaignId)
        {
            var campaign = await GetCampaign(campaignId).ConfigureAwait(false);

            return campaign.Relationships.Tiers;
        }

        public async Task<List<Member>> GetCampaignMembers(string campaignId)
        {
            var list = new List<Member>();

            string next = MembersURL(campaignId);

            do
            {
                var url = next;

                url = AppendQuery(url, GenerateFieldsAndIncludes(typeof(MemberRelationships),
                    typeof(MemberAttributes), typeof(UserAttributes)));

                var document = await GET<DocumentRoot<Member[]>>(url).ConfigureAwait(false);

                list.AddRange(document.Data);

                if (document.Links != null && document.Links.ContainsKey("next"))
                    next = document.Links["next"].Href;
                else
                    next = null;

            } while (next != null);

            return list;
        }

        public async Task<User> GetUser(string id) => (await GET<UserData>(UserURL(id)).ConfigureAwait(false))?.User;

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
