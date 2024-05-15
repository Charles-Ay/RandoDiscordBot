using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Anime
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Datum
    {
        public Node node { get; set; }
        public Ranking ranking { get; set; }
    }

    public class MainPicture
    {
        public string medium { get; set; }
        public string large { get; set; }
    }

    public class Node
    {
        public int id { get; set; }
        public string title { get; set; }
        public MainPicture main_picture { get; set; }
    }

    public class Paging
    {
        public string next { get; set; }
    }

    public class Ranking
    {
        public int rank { get; set; }
    }

    public class AnimeData
    {
        public List<Datum> data { get; set; }
        public Paging paging { get; set; }
    }
}
