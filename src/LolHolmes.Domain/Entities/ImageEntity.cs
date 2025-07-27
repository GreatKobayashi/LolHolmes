namespace LolHolmes.Domain.Entities
{
    public class ImageEntity
    {
        public ImageEntity(string url)
        {
            Url = url;
        }

        public string Url { get; private set; }
    }
}
