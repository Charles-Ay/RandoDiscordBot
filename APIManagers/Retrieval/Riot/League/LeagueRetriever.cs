using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Riot.League
{
    internal class LeagueRetriever
    {
        //RGAPI-4901e832-d521-4384-afab-229f714edd59
        private readonly string apiKey;
        public LeagueRetriever(string apiKey)
        {
            this.apiKey = apiKey;
        }
        private async Task<SummonerRawData> GetSummonerByNameAsync(string name)
        {
            while(name[name.Length -1] == ' ')
            {
                name = name.Remove(name.Length - 1);
            }
            string formatedName = name.Replace(" ", "%20"); 
            //TODO: API KEY FROM FILE
            var url = $"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{formatedName}?api_key={apiKey}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<SummonerRawData>(data);
        }

        public async Task<List<LeagueEntryData>> GetLeagueEntryDataBySummonerName(string name)
        {
            var summoner = await GetSummonerByNameAsync(name);
            var url = $"https://na1.api.riotgames.com/lol/league/v4/entries/by-summoner/{summoner.id}?api_key={apiKey}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            //data = data.Replace("[", "");
            //data = data.Replace("]", "");
            return JsonConvert.DeserializeObject <List<LeagueEntryData>>(data);
        }
    }
}
