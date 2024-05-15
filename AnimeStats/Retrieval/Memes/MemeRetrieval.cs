using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Memes
{
    internal class MemeRetrieval
    {
        public async Task<MemeData> GetRandomMeme()
        {
            var url = "https://meme-api.herokuapp.com/gimme";

            var request = WebRequest.Create(url);
            request.Method = "GET";

            var webResponse = await request.GetResponseAsync();
            var webStream = webResponse.GetResponseStream();

            var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return JsonConvert.DeserializeObject<MemeData>(data);
        }
    }
}
