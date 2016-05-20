using MangaReader.Client.ViewModel;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using MangaReader.Client.Navigate;

// Шаблон элемента пустой страницы задокументирован по адресу http://go.microsoft.com/fwlink/?LinkId=234238

namespace MangaReader.Client.View.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class AboutMangaPageView : Page
    {
        public AboutMangaPageView()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DataContext = new AboutMangaPageViewModel(new NavigationService(this.Frame) { NavigatedParametr = e.Parameter });
        }
    }

    

}
