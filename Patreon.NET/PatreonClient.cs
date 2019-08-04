using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using JsonApiSerializer;
using JsonApiSerializer.JsonApi;

namespace Patreon.NET
{
    public class PatreonClient : IDisposable
    {
        public const string SAFE_ROOT = "https://www.patreon.com/api/oauth2/api/";
        public const string PUBLIC_ROOT = "https://www.patreon.com/api/";

        public static string CampaignURL(string campaignId) => SAFE_ROOT + $"campaigns/{campaignId}/";
        public static string PledgesURL(string campaignId) => CampaignURL(campaignId) + "pledges";

        public static string UserURL(string userId) => PUBLIC_ROOT + "user/" + userId;

        public static string PLEDGE_FIELDS => "fields%5Bpledge%5D=amount_cents,created_at,declined_since,pledge_cap_cents,patron_pays_fees,total_historical_amount_cents,is_paused,has_shipping_address";

        HttpClient httpClient;

        public PatreonClient(string accessToken)
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
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

                }
            }

            return null;
        }

        public async Task<List<Pledge>> GetCampaignPledges(string campaignId)
        {
            var list = new List<Pledge>();

            string next = PledgesURL(campaignId);

            do
            {
                var url = next;
                if (url.Contains("?"))
                    url += "&" + PLEDGE_FIELDS;
                else
                    url += "?" + PLEDGE_FIELDS;

                var document = await GET<DocumentRoot<Pledge[]>>(url);
                list.AddRange(document.Data);

                if (document.Links.ContainsKey("next"))
                    next = document.Links["next"].Href;
                else
                    next = null;

            } while (next != null);

            return list;
        }

        public async Task<User> GetUser(string id) => (await GET<UserData>(UserURL(id)))?.User;

        public void Dispose()
        {
            httpClient.Dispose();
        }
    }
}
