using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonApiSerializer;

namespace Patreon.NET
{
    public class PledgePager
    {
        public string CampaignId { get; private set; }

        public bool HasNextPage => nextPage != null;

        PatreonClient client;

        string nextPage;

        public PledgePager(PatreonClient client, string campaignId)
        {
            this.client = client;
            this.CampaignId = campaignId;

            nextPage = PatreonClient.PledgesURL(campaignId);
        }

        public async Task<List<Pledge>> LoadAllPledges()
        {
            List<Pledge> pledges = new List<Pledge>();

            while (HasNextPage)
            {
                var page = await LoadNextPageAsync();
                if (page == null)
                    return null;

                pledges.AddRange(page);
            }

            return pledges;
        }

        public async Task<List<Pledge>> LoadNextPageAsync()
        {
            var pledgeListData = await client.GET<Pledge[]>(nextPage);

            if (pledgeListData == null)
                return null;

            //nextPage = pledgeListData.Links.Next;
            return pledgeListData.ToList();
        }
    }
}
