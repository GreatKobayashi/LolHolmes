namespace LolHolmes.Domain.Entities
{
    public class NameEntity
    {
        public string Value { get; private set; }
        public DateTime TimeStamp { get; private set; }

        public NameEntity(string value, DateTime timeStamp)
        {
            Value = value;
            TimeStamp = timeStamp;
        }
    }
}
