using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Repositories;
using RiotApiWrapper.Entities.Match.Info;
using RiotApiWrapper.Logics;

namespace LolHolmes.Infrastructure.Api
{
    public class NameApi : RiotApiBase, INameRepository
    {
        private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly int _matchesPerPage = 100;
        private static readonly long _changeCoolTime = 7776000000;

        public NameApi(string apiKey) : base(apiKey)
        {
        }

        public async Task<List<NameEntity>> GetEntities(AccountEntity account, int page)
        {
            if (page < 1)
            {
                // TODO
                throw new Exception();
            }

            var platform = ApiHelper.GetPlatformFromServer(account.Server);
            var region = RiotHelper.GetRegionFromPlatform(platform);

            var entities = new List<NameEntity>();
            var start = _matchesPerPage * (page - 1);
            var matches = _matchesPerPage;
            while (true)
            {
                var matchIds = await Api.Match.GetIdsAsync(region, account.PuuId, start: start, count: matches);

                var firstMatch = await Api.Match.GetInfoAsync(region, matchIds.First());
                var lastMatch = await Api.Match.GetInfoAsync(region, matchIds.Last());

                var participantInFirstMatch = firstMatch.Info.Participants.First(x => x.Puuid == account.PuuId);
                var participantInLastMatch = lastMatch.Info.Participants.First(x => x.Puuid == account.PuuId);

                entities.Add(CreateEntity(firstMatch, participantInFirstMatch));
                if (participantInFirstMatch.RiotIdGameName != participantInLastMatch.RiotIdGameName)
                {
                    entities.Add(CreateEntity(lastMatch, participantInLastMatch));
                    if (firstMatch.Info.GameStartTimestamp - lastMatch.Info.GameStartTimestamp > _changeCoolTime)
                    {
                        if (matches < 2)
                        {
                            break;
                        }
                        matches /= 2;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            return entities.GroupBy(x => x.RiotId).Select(x => x.First()).ToList();
        }

        // 納得はしていないが暫定
        private NameEntity CreateEntity(RiotApiWrapper.Entities.MatchEntity match, ParticipantEntity participant)
        {
            var timeStamp = _unixEpoch.AddSeconds(match.Info.GameStartTimestamp / 1000).ToLocalTime();
            return new(participant.RiotIdGameName, participant.RiotIdTagline, timeStamp);
        }
    }
}
