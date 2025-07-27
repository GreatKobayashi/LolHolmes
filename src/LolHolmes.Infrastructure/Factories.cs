using LolHolmes.Domain;
using LolHolmes.Domain.Repositories;
using LolHolmes.Infrastructure.Api;
using LolHolmes.Infrastructure.Fake;

namespace LolHolmes.Infrastructure
{
    public static class Factories
    {
        public static IAccountRepository CreateAccountRepository()
        {
            if (Shared.IsFake)
            {
                return new AccountFake();
            }
            return new AccountApi();
        }

        public static INameRepository CreateNameRepository()
        {
            if (Shared.IsFake)
            {
                return new NameFake();
            }
            return new NameApi();
        }

        public static IImageRepository CreateImageRepository()
        {
            if (Shared.IsFake)
            {
            }
            return new ImageApi();
        }
    }
}
