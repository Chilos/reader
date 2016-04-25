namespace MangaReader.Interfaces.Entity
{
    public interface IChapter
    {
        string Name { get; set; }
        string Date { get; set; }
        string Url { get; set; }
    }
}