using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Exceptions;
using LolHolmes.Domain.Repositories;
using RiotApiWrapper.Entities.Match.Info;
using RiotApiWrapper.Exceptions;
using RiotApiWrapper.Logics;
using RiotApiWrapper.Misc;
using System.Net;

namespace LolHolmes.Infrastructure.Api
{
    public class NameApi : RiotApiBase, INameRepository
    {
        private static readonly int _matchesPerPage = 100;
        private static readonly long _changeCoolTime = 7776000000;

        public async Task<List<NameEntity>> GetEntities(AccountEntity account, int page)
        {
            if (page < 1)
            {
                throw new NameApiException(ErrorCode.Unexpected);
            }

            try
            {
                var platform = ApiHelper.GetPlatformFromServer(account.Server);
                var region = RiotHelper.GetRegionFromPlatform(platform);

                var entities = new List<NameEntity>();
                var start = _matchesPerPage * (page - 1);
                var matches = _matchesPerPage;
                while (true)
                {
                    var matchIds = await Api.Match.GetIdsAsync(region, account.PuuId, start: start, count: matches);

                    if (matchIds.Count == 0)
                    {
                        break;
                    }
                    var firstMatch = await GetMatchInfo(true, region, matchIds);
                    var lastMatch = await GetMatchInfo(false, region, matchIds);

                    var participantInFirstMatch = firstMatch.Info.Participants.First(x => x.Puuid == account.PuuId);
                    var participantInLastMatch = lastMatch.Info.Participants.First(x => x.Puuid == account.PuuId);

                    entities.Add(CreateEntity(firstMatch, participantInFirstMatch));

                    var nameInFirstMatch = participantInFirstMatch.RiotIdGameName ?? participantInFirstMatch.SummonerName;
                    var nameInLstMatch = participantInLastMatch.RiotIdGameName ?? participantInLastMatch.SummonerName;
                    if (nameInFirstMatch != nameInLstMatch)
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
                        if (!string.IsNullOrEmpty(participantInLastMatch.SummonerName))
                        {
                            entities.Add(CreateEntity(lastMatch, participantInLastMatch.SummonerName, ""));
                        }
                        break;
                    }
                }
                return entities.GroupBy(x => x.RiotId).Select(x => x.First()).ToList();
            }
            catch (RiotApiException ex)
            {
                if (ex.Message == InfraSetting.OverRequestLimitErrorMessage)
                {
                    throw new NameApiException(ex, ErrorCode.OverRequestLimit);
                }
                throw new NameApiException(ex);
            }
            catch (Exception ex)
            {
                throw new NameApiException(ex, ErrorCode.Unexpected);
            }
        }

        private async Task<RiotApiWrapper.Entities.MatchEntity> GetMatchInfo(bool isTargetFirstMatch, Region region, List<string> matchIds, int trys = 0)
        {
            var index = isTargetFirstMatch ? trys : matchIds.Count - 1 - trys;
            try
            {
                return await Api.Match.GetInfoAsync(region, matchIds[index]);
            }
            catch (RiotApiException ex)
            {
                // ゲームモードがブロウルの時に403になる
                if (ex.HttpStatusCode == HttpStatusCode.Forbidden)
                {
                    return await GetMatchInfo(isTargetFirstMatch, region, matchIds, trys + 1);
                }
                else
                {
                    throw;
                }
            }
        }

        private NameEntity CreateEntity(RiotApiWrapper.Entities.MatchEntity match, ParticipantEntity participant)
        {
            return CreateEntity(match, participant.RiotIdGameName ?? participant.SummonerName!, participant.RiotIdTagline);
        }

        private NameEntity CreateEntity(RiotApiWrapper.Entities.MatchEntity match, string name, string tagLine)
        {
            var timeStamp = RiotHelper.ConvertTimestampToDateTime(match.Info.GameStartTimestamp);
            return new(name, tagLine, timeStamp);
        }
    }
}
