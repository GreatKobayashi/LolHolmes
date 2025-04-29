using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Infrastructure.Api;

namespace TestLolHolmes.Infrastructure.Api
{
    [TestClass]
    public class NameApiTests
    {
        [TestMethod]
        public async Task TestGetLastEntity()
        {
            var nameApi = new NameApi(TestUtility.ApiKey);
            var account = new AccountEntity(TestUtility.Puuid, Server.Japan, "裸だったら何が悪い", "5444", 458, 1153);
            var result = await nameApi.GetLastEntity(account, 40, 20);
            Assert.IsNotNull(result);
            //Assert.IsInstanceOfType(result, typeof(Task<NameEntity>));
        }
    }
}
