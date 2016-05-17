using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Ioc;
using MangaReader.Client.Navigate;

namespace MangaReader.Client.ViewModel
{
    class ViewModelLocator
    {
        public MainPageViewModel MainPage => SimpleIoc.Default.GetInstance<MainPageViewModel>();

        //public Page3ViewModel Page3 => SimpleIoc.Default.GetInstance<Page3ViewModel>();
        //public Page2ViewModel Page2 => SimpleIoc.Default.GetInstance<Page2ViewModel>();
        public AboutMangaPageViewModel AboutPage => SimpleIoc.Default.GetInstance<AboutMangaPageViewModel>();
        public CatalogPageViewModel CatalogPage => SimpleIoc.Default.GetInstance<CatalogPageViewModel>();

        public ViewModelLocator()
        {
            SimpleIoc.Default.Unregister<INavigationService>();
            var navigationService = new NavigationService((Frame)Window.Current.Content);
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);

            SimpleIoc.Default.Register<MainPageViewModel>();
            //SimpleIoc.Default.Register<Page3ViewModel>();
            //SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<AboutMangaPageViewModel>();
            SimpleIoc.Default.Register<CatalogPageViewModel>();
        }

        public ViewModelLocator(Frame frame)
        {
            //ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Unregister<INavigationService>();
            var navigationService = new NavigationService(frame);
            SimpleIoc.Default.Register<INavigationService>(() => navigationService);
            SimpleIoc.Default.Register<MainPageViewModel>();
            //SimpleIoc.Default.Register<Page3ViewModel>();
            //SimpleIoc.Default.Register<Page2ViewModel>();
            SimpleIoc.Default.Register<AboutMangaPageViewModel>();
            SimpleIoc.Default.Register<CatalogPageViewModel>();
        }

    }
}
