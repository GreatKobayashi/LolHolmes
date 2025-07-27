using CDragonWrapper.DataTypes;
using CDragonWrapper.Logics;
using CDragonWrapper.Misc;
using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.Infrastructure.Api
{
    public class ImageApi : IImageRepository
    {
        private static SummonerIconList _summonerIcons = new();

        public ImageEntity GetSummonerIcon(int id)
        {
            return new(_summonerIcons.First(x => x.Id == id).ImageUrl!);
        }

        public ImageEntity GetRankEmblem(Tier tier)
        {
            var rank = (Rank)Enum.Parse(typeof(Rank), tier.ToString());
            return new(UrlManager.Image.GetRankEmblemUrl(rank));
        }
    }
}
