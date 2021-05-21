using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        const string CAMPAIGN_ID = "CAMPAIGN_ID";
        const string ACCESS_TOKEN = "ACCESS_TOKEN";

        static async Task Main(string[] args)
        {
            var patreon = new Patreon.NET.PatreonClient(ACCESS_TOKEN);
            //var pledges = await patreon.GetCampaignPledges(CAMPAIGN_ID);
            var members = await patreon.GetCampaignMembers(CAMPAIGN_ID);
            //var campaign = await patreon.GetCampaign(CAMPAIGN_ID);

            Console.Read();
        }
    }
}
