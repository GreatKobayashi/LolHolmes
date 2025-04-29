using RiotApiWrapper;

namespace LolHolmes.Infrastructure.Api
{
    public class RiotApiBase
    {
        protected readonly RiotApi Api;

        public RiotApiBase(string apiKey)
        {
            Api = new RiotApi(apiKey);
        }
    }
}
