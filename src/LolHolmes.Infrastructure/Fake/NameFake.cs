using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.Infrastructure.Fake
{
    public class NameFake : INameRepository
    {
        private static readonly List<NameEntity> _nameList = new List<NameEntity>
        {
            new NameEntity("裸だったら何が悪い", "5444", DateTime.Now),
            new NameEntity("Duster", "JP1", DateTime.Now.AddDays(-40)),
        };

        public Task<List<NameEntity>> GetEntities(AccountEntity account, int page)
        {
            return Task.FromResult(_nameList);
        }
    }
}
