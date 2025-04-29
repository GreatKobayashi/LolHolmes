using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;

namespace LolHolmes.Domain.Repositories
{
    public interface IAccountRepository
    {
        public Task<AccountEntity> GetEntity(Server region, string riotId, string tagLine);
    }
}
