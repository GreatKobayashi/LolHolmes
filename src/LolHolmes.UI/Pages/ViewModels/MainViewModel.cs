using LolHolmes.Domain.Entities;
using LolHolmes.Domain.Enums;
using LolHolmes.Domain.Exceptions;
using LolHolmes.Domain.Repositories;

namespace LolHolmes.UI.Pages.ViewModels
{
    public class MainViewModel
    {
        private static readonly int _pagesPerSearch = 5;

        private readonly IAccountRepository _accountRepository;
        private readonly INameRepository _nameRepository;
        private int _startPage = 1;
        private bool _isLimit = false;

        public MainViewModel(IAccountRepository accountRepository, INameRepository nameRepository)
        {
            _accountRepository = accountRepository;
            _nameRepository = nameRepository;
        }

        public async Task<AccountEntity> LoadAccount(string riotId, string tagLine)
        {
            if (riotId.Length < 3 || riotId.Length > 16)
            {
                throw new AccountSearchException(ErrorCode.InvalidRiotId);
            }
            if (tagLine.Length < 3 || tagLine.Length > 5)
            {
                throw new AccountSearchException(ErrorCode.InvalidTagLine);
            }

            var account = await _accountRepository.GetEntity(Server.Japan, riotId, tagLine);

            // 初期化処理
            _startPage = 1;
            _isLimit = false;

            return account;
        }

        public async Task<List<NameEntity>> SearchPriviousName(AccountEntity account)
        {
            if (_isLimit)
            {
                throw new NameSearchException(ErrorCode.NameSearchLimit);
            }

            var page = _startPage;
            var names = new List<NameEntity>();

            while (page < _startPage + _pagesPerSearch)
            {
                var gotNames = await _nameRepository.GetEntities(account, page);
                if (gotNames.Count == 0)
                {
                    _isLimit = true;
                    break;
                }

                foreach (var entity in gotNames)
                {
                    if (names.Find(x => x.RiotId == entity.RiotId) == null)
                    {
                        names.Add(entity);
                    }
                }
                page++;
            }

            _startPage += _pagesPerSearch;
            return names;
        }
    }
}
