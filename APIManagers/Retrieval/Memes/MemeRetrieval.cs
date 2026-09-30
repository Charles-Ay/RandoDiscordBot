using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WebResponder.Retrieval.Memes
{
    internal class MemeRetrieval
    {
        public async Task<MemeData> CreateRandomMeme()
        {
            var url = "https://api.imgflip.com/get_memes";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<MemeData>(data);
        }
        public async Task<MemeData> GetRandomMeme()
        {
            var url = "https://www.memedroid.com/memes/random";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();

            return ParseMemePage(data);
        }

        private MemeData ParseMemePage(string page)
        {
            MemeData data = new MemeData();
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            IEnumerable<HtmlNode> nodes = doc.DocumentNode.Descendants().Where(n => n.HasClass("row"));
            int id = 0;
            foreach (var node in nodes)
            {
                node.ChildNodes.Where(n => n.Name == "button").ToList().ForEach(n => {
                    string name = n.GetAttributeValue("data-title", "");
                    string url = n.GetAttributeValue("data-picture", "");

                    data.memes.Add(new Meme() { id = id.ToString(), name = name, url = url });
                    ++id;
                });
            }

            return data;
        } 
    }
}
