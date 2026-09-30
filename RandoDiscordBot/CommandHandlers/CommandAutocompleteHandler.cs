using Discord;
using System;
using Discord.Interactions;
using System.Threading.Tasks;
using System.Collections.Generic;


namespace RandoDiscordBot.CommandHandlers
{
    public class CommandAutocompleteHandler : AutocompleteHandler
    {
        public override async Task<AutocompletionResult> GenerateSuggestionsAsync(IInteractionContext context, IAutocompleteInteraction autocompleteInteraction, IParameterInfo parameter, IServiceProvider services)
        {
            // Example suggestions based on available commands
            var suggestions = new List<AutocompleteResult>
            {
                new AutocompleteResult("ping", "Ping Server"),
                new AutocompleteResult("hello", "Hello"),
                new AutocompleteResult("info", "Info"),
                new AutocompleteResult("meme", "Generate A random Meme"),
                new AutocompleteResult("top_anime", "Top Anime"),
                new AutocompleteResult("top_airing", "top Airing Anime"),
                new AutocompleteResult("Stock", "Stack Stock Market Data"),
            };

            return AutocompletionResult.FromSuccess(suggestions);
        }
    }
}
