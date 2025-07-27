using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Exceptions;
using LolHolmes.Domain.Repositories;
using RiotApiWrapper.Entities;
using RiotApiWrapper.Exceptions;
using RiotApiWrapper.Logics;
using AccountEntity = LolHolmes.Domain.Entities.AccountEntity;

namespace LolHolmes.Infrastructure.Api
{
    public class AccountApi : RiotApiBase, IAccountRepository
    {
        private static string _soloRankQueueName = "RANKED_SOLO_5x5";
        private static string _flexRankQueueName = "RANKED_FLEX_SR";
        private static Dictionary<string, Tier> _tierEnumMaps = new()
        {
            { "IRON", Tier.Iron },
            { "BRONZE", Tier.Bronze },
            { "SILVER", Tier.Silver },
            { "GOLD", Tier.Gold },
            { "PLATINUM", Tier.Platinum },
            { "EMERALD", Tier.Emerald },
            { "DIAMOND", Tier.Diamond },
            { "MASTER", Tier.Master },
            { "GRANDMASTER", Tier.GrandMaster },
            { "CHALLENGER", Tier.Challenger },
        };
        private static Dictionary<string, int> _divisionNumMaps = new()
        {
            { "I", 1 },
            { "II", 2 },
            { "III", 3 },
            { "IV", 4 },
        };
        private static List<string> _accountNotFoundErrorMessages = new()
        {
            InfraSetting.AccountNotFoundErrorMessage, InfraSetting.SummonerNotFoundErrorMessage
        };

        public async Task<AccountEntity> GetEntity(Server server, string riotId, string tagLine)
        {
            try
            {
                var platform = ApiHelper.GetPlatformFromServer(server);
                var region = RiotHelper.GetRegionFromPlatform(platform);
                var account = await Api.Account.GetByGameIdAsync(region, riotId, tagLine);
                var summoner = await Api.Summoner.GetByPuuIdAsync(platform, account.PuuId);
                var entries = await Api.League.GetEntriesByPuuIdAsync(platform, account.PuuId);
                var soloRank = CreateRankEntity(entries.FirstOrDefault(x => x.QueueType == _soloRankQueueName));
                var flexRank = CreateRankEntity(entries.FirstOrDefault(x => x.QueueType == _flexRankQueueName));

                return new(account.PuuId, server, account.GameName, account.TagLine, summoner.SummonerLevel, summoner.ProfileIconId, soloRank, flexRank);
            }
            catch (RiotApiException ex)
            {
                if (_accountNotFoundErrorMessages.Contains(ex.Message))
                {
                    throw new AccountApiException(ex, ErrorCode.AccountNotFound);
                }
                else if (ex.Message == InfraSetting.OverRequestLimitErrorMessage)
                {
                    throw new AccountApiException(ex, ErrorCode.OverRequestLimit);
                }
                throw new AccountApiException(ex);
            }
            catch (Exception ex)
            {
                throw new AccountApiException(ex, ErrorCode.Unexpected);
            }
        }

        private static RankEntity? CreateRankEntity(LeagueEntryEntity? leagueEntry)
        {
            if (leagueEntry == null)
            {
                return null;
            }
            return new RankEntity(
                _tierEnumMaps[leagueEntry.Tier], _divisionNumMaps[leagueEntry.Rank], leagueEntry.LeaguePoints, leagueEntry.Wins, leagueEntry.Losses);
        }
    }
}
