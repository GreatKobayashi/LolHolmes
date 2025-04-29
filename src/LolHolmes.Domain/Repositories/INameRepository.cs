using LolHolmes.Domain.Entities;

namespace LolHolmes.Domain.Repositories
{
    public interface INameRepository
    {
        public Task<NameEntity> GetLastEntity(AccountEntity account, int start, int count);
    }
}
