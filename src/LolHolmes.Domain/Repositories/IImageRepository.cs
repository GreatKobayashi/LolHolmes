using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;

namespace LolHolmes.Domain.Repositories
{
    public interface IImageRepository
    {
        public ImageEntity GetSummonerIcon(int id);
        public ImageEntity GetRankEmblem(Tier tier);
    }
}
