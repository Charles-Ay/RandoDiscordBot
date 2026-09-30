using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Memes;

namespace WebResponder.Retrieval.Stock
{
    internal class StockRetrieval
    {
		private readonly string apiKey;
		public StockRetrieval(string key)
        {
            apiKey = key;
        }
		public async Task<StockData> GetStockByTicker(string ticker) {
            var url = $"https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol={ticker}&apikey={apiKey}";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<StockData>(data);
        }

        public async Task<TickerData> GetTickerData(string ticker)
        {
            //KEY: e7d16c0603068ac794eaf1f60182a788cb510816ba8803b62ab16f37745ae211
            var url = $"https://api.sec-api.io/mapping/ticker/^{ticker}$?token=e7d16c0603068ac794eaf1f60182a788cb510816ba8803b62ab16f37745ae211";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<TickerData>>(data)[0];
        }
    }
}
