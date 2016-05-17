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
    public class MangaInfo : IMangaInfo
    {
        public ImageSource Image { get; set; }
        public string EnName { get; set; }
        public string RusName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ObservableCollection<ITag> Tags { get; set; }
        public string AnotherNames { get; set; }
        public string Author { get; set; }
        public string DownloadingStatus { get; set; }
        public string Translater { get; set; }
        public string ReadUrl { get; set; }
        public ObservableCollection<IChapter> Chapters { get; set; }
    }
}
