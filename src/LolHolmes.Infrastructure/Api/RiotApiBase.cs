using RiotApiWrapper;

namespace LolHolmes.Infrastructure.Api
{
    public class RiotApiBase
    {
        protected readonly RiotApi Api;

        internal RiotApiBase()
        {
            Api = new RiotApi(InfraSetting.ApiKey);
        }
    }
}
