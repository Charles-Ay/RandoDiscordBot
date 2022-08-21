using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimeStats;

namespace RandoDiscordBot
{
    public class ClientManager
    {
        public DiscordSocketClient client { get; private set; }
        public CommandService commands { get; private set; }
        public IServiceProvider services { get; private set; }
        public AnimeStats.AnimeStats animeStats { get; private set; }

        private static ClientManager _manager;

        private ClientManager()
        {
            client = new DiscordSocketClient();
            commands = new CommandService();
            animeStats = new AnimeStats.AnimeStats();
            //singletone ensure only one bot is running at a time
            services = new ServiceCollection().AddSingleton(client).AddSingleton(commands).BuildServiceProvider();
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
