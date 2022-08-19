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
        [Command("ping")]
        public async Task Ping()
        {
            await ReplyAsync("pong!");
        }
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

        [Command("abort")]
        public async Task abort()
        {
            await ReplyAsync("Fetus deletus");
        }

        [Command("meme")]
        public async Task meme()
        {
            var embed = new EmbedBuilder();

            embed.WithImageUrl("https://static.wikia.nocookie.net/runescape2/images/5/56/Frog_%28NPC%29.png/revision/latest?cb=20160531202106");

            await ReplyAsync("", false, embed.Build());
        }
        [Command("ni")]
        public async Task ni()
        {
            await ReplyAsync("gger");
        }
    }
}
