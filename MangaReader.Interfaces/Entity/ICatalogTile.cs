using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;

namespace MangaReader.Interfaces.Entity
{
    public interface ICatalogTile
    {
        ImageSource Image { get; set; }
        string EnName { get; set; }
        string RusName { get; set; }
        string Description { get; set; }
        string Status { get; set; }
        ObservableCollection<ITag> Tags { get; set; }
        string UrlToInfo { get; set; }
        string ChapterCount { get; set; }
        bool IsEnded { get; set; }
        bool IsSingle { get; set; }
    }
}