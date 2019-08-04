using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            var patreon = new Patreon.NET.PatreonClient("ACCESS_TOKEN");
            var pledges = patreon.GetCampaignPledges("CAMPAIGN_ID").Result;

            //var result = task.Result;

            Console.Read();
        }
    }
}
