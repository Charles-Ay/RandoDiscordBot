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
        private DiscordSocketClient _client;
        private CommandService _commands;
        private IServiceProvider _services;

        static void Main(string[] args) => new Program().RunBotAysnc().GetAwaiter().GetResult();

        public async Task RunBotAysnc()
        {
            _client = new DiscordSocketClient();
            _commands = new CommandService();
            //singletone ensure only one bot is running at a time
            _services = new ServiceCollection().AddSingleton(_client).AddSingleton(_commands).BuildServiceProvider();

            string token = "MTAxMDIyNjYwMDU5MzMzODQ1MQ.G-IyRU.JYQBMc5hr7EI-saPztj29-oGemhFP-E3u3vqcY";
            _client.Log += _client_Log;
            
            await RegisterCommandsAsync();

            await _client.LoginAsync(TokenType.Bot, token);

            await _client.StartAsync();



            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        public async Task RegisterCommandsAsync(){
            _client.MessageReceived += HandleCommandAsync;
            await _commands.AddModulesAsync(Assembly.GetEntryAssembly(), _services);
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            var context = new SocketCommandContext(_client, message);
            if (message.Author.IsBot) return;

            string[] filters = { "ni" };
            string content = message.Content;
            bool contains = filters.Any(x => content.Split(' ').Any(y => y.Contains(x)));

            int argPos = 0;
            if (message.HasStringPrefix("_", ref argPos) || message.HasMentionPrefix(_client.CurrentUser, ref argPos))
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
            }
            //message without prefix
            else if (contains)
            {
                var result = await _commands.ExecuteAsync(context, argPos, _services);
                if (!result.IsSuccess) Console.WriteLine(result.ErrorReason);
                return;
            }
        }
    }
}
