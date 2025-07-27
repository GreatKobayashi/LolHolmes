using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Infrastructure;

namespace TestLolHolmes.Infrastructure.Api
{
    [TestClass]
    public class NameApiTests
    {
        [TestMethod]
        public async Task TestGetEntities()
        {
            var nameApi = Factories.CreateNameRepository();
            var rank = new RankEntity(Tier.Bronze, 1, 1, 1, 1);
            var account = new AccountEntity(TestUtility.Puuid, Server.Japan, "裸だったら何が悪い", "5444", 458, 1153, rank, rank);
            var result = await nameApi.GetEntities(account, 1);
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(Task<NameEntity>));
        }
    }
}
