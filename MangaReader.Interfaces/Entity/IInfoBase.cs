using System.Collections.ObjectModel;
using Windows.UI.Xaml.Media;

namespace MangaReader.Interfaces.Entity
{
    public interface IINfoBase
    {
        ImageSource Image { get; set; }
        string EnName { get; set; }
        string RusName { get; set; }
        string Description { get; set; }
        string Status { get; set; }
        ObservableCollection<ITag> Tags { get; set; }
    }
}