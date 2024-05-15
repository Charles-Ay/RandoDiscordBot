using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Stock
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Result
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string price { get; set; }
        public string price_open { get; set; }
        public string price_low { get; set; }
        public string price_high { get; set; }
        public string price_low_high_change_percent { get; set; }
        public string price_1d { get; set; }
        public string price_change_1d { get; set; }
        public string price_change_percent_1d { get; set; }
        public string price_change_percent_5d { get; set; }
        public string price_change_percent_1m { get; set; }
        public string price_change_percent_3m { get; set; }
        public string price_change_percent_6m { get; set; }
        public string price_change_percent_ytd { get; set; }
        public string price_change_percent_1y { get; set; }
        public string price_change_percent_5y { get; set; }
        public string price_change_percent_10y { get; set; }
        public string all_time_high_date { get; set; }
        public string all_time_high_price { get; set; }
        public string all_time_high_percent_diff { get; set; }
        public string moving_avg_50d { get; set; }
        public string moving_avg_50d_percent_diff { get; set; }
        public string moving_avg_200d { get; set; }
        public string moving_avg_200d_percent_diff { get; set; }
        public int volume { get; set; }
        public int volume_avg_10d { get; set; }
        public string volume_avg_10d_percent_diff { get; set; }
        public int volume_avg_3m { get; set; }
        public string volume_avg_3m_percent_diff { get; set; }
        public string pe_ratio { get; set; }
        public long market_cap { get; set; }
        public string eps { get; set; }
        public string week_52_high { get; set; }
        public string week_52_high_percent_diff { get; set; }
        public string week_52_low { get; set; }
        public string week_52_low_percent_diff { get; set; }
        public string dividend_rate { get; set; }
        public string dividend_yield_percent { get; set; }
        public string dividend_date { get; set; }
        public string earnings_date { get; set; }
        public string analyst_rating { get; set; }
        public string exchange_name { get; set; }
        public DateTime created { get; set; }
        public DateTime updated { get; set; }
        public DateTime updated_pst { get; set; }
        public DateTime updated_est { get; set; }
    }

    public class StockData
    {
        public int count { get; set; }
        public List<Result> results { get; set; }
    }
}


