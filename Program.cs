using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace RandoDiscordBot
{
    public class Program
    {
        public Program()
        {
            
        }
        private ClientManager _manager;

        static void Main(string[] args) => new Program().RunBotAysnc().GetAwaiter().GetResult();

        public async Task RunBotAysnc()
        {
            _manager = ClientManager.GetClientManager();

            string token = "MTAxMDIyNjYwMDU5MzMzODQ1MQ.G-IyRU.JYQBMc5hr7EI-saPztj29-oGemhFP-E3u3vqcY";
            _manager.client.Log += _client_Log;
            
            await RegisterCommandsAsync();

            await _manager.client.LoginAsync(TokenType.Bot, token);

            await _manager.client.StartAsync();



            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync(){
            _manager.client.MessageReceived += HandleCommandAsync;
            await _manager.commands.AddModulesAsync(Assembly.GetEntryAssembly(), _manager.services);
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            var context = new SocketCommandContext(_manager.client, message);
            if (message.Author.IsBot) return;

            int argPos = 0;
            if (message.HasStringPrefix("_", ref argPos) || message.HasMentionPrefix(_manager.client.CurrentUser, ref argPos))
            {
                var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
            //else if (message.HasStringPrefix("_d", ref argPos) || message.HasMentionPrefix(_manager.client.CurrentUser, ref argPos))
            //{
            //    var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
            //    if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            //}
            else await HandleCommandAsyncSpec(args);

        }

        private async Task HandleCommandAsyncSpec(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            string[] filters = { "what am i?", "who am i?", "download" };
            var context = new SocketCommandContext(_manager.client, message);
            
            string content = message.Content;
            
            bool contains = filters.Any(x => content.Split(' ').Any(y => y.Contains(x.ToLower())));
            int argPos = 1;

            //foreach (var filter in filters)
            //{
            //    if (!contains)
            //    {
            //        if (message.Content.ToLower() == filter) contains = true;
            //    }
            //}

            //message without prefix
            //if (contains)
            //{
            //    var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
            //    if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            //    return;
            //}
            string[] split = message.Content.Split(' ');
            //if (message.Content.Contains("download") && split.Count() > 1)
            //{

            //}


            if (contains)
            {
                //_manager.animeDownloader.DownloadAnime(split[1], split[2]);
               
            }
            _manager.animeStats.GetTopAnime();
        }
    }
}
