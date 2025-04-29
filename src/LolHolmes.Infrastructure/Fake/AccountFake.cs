using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.Infrastructure.Fake
{
    class AccountFake : IAccountRepository
    {
        public Task<AccountEntity> GetEntity(Server server, string riotId, string tagLine)
        {
            return Task.FromResult(new AccountEntity(
                "vqIB5nx38QS7322H34nNgvaY-eBRxjm94aaDfQdlX2UGSv_qTTmjwLhy3Er2VxrNS1Rt8OmI5iONRQ",
                Server.Japan,
                "裸だったら何が悪い",
                "5444",
                458,
                1153));
        }
    }
}
