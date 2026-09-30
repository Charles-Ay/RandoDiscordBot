using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Stock;

namespace WebResponder.Managers
{
    public class StockManager
    {
        private StockRetrieval stockRetrieval;
        public StockManager(string key)
        {
            stockRetrieval = new StockRetrieval(key);
        }
        public async Task<FormatedStockData> GetStockByTicker(string ticker)
        {
            TickerData tickerData = await stockRetrieval.GetTickerData(ticker.ToLower());
            StockData stock = await stockRetrieval.GetStockByTicker(ticker.ToUpper());
            FormatedStockData formatedStock = new FormatedStockData(stock.GlobalQuote, tickerData);
            return formatedStock;
        }
    }
}
