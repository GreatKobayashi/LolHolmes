namespace LolHolmes.Infrastructure
{
    internal static class InfraSetting
    {
        internal static string ApiKey { get; } = "RGAPI-c28ba482-1c4d-4b77-b0bc-5a67064e5d0a";

        // RiotApiWrapperが出すエラーメッセージ
        internal static string AccountNotFoundErrorMessage => "Account Not Found.";
        internal static string SummonerNotFoundErrorMessage => "Summoner Not Found.";
        internal static string OverRequestLimitErrorMessage => "Over the request limit.";
    }
}
