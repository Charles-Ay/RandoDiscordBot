using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebResponder.Retrieval.Anime;

namespace WebResponder.Retrieval.Anime
{
    internal class MALRetriever
    {
        private readonly string apiKey = "";
        public MALRetriever(string key)
        {
            apiKey = key;
        }
        public async Task<AnimeData> GetTopAiringAnime()
        {
            string url = "https://api.myanimelist.net/v2/anime/ranking?ranking_type=airing";

            WebRequest myReq = WebRequest.Create(url);
            myReq.Method = "GET";
            myReq.ContentType = "application/json; charset=UTF-8";

           // string usernamePassword = "YOUR API TOKEN HERE" + ":" + "x";

            UTF8Encoding enc = new UTF8Encoding();

            myReq.Headers.Add("X-MAL-CLIENT-ID", apiKey);

            //using (Stream ds = myReq.GetRequestStream())
            //{
            //    ds.Write(enc.GetBytes(data), 0, data.Length);
            //}

            WebResponse wr;
            try
            {
                wr = await myReq.GetResponseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject data = JObject.Parse(content);
            return JsonConvert.DeserializeObject<AnimeData>(content);

        }

        public async Task<AnimeData> GetTopAnime()
        {
            string url = "https://api.myanimelist.net/v2/anime/ranking";

            WebRequest myReq = WebRequest.Create(url);
            myReq.Method = "GET";
            myReq.ContentType = "application/json; charset=UTF-8";

            // string usernamePassword = "YOUR API TOKEN HERE" + ":" + "x";

            UTF8Encoding enc = new UTF8Encoding();

            myReq.Headers.Add("X-MAL-CLIENT-ID", "6114d00ca681b7701d1e15fe11a4987e");

            //using (Stream ds = myReq.GetRequestStream())
            //{
            //    ds.Write(enc.GetBytes(data), 0, data.Length);
            //}

            WebResponse wr;
            try
            {
                wr = await myReq.GetResponseAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            Stream receiveStream = wr.GetResponseStream();
            StreamReader reader = new StreamReader(receiveStream, Encoding.UTF8);
            string content = reader.ReadToEnd();
            JObject data = JObject.Parse(content);
            return JsonConvert.DeserializeObject<AnimeData>(content);

        }

        public void DowloadImages(string url, string name)
        {
            //string dir = Directory.GetCurrentDirectory();
            System.IO.Directory.CreateDirectory("images");
            using (WebClient client = new WebClient())
            {
                client.DownloadFileAsync(new Uri(url), Path.Combine(Directory.GetCurrentDirectory(), $"images\\{name}"));
            }
        } 
    }
}
 