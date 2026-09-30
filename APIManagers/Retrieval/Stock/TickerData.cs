using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Stock
{
    public class TickerData
    {
        public string name { get; set; }
        public string ticker { get; set; }
        public string cik { get; set; }
        public string cusip { get; set; }
        public string exchange { get; set; }
        public bool isDelisted { get; set; }
        public string category { get; set; }
        public string sector { get; set; }
        public string industry { get; set; }
        public string sic { get; set; }
        public string sicSector { get; set; }
        public string sicIndustry { get; set; }
        public string famaSector { get; set; }
        public string famaIndustry { get; set; }
        public string currency { get; set; }
        public string location { get; set; }
        public string id { get; set; }
    }
}
