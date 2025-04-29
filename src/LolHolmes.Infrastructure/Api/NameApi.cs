using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Repositories;
using RiotApiWrapper.Logics;

namespace LolHolmes.Infrastructure.Api
{
    public class NameApi : RiotApiBase, INameRepository
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public NameApi(string apiKey) : base(apiKey)
        {
        }

        public async Task<NameEntity> GetLastEntity(AccountEntity account, int start, int count)
        {
            var platform = ApiHelper.GetPlatformFromServer(account.Server);
            var region = RiotHelper.GetRegionFromPlatform(platform);

            var matchIds = await Api.Match.GetIdsAsync(region, account.PuuId, start: start, count: count);

            var matchInfo = await Api.Match.GetInfoAsync(region, matchIds.Last());

            var priviousName = matchInfo.Info.Participants.First(x => x.Puuid == account.PuuId).RiotIdGameName;
            var timeStamp = _unixEpoch.AddSeconds(matchInfo.Info.GameStartTimestamp / 1000).ToLocalTime();

            return new NameEntity(priviousName, timeStamp);
        }
    }
}
