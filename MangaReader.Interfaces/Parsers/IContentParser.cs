using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using MangaReader.Interfaces.Entity;

namespace MangaReader.Interfaces.Parsers
{
    public interface IContentParser
    {
        Task<WriteableBitmap> GetImageFromUrl(string url);
        void GetMangaImagesAsync(ObservableCollection<IContent> mangaImages);
    }
}
