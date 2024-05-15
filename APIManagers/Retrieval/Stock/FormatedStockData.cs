using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;

namespace WebResponder.Retrieval.Stock
{
    public class FormatedStockData
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Change { get; set; }
        public string ChangePercent { get; set; }
        public long MarketCap { get; set; }
        public int Volume { get; set; }
        public int VolumeAvg { get; set; }
        //public int Shares { get; set; }
        public string StockExchange { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public FormatedStockData(Result data)
        {
            Symbol = data.symbol;
            Name = data.name;
            Price = data.price;
            High = data.price_high;
            Low = data.price_low;
            Change = data.price_change_1d;
            ChangePercent = data.price_change_percent_1d;
            MarketCap = data.market_cap;
            Volume = data.volume;
            VolumeAvg = data.volume_avg_10d;
            //Shares = data.shares;
            StockExchange = data.exchange_name;
            LastUpdated = data.updated;
        }

        public Task<EmbedBuilder> ToEmbedBuilder()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.Color = Color.Green;
            builder.WithTitle(Name);
            builder.WithDescription($"Stock data for: {Symbol}");
            builder.AddField("Market Cap", MarketCap);
            builder.AddField("Price", Price);
            builder.AddField("High", High);
            builder.AddField("Low", Low);
            builder.AddField("Change", Change);
            builder.AddField("Change Percent", ChangePercent);
            builder.AddField("Volume", Volume);
            builder.AddField("Exchange: ", StockExchange);
            builder.WithFooter(footer =>
            {
                footer.Text = $"Last updated: {LastUpdated}";
            });


            return Task.FromResult(builder);
        }
    }
}
