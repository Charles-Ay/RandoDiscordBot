using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using RandoDiscordBot.CommandHandlers;

namespace RandoDiscordBot
{
    public class Commands : InteractionModuleBase<SocketInteractionContext>
    {
        private ClientManager _manager = ClientManager.GetClientManager();

        [SlashCommand("ping", "Ping Server")]
        public async Task Ping()
        {
            await RespondAsync($"ping");
        }

        [SlashCommand("hello", "Hello command")]
        public async Task Hello()
        {
            await RespondAsync("Hello there!");
        }

        [SlashCommand("info", "Info command")]
        public async Task Info()
        {
            await RespondAsync("This is the info command.");
        }
        #region DUMB STUFF
        [SlashCommand("daddy", "Find Daddy")]
        public async Task Daddy()
        {
            await RespondAsync("I was a random bot that my handsome daddy Charles decided to make when he was bored.\nMy only goal in life is to troll Ellie!");
        }

        #endregion
        [SlashCommand("meme", "test command")]
        public async Task meme()
        {
            var embed = new EmbedBuilder();

            embed.WithImageUrl(await _manager.memeManager.GetRandomMeme());

            await RespondAsync(embed: embed.Build());
        }

        [SlashCommand("top_anime", "Top Anime")]

        public async Task TopAnime()
        {
            var animeData = await _manager.animeStats.GetTopAnime();
            var embed = new EmbedBuilder();
            List<Embed> em = new List<Embed>();
            for (int i = 0; i < animeData.Count; ++i)
            {
                embed.WithImageUrl(animeData[i].Value);
                embed.WithDescription(animeData[i].Key);
                em.Add(embed.Build());
            }
            Embed[] embeds = em.ToArray();
            embed = new EmbedBuilder();
            await RespondAsync(embeds: embeds);
        }

        [SlashCommand("top_airing", "Top Airing Anime")]
        public async Task TopAiringAnime()
        {
            var animeData = await _manager.animeStats.GetTopAiringAnime();
            var embed = new EmbedBuilder();
            List<Embed> em = new List<Embed>();
            for (int i = 0; i < animeData.Count; ++i)
            {
                embed.WithImageUrl(animeData[i].Value);
                embed.WithDescription(animeData[i].Key);
                em.Add(embed.Build());
            }
            Embed[] embeds = em.ToArray();
            await RespondAsync(embeds: embeds);


            //await ReplyAsync("", false, embed.Build()); 
        }

        [SlashCommand("stock", "Stock Ticker Data")]
        public async Task GetStock(string ticker = "")
        {
            try
            {
                var data = await _manager.stockManager.GetStockByTicker(ticker);
                EmbedBuilder builder = await data.ToEmbedBuilder();
                await RespondAsync(embed: builder.Build());
            }
            catch (Exception e)
            {
                await RespondAsync(e.Message);
            }
        }
        e
        //[SlashCommand("league", "test command")]
        //public async Task GetSummonerStats(params string[] nameArray)
        //{
        //    string name = "";
        //    foreach (var n in nameArray)
        //    {
        //        name += n + " ";
        //    }
        //    name.Remove(name.Length - 1);
        //    try
        //    {
        //        var data = await _manager.riotManager.GetFormatedLeagueEntryDataBySummonerName(name);
        //        EmbedBuilder builder = await data[0].ToEmbedBuilder();
        //        await ReplyAsync("", false, builder.Build());
        //    }
        //    catch (Exception e)
        //    {
        //        await ReplyAsync("No Ranked Data");
        //    }
        //}
    }
}
