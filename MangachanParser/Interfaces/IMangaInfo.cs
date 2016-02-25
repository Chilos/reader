using System.Collections.ObjectModel;

namespace MangachanParser.Interfaces
{
    public interface IMangaInfo : IINfoBase
    {
        string AnotherNames { get; set; }
        string Author { get; set; }
        string DownloadingStatus { get; set; }
        string Translater { get; set; }
        string ReadUrl { get; set; }
        ObservableCollection<IChapter> Chapters { get; set; }
    }
}