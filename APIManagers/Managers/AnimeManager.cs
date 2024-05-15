using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Anime;
using WebResponder.Retrieval;

namespace WebResponder.Managers
{
    public class AnimeManager
    {
        private MALRetriever retriever;

        public AnimeManager(string key)
        {
            retriever = new MALRetriever(key);
        }

        public async Task<List<KeyValuePair<string, string>>> GetTopAnime()
        {
            var animeData = await retriever.GetTopAnime();
            //stores anime info parsed and image link
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            foreach (var anime in animeData.data)
            {
                //retriever.DowloadImages(anime.node.main_picture.medium, anime.node.title + ".jpg");
                ret.Add(new KeyValuePair<string, string>($"#{anime.ranking.rank} - {anime.node.title}", anime.node.main_picture.medium));
            }
            return ret;
        }

        public async Task<List<KeyValuePair<string, string>>> GetTopAiringAnime()
        {
            var animeData = await retriever.GetTopAiringAnime();
            //stores anime info parsed and image link
            List<KeyValuePair<string, string>> ret = new List<KeyValuePair<string, string>>();
            foreach (var anime in animeData.data)
            {
                //retriever.DowloadImages(anime.node.main_picture.medium, anime.node.title + ".jpg");
                ret.Add(new KeyValuePair<string, string>($"#{anime.ranking.rank} - {anime.node.title}", anime.node.main_picture.medium));
            }
            return ret;
        }
    }
}
