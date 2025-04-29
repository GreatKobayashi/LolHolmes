using LolHolmes.Domain.Enums;
using RiotApiWrapper.Misc;

namespace LolHolmes.Infrastructure.Api
{
    public static class ApiHelper
    {
        public static Dictionary<Server, Platform> ServerAbbreviationPairs = new()
        {
            { Server.Brazil, Platform.BR1 },
            { Server.EuropeNordicAndEast, Platform.EUN1 },
            { Server.EuropeWest, Platform.EUW1 },
            { Server.Japan, Platform.JP1 },
            { Server.Korea, Platform.KR },
            { Server.LatinAmericaNorth, Platform.LA1 },
            { Server.LatinAmericaSouth, Platform.LA2 },
            { Server.MiddleEast, Platform.ME1 },
            { Server.NorthAmerica, Platform.NA1 },
            { Server.Oceania, Platform.OC1 },
            { Server.Russia, Platform.RU },
            { Server.SoutheastAsia, Platform.SG2 },
            { Server.Turkey, Platform.TR1 },
            { Server.Taiwan, Platform.TW2 },
            { Server.Vietnam, Platform.VN2 }
        };

        public static Platform GetPlatformFromServer(Server server)
        {
            if (ServerAbbreviationPairs.TryGetValue(server, out Platform platform))
            {
                return platform;
            }
            throw new ArgumentException($"Invalid server: {server}");
        }
    }
}
