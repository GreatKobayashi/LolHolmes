using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.Infrastructure.Fake
{
    public class NameFake : INameRepository
    {
        private static readonly List<NameEntity> _nameList = new List<NameEntity>
        {
            new NameEntity("裸だったら何が悪い", "5444", DateTime.Now),
            new NameEntity("裸だったら何が悪い", "5444", DateTime.Now.AddDays(-10)),
            new NameEntity("裸だったら何が悪い", "5444", DateTime.Now.AddDays(-20)),
            new NameEntity("Duster", "JP1", DateTime.Now.AddDays(-30)),
            new NameEntity("Duster", "JP1", DateTime.Now.AddDays(-40)),
        };

        private static int _count = 0;

        public Task<NameEntity> GetLastEntity(AccountEntity account, int start, int count)
        {
            if (_count >= _nameList.Count)
            {
                return Task.FromResult(_nameList.Last());
            }
            return Task.FromResult(_nameList[_count++]);
        }
    }
}
