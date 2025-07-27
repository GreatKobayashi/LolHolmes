using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Infrastructure;

namespace TestLolHolmes.Infrastructure.Api
{
    [TestClass]
    public class AccountApiTests
    {
        [TestMethod]
        public async Task TestGetEntity()
        {
            var accountApi = Factories.CreateAccountRepository();
            var result = await accountApi.GetEntity(Server.Japan, "裸だったら何が悪い", "5444");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Task<NameEntity>));
        }
    }
}
