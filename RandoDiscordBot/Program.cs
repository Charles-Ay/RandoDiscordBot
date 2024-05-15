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

            string token = _manager.keys.DiscordKey;
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

        public async Task RegisterCommandsAsync() {
            _manager.client.MessageReceived += HandleCommandAsync;
            await _manager.commands.AddModulesAsync(Assembly.GetEntryAssembly(), _manager.services);
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            var context = new SocketCommandContext(_manager.client, message);
            if (message.Author.IsBot) return;
            //else if(== )


            int argPos = 0;
            if (message.HasStringPrefix("_", ref argPos) || message.HasMentionPrefix(_manager.client.CurrentUser, ref argPos))
            {
                if (await BeastieBlacklist(message)) return;
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
            string[] filters = { "what am i", "who am i?", "download" };
            var context = new SocketCommandContext(_manager.client, message);

            string content = message.Content;

            bool contains = false;
            //bool contains = filters.Any(x => content.Split(' ').Any(y => y.ToLower().Contains(x.ToLower())));
            foreach (var filter in filters)
            {
                if (filter.ToLower().Contains(content.ToLower()) || content.ToLower().Contains(filter.ToLower()))
                {
                    contains = true;
                    break;
                }
            }
            
            int argPos = 0;

            //message without prefix
            if (contains)
            {
                if(await BeastieBlacklist(message))return;
                try
                {
                    var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
                    if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(message.Content);
                    return;

                }
            }
        }

        private async Task<bool> BeastieBlacklist(SocketUserMessage message)
        {
            var it = _manager.client.GetUser(message.Author.Id);
            if (message.Content.Contains("choke")) return false;
            if (message.Content.Contains("meme")) return false;
            if (it.Username.ToLower().Contains("beastie"))
            {
                var chnl = _manager.client.GetChannel(message.Channel.Id) as IMessageChannel; // 4
                await chnl.SendMessageAsync($"{message.Author.Mention} shut up ur a woman"); // 5
                return true;
            }
            return false;
        }
    }
}
