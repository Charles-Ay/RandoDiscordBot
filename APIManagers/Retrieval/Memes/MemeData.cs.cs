using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Memes
{
    public class MemeData
    {
        public List<Meme> memes { get; set; }
        public MemeData()
        {
            memes = new List<Meme>();
        }
    }

    public class Meme
    {
        public string id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
}
