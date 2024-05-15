using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Riot.League;

namespace WebResponder.Managers
{
    public class RiotManager
    {
        private LeagueRetriever leagueRetrieval;
        public RiotManager(string key)
        {
            leagueRetrieval = new LeagueRetriever(key);
        }
        public async Task<List<FormatedLeagueEntryData>> GetFormatedLeagueEntryDataBySummonerName(string name)
        {
            List<LeagueEntryData> leagueEntry = await leagueRetrieval.GetLeagueEntryDataBySummonerName(name);
            return await FormatedLeagueEntryData.FormatedLeagueEntryDataList(leagueEntry);
        }
    }
}
