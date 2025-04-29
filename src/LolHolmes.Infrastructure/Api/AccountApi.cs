using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Repositories;
using RiotApiWrapper.Logics;

namespace LolHolmes.Infrastructure.Api
{
    public class AccountApi : RiotApiBase, IAccountRepository
    {
        public AccountApi(string apiKey) : base(apiKey)
        {
        }

        public async Task<AccountEntity> GetEntity(Server server, string riotId, string tagLine)
        {
            var platform = ApiHelper.GetPlatformFromServer(server);
            var region = RiotHelper.GetRegionFromPlatform(platform);
            var account = await Api.Account.GetByGameIdAsync(region, riotId, tagLine);
            var summoner = await Api.Summoner.GetByPuuIdAsync(platform, account.PuuId);

            return new(account.PuuId, server, account.GameName, account.TagLine, summoner.SummonerLevel, summoner.ProfileIconId);
        }
    }
}
