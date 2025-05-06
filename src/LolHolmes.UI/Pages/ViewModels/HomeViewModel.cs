using CommunityToolkit.Mvvm.ComponentModel;
using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Logics;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.UI.Pages.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [ObservableProperty]
        public partial AccountEntity? Account { get; private set; }
        public ReactiveList<NameEntity> Names { get; private set; } = new();

        private readonly IAccountRepository _accountRepository;
        private readonly INameRepository _nameRepository;

        private readonly int _maxPages = 5;

        public HomeViewModel(IAccountRepository accountRepository, INameRepository nameRepository)
        {
            _accountRepository = accountRepository;
            _nameRepository = nameRepository;
        }

        public async Task LoadAccount(string riotId, string tagLine)
        {
            Account = await _accountRepository.GetEntity(Server.Japan, riotId, tagLine);
        }

        public async Task SerchPriviousName()
        {
            var page = 1;

            while (page <= _maxPages)
            {
                var gotNames = await _nameRepository.GetEntities(Account!, page);
                foreach (var entity in gotNames)
                {
                    if (Names.Find(x => x.RiotId == entity.RiotId) == null)
                    {
                        Names.Add(entity);
                    }
                }
                page++;
            }
        }
    }
}
