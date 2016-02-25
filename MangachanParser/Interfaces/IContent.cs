using Windows.UI.Xaml.Media.Imaging;

namespace MangachanParser.Interfaces
{
    public interface IContent
    {
        WriteableBitmap Image { get; set; }
        string Title { get; set; }
        string PageNamber { get; set; }
        string Chapter { get; set; }
    }
}