using LolHolmes.Domain.Enums;

namespace LolHolmes.Domain.Entities
{
    public class AccountEntity
    {
        public AccountEntity(
            string puuId,
            Server server,
            string currentRiotId,
            string currentTagLine,
            int level,
            int profileIcon,
            RankEntity? soloRank,
            RankEntity? flexRank)
        {
            PuuId = puuId;
            Server = server;
            CurrentRiotId = currentRiotId;
            CurrentTagLine = currentTagLine;
            Level = level;
            ProfileIcon = profileIcon;
            SoloRank = soloRank;
            FlexRank = flexRank;
        }

        public string PuuId { get; private set; }
        public Server Server { get; private set; }
        public string CurrentRiotId { get; private set; }
        public string CurrentTagLine { get; private set; }
        public int Level { get; private set; }
        public int ProfileIcon { get; private set; }
        public RankEntity? SoloRank { get; private set; }
        public RankEntity? FlexRank { get; private set; }
    }
}
