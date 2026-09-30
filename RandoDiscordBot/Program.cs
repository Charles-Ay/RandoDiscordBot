using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;

namespace RandoDiscordBot
{
    public class Program
    {
        private ClientManager _manager;

        static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();

        public async Task RunBotAsync()
        {
            _manager = ClientManager.GetClientManager();
            string token = _manager.keys.DiscordKey;
            _manager.client.Log += _client_Log;
            _manager.client.Ready += _client_ready;

            await _manager.client.LoginAsync(TokenType.Bot, token);
            await _manager.client.StartAsync();

            await Task.Delay(-1);
        }

        private Task _client_Log(LogMessage arg)
        {
            Console.WriteLine(arg);
            return Task.CompletedTask;
        }

        //private async Task _client_Ready()
        //{

        //    await _manager.interactions.AddModulesAsync(Assembly.GetEntryAssembly(), _manager.services);
        //    await _manager.interactions.RegisterCommandsToGuildAsync(_manager.client.Guilds.ToArray()[0].Id);
        //    _manager.client.InteractionCreated += async interaction =>
        //    {
        //        var scope = _manager.services.CreateScope();
        //        var ctx = new SocketInteractionContext(_manager.client, interaction);
        //        await _manager.interactions.ExecuteCommadAsync(ctx, scope.ServiceProvider);
        //    };
        //}

        private async Task _client_ready()
        {
            Console.WriteLine("Client is ready. Registering commands...");
            await RegisterCommandsAsync();
            Console.WriteLine("Commands registered.");
        }

        public async Task RegisterCommandsAsync()
        {
            // Register command modules
            await _manager.commands.AddModulesAsync(Assembly.GetEntryAssembly(), _manager.services);
            await _manager.interactions.AddModulesAsync(Assembly.GetEntryAssembly(), _manager.services);

            // Register slash commands globally
            try
            {
                await _manager.interactions.RegisterCommandsGloballyAsync();
                Console.WriteLine("Slash commands registered globally.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering slash commands: {ex.Message}");
            }

            // Add event handlers
            _manager.client.MessageReceived += HandleCommandAsync;
            _manager.client.InteractionCreated += HandleInteractionAsync;
        }

        private async Task HandleCommandAsync(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            if (message == null || message.Author.IsBot) return;

            var context = new SocketCommandContext(_manager.client, message);
            int argPos = 0;

            if (message.HasStringPrefix("/", ref argPos) || message.HasMentionPrefix(_manager.client.CurrentUser, ref argPos))
            {
                var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
                if (!result.IsSuccess)
                {
                    Console.WriteLine($"Command execution failed: {result.ErrorReason}");
                }
            }
            else await HandleCommandAsyncSpec(args);
        }

        private async Task HandleCommandAsyncSpec(SocketMessage args)
        {
            var message = args as SocketUserMessage;
            string[] filters = { "what am i", "who am i?", "download" };
            var context = new SocketCommandContext(_manager.client, message);

            string content = message.Content;

            bool contains = filters.Any(filter => content.ToLower().Contains(filter.ToLower()));

            int argPos = 0;

            if (contains)
            {
                try
                {
                    var result = await _manager.commands.ExecuteAsync(context, argPos, _manager.services);
                    if (!result.IsSuccess)
                    {
                        Console.WriteLine($"Filtered command execution failed: {result.ErrorReason}");
                        Console.WriteLine(context.Message.Content);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception during filtered command execution: {ex.Message}");
                    Console.WriteLine(message.Content);
                }
            }
        }

        private async Task HandleInteractionAsync(SocketInteraction interaction)
        {
            var scope = _manager.services.CreateScope();
            var context = new SocketInteractionContext(_manager.client, interaction);
            var result = await _manager.interactions.ExecuteCommandAsync(context, scope.ServiceProvider);

            if (!result.IsSuccess)
            {
                Console.WriteLine($"Interaction execution failed: {result.ErrorReason}");
            }
        }
    }
}
