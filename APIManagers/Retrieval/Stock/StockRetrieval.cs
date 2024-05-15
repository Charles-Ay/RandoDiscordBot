using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

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
			var client = new HttpClient();

			string cont1 = $"SELECT * FROM stocks WHERE symbol in ('AAPL') ORDER BY price_change_percent_1m DESC";
			ticker = ticker.Replace(" ", "");
			string cont2 = $"SELECT * FROM stocks WHERE symbol in ('{ticker}') ORDER BY price_change_percent_1m DESC";
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Post,
				RequestUri = new Uri("https://hotstoks-sql-finance.p.rapidapi.com/query"),
				Headers =
				{
					{ "X-RapidAPI-Key", apiKey },
					{ "X-RapidAPI-Host", "hotstoks-sql-finance.p.rapidapi.com" },
				},
				Content = new StringContent($"{cont2}")
				{
					Headers =
					{
						ContentType = new MediaTypeHeaderValue("text/plain")
					}
				}
			};
            
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StockData>(body);
            }

		}
    }
}
