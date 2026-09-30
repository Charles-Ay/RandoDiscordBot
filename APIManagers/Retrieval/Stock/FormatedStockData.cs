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
        public string Volume { get; set; }
        //public int Shares { get; set; }
        public string StockExchange { get; set; }
        public DateTime LastUpdated { get; set; }
        
        public FormatedStockData(GlobalQuote data, TickerData ticker)
        {
            Symbol = data._01symbol;
            Name = ticker.name;
            Price = data._05price;
            High = data._03high;
            Low = data._04low;
            Change = data._09change;
            ChangePercent = data._10changepercent;
            Volume = data._06volume;
            StockExchange = ticker.exchange;
            LastUpdated = DateTime.Now;
        }

        public Task<EmbedBuilder> ToEmbedBuilder()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.Color = Color.Green;
            builder.WithTitle(Name);
            builder.WithDescription($"Stock data for: {Symbol}");
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
