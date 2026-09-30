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
        private static int currentMeme = 0;
        private static List<string> memes = new List<string>();
        private MemeRetrieval memeRetrieval = new MemeRetrieval();
        public async Task<string> GetRandomMeme()
        {
            if(memes.Count == 0 || currentMeme == memes.Count)
            {
                MemeData meme = await memeRetrieval.GetRandomMeme();
                foreach (Meme m in meme.memes)
                {
                    memes.Add(m.url);
                }
                currentMeme = 0;
            }
            else ++currentMeme;
            return memes[currentMeme];
        }
    }
}
