using LolHolmes.Domain.Enums;

namespace LolHolmes.Domain.Entities
{
    public class AccountEntity
    {
        public AccountEntity(string puuId, Server server, string currentName, string currentTagLine, int level, int profileIcon)
        {
            PuuId = puuId;
            Server = server;
            CurrentName = currentName;
            CurrentTagLine = currentTagLine;
            Level = level;
            ProfileIcon = profileIcon;
        }

        public string PuuId { get; private set; }
        public Server Server { get; private set; }
        public string CurrentName { get; private set; }
        public string CurrentTagLine { get; private set; }
        public int Level { get; private set; }
        public int ProfileIcon { get; private set; }
    }
}
