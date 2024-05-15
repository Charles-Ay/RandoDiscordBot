using Discord;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebResponder.Retrieval.Riot.League
{
    public class FormatedLeagueEntryData
    {
        public string queueType { get; set; }
        public string tier { get; set; }
        public string rank { get; set; }
        public string summonerName { get; set; }
        public int lp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }

        public FormatedLeagueEntryData(LeagueEntryData leagueEntry)
        {
            queueType = leagueEntry.queueType;
            tier = leagueEntry.tier;
            rank = leagueEntry.rank;
            summonerName = leagueEntry.summonerName;
            lp = leagueEntry.leaguePoints;
            wins = leagueEntry.wins;
            losses = leagueEntry.losses;
        }
        
        public static Task<List<FormatedLeagueEntryData>> FormatedLeagueEntryDataList(List<LeagueEntryData> leagueEntry)
        {
            List<FormatedLeagueEntryData> dL = new List<FormatedLeagueEntryData>();
            foreach (LeagueEntryData entry in leagueEntry)
            {
                FormatedLeagueEntryData d = new FormatedLeagueEntryData(entry);
                dL.Add(d);
            }
            return Task.FromResult(dL);
        }

        public Task<EmbedBuilder> ToEmbedBuilder()
        {
            EmbedBuilder builder = new EmbedBuilder();
            builder.Color = Color.Green;
            builder.WithTitle(summonerName);
            if(queueType == "RANKED_SOLO_5x5")builder.WithDescription($"Stats for: Ranked Solo/Duo");
            else if (queueType == "RANKED_FLEX_SR") builder.WithDescription($"Stats for: Ranked Flex");
            else if (queueType == "RANKED_FLEX_TT") builder.WithDescription($"Stats for: Ranked Flex");
            builder.AddField("Rank:", $"{tier} {rank} - {lp} LP");
            builder.AddField("Wins - Losses", $"{wins} - {losses}");

            return Task.FromResult(builder);
        }
    }
}
