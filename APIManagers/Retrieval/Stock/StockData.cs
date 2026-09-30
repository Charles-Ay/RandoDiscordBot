using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Stock
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class GlobalQuote
    {
        [JsonProperty("01. symbol")]
        public string _01symbol { get; set; }

        [JsonProperty("02. open")]
        public string _02open { get; set; }

        [JsonProperty("03. high")]
        public string _03high { get; set; }

        [JsonProperty("04. low")]
        public string _04low { get; set; }

        [JsonProperty("05. price")]
        public string _05price { get; set; }

        [JsonProperty("06. volume")]
        public string _06volume { get; set; }

        [JsonProperty("07. latest trading day")]
        public string _07latesttradingday { get; set; }

        [JsonProperty("08. previous close")]
        public string _08previousclose { get; set; }

        [JsonProperty("09. change")]
        public string _09change { get; set; }

        [JsonProperty("10. change percent")]
        public string _10changepercent { get; set; }
    }

    public class StockData
    {
        [JsonProperty("Global Quote")]
        public GlobalQuote GlobalQuote { get; set; }
    }


}


