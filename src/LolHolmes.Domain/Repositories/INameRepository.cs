using LolHolmes.Domain.Entities;

namespace LolHolmes.Domain.Repositories
{
    public interface INameRepository
    {
        public Task<List<NameEntity>> GetEntities(AccountEntity account, int page);
    }
}
