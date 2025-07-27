namespace LolHolmes.Domain.Entities
{
    public class NameEntity
    {
        public NameEntity(string riotId, string tagLine, DateTime timeStamp)
        {
            RiotId = riotId;
            TagLine = tagLine;
            TimeStamp = timeStamp;
        }

        public string RiotId { get; private set; }
        public string TagLine { get; private set; }
        public DateTime TimeStamp { get; private set; }
    }
}
