using Discord;
using Discord.Commands;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using WebResponder.Managers;

namespace RandoDiscordBot
{
    public class ClientManager
    {
        public DiscordSocketClient client { get; private set; }
        public CommandService commands { get; private set; }
        public InteractionService interactions { get; private set; }
        public IServiceProvider services { get; private set; }
        public APIKeys keys = APIKeys.GetKeysFromJson();
        public AnimeManager animeStats { get; private set; }
        public StockManager stockManager { get; private set; }
        public MemeManager memeManager { get; private set; }
        public RiotManager riotManager { get; private set; }

        private static ClientManager _manager;

        private ClientManager()
        {
            var config = new DiscordSocketConfig
            {
                GatewayIntents = GatewayIntents.Guilds | GatewayIntents.GuildMessages | GatewayIntents.MessageContent
            };

            client = new DiscordSocketClient(config);
            commands = new CommandService();
            interactions = new InteractionService(client);

            interactions = new InteractionService(client);

            animeStats = new AnimeManager(keys.MALKey);
            stockManager = new StockManager(keys.StockKey);
            memeManager = new MemeManager();
            riotManager = new RiotManager(keys.RiotLeagueKey);

            // Singleton ensure only one bot is running at a time
            services = new ServiceCollection()
                .AddSingleton(client)
                .AddSingleton(commands)
                .AddSingleton(interactions)
                .BuildServiceProvider();
        }

        public static ClientManager GetClientManager()
        {
            if (_manager != null)
            {
                return _manager;
            }
            else
            {
                _manager = new ClientManager();
                return _manager;
            }
        }
    }
}
