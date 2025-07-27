using LolHolmes.Domain.Enums;

namespace LolHolmes.Domain.Entities
{
    public class RankEntity
    {
        public RankEntity(Tier tier, int division, int point, int wins, int losses)
        {
            Tier = tier;
            Division = division;
            Point = point;
            Wins = wins;
            Losses = losses;
        }

        public Tier Tier { get; private set; }
        public int Division { get; private set; }
        public int Point { get; private set; }
        public int Wins { get; private set; }
        public int Losses { get; private set; }
    }
}
