using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandoDiscordBot
{
    public class APIKeys
    {
        static readonly string jsonPath = "C:\\APIKey\\key.json";

        [JsonProperty("Discord Key")]
        public string DiscordKey { get; set; }
        
        [JsonProperty("MAL Key")]
        public string MALKey { get; set; }

        [JsonProperty("Riot League Key")]
        public string RiotLeagueKey { get; set; }

        [JsonProperty("Stock Key")]
        public string StockKey { get; set; }

        public static APIKeys GetKeysFromJson()
        {
            string txt = System.IO.File.ReadAllText(jsonPath);
            return JsonConvert.DeserializeObject<APIKeys>(txt);
        }
    }
}
