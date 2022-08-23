using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;

namespace RandoDiscordBot
{
    public class Commands : ModuleBase<SocketCommandContext>
    {
        private ClientManager _manager = ClientManager.GetClientManager();

        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("pong!");
        }
        #region DUMB STUFF
        [Command("daddy")]
        public async Task Daddy()
        {
            await ReplyAsync("I was a random bot that my handsome daddy C9Flexer decided to make when he was bored.\nMy only goal in life is to troll beastie!");
        }
        [Command("hardR")]
        public async Task HardR()
        {
            await ReplyAsync("Im about to drop the hard R!");
        }
        [Command("n")]
        public async Task n()
        {
            await ReplyAsync("i\ng\ng");
        }

        [Command("e")]
        public async Task e()
        {
            await ReplyAsync("r");
        }
        
        [Command("what am i")]
        public async Task WhatAmI()
        {
            await ReplyAsync("A cool guy");
        }
        [Command("who am i")]
        public async Task WhoAmI()
        {
            var Username = base.Context.User.Username;
            await ReplyAsync($"You are: {Username}");
        }

        [Command("abort")]
        public async Task abort()
        {
            await ReplyAsync("Fetus deletus");
        }
        
        [Command("choke")]
        public async Task Choke()
        {
            var it = _manager.client.GetUser(Context.Message.Author.Id);
            if (it.Username.ToLower().Contains("beastie"))
            {
                var chnl = _manager.client.GetChannel(Context.Message.Channel.Id) as IMessageChannel; // 4
                await chnl.SendMessageAsync($"{Context.Message.Author.Mention} DIE!!! *Starts choking beastie*"); // 5
            }
        }
        #endregion
        [Command("meme")]
        public async Task meme()
        {
            var embed = new EmbedBuilder();

            embed.WithImageUrl(await _manager.memeManager.GetRandomMeme());

            await ReplyAsync("", false, embed.Build());
        }

        [Command("top anime")]
       
        public async Task TopAnime()
        {
            var animeData = await _manager.animeStats.GetTopAnime();
            var embed = new EmbedBuilder();
            List<Embed> em = new List<Embed>();
            for(int i = 0; i < animeData.Count; ++i)
            {
                embed.WithImageUrl(animeData[i].Value);
                embed.WithDescription(animeData[i].Key);
                em.Add(embed.Build());
            }
            Embed[] embeds = em.ToArray();
            embed = new EmbedBuilder();
            await ReplyAsync("", false, embeds: embeds);


            //await ReplyAsync("", false, embed.Build()); 
        }
        [Command("top airing")]
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
            await ReplyAsync("", false, embeds: embeds);


            //await ReplyAsync("", false, embed.Build()); 
        }

        [Command("stock")]
        public async Task GetStock(string ticker = "")
        {
            try
            {
                var data = await _manager.stockManager.GetStockByTicker(ticker);
                EmbedBuilder builder = await data.ToEmbedBuilder();
                await ReplyAsync("", false, builder.Build());
            }
            catch (Exception e)
            {
                await ReplyAsync(e.Message);
            }
        }
        
        [Command("league")]
        public async Task GetSummonerStats(params string[] nameArray)
        {
            string name = "";
            foreach (var n in nameArray)
            {
                name += n + " ";
            }
            name.Remove(name.Length - 1);
            try
            {
                var data = await _manager.riotManager.GetFormatedLeagueEntryDataBySummonerName(name);
                EmbedBuilder builder = await data.ToEmbedBuilder();
                await ReplyAsync("", false, builder.Build());
            }
            catch (Exception e)
            {
                await ReplyAsync(e.Message);
            }
        }
    }
}
