using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Memes
{
    //https://github.com/D3vd/Meme_Api
    internal class MemeData
    {
        public string postLink { get; set; }
        public string subreddit { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public bool nsfw { get; set; }
        public bool spoiler { get; set; }
        public string author { get; set; }
        public int ups { get; set; }
        public List<string> preview { get; set; }
    }
}
