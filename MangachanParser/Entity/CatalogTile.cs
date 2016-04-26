using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using MangaReader.Interfaces.Entity;

namespace MangachanParser.Entity
{
    class CatalogTile : ICatalogTile
    {
        public ImageSource Image { get; set; }
        public string EnName { get; set; }
        public string RusName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ObservableCollection<ITag> Tags { get; set; }
        public string UrlToInfo { get; set; }
        public int ChapterCount { get; set; }
        public bool IsEnded { get; set; }
        public bool IsSingle { get; set; }
    }
}
