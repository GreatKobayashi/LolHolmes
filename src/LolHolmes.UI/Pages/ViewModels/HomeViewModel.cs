using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Logics;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.UI.Pages.ViewModels
{
    public class HomeViewModel
    {
        public AccountEntity? Acocunt { get; private set; }
        public ReactiveList<NameEntity> Names { get; private set; } = new();

        private readonly IAccountRepository _accountRepository;
        private readonly INameRepository _nameRepository;

        private readonly int _maxGoBackCount = 500;
        private readonly int _betweens = 20;

        public HomeViewModel(IAccountRepository accountRepository, INameRepository nameRepository)
        {
            _accountRepository = accountRepository;
            _nameRepository = nameRepository;
        }

        public async Task LoadAccount(string riotId, string tagLine)
        {
            Acocunt = await _accountRepository.GetEntity(Server.Japan, riotId, tagLine);
        }

        public async Task SerchPriviousName()
        {
            var goBackCount = 0;

            while (goBackCount < _maxGoBackCount)
            {
                var gotName = await _nameRepository.GetLastEntity(Acocunt!, goBackCount, _betweens);
                if (Names.Find(x => x.RiotId == gotName.RiotId) == null)
                {
                    Names.Add(gotName);
                }
                goBackCount += _betweens;
            }
        }
    }
}
