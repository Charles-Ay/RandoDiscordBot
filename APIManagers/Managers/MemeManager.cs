using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Memes;

namespace WebResponder.Managers
{
    public class MemeManager
    {
        private MemeRetrieval memeRetrieval = new MemeRetrieval();
        public async Task<string> GetRandomMeme()
        {
            MemeData meme = await memeRetrieval.GetRandomMeme();
            return meme.url;
        }
    }
}
