using LolHolmes.Domain;
using LolHolmes.Domain.Repositories;
using LolHolmes.Infrastructure.Api;
using LolHolmes.Infrastructure.Fake;

namespace LolHolmes.Infrastructure
{
    public static class Factories
    {
        public static IAccountRepository CreateAccountRepository(string apiKey)
        {
            if (Shared.IsFake)
            {
                return new AccountFake();
            }
            return new AccountApi(apiKey);
        }

        public static INameRepository CreateNameRepository(string apiKey)
        {
            if (Shared.IsFake)
            {
                return new NameFake();
            }
            return new NameApi(apiKey);
        }
    }
}
