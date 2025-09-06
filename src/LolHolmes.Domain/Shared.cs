namespace LolHolmes.Domain
{
    public static class Shared
    {
        public static bool IsFake { get; } = false;
        // 連打でリクエスト上限超過してしまうことの予防
        public static int ActionCoolDownMS { get; } = 1000;
    }
}
