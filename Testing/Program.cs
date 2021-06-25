using System;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        const string CampaignId = "CAMPAIGN_ID";
        const string AccessToken = "ACCESS_TOKEN";

        static async Task Main(string[] args)
        {
            var patreon = new Patreon.NET.PatreonClient(AccessToken);
            //var pledges = await patreon.GetCampaignPledges(CAMPAIGN_ID);
            var members = await patreon.GetCampaignMembers(CampaignId);
            //var campaign = await patreon.GetCampaign(CAMPAIGN_ID);

            Console.Read();
        }
    }
}
