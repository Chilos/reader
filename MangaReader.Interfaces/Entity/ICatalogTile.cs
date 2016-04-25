namespace MangaReader.Interfaces.Entity
{
    public interface ICatalogTile : IINfoBase
    {
        string UrlToInfo { get; set; }
        int ChapterCount { get; set; }
        bool IsEnded { get; set; }
        bool IsSingle { get; set; }
    }
}