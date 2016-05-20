using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MangachanParser.Entity;
using MangachanParser.Parser;
using MangaReader.Client.Navigate;
using MangaReader.Interfaces.Entity;

namespace MangaReader.Client.ViewModel
{
    class AboutMangaPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ICatalogTile _catalogTile;
        private IMangaInfo _mangaInfo;
        private ICommand _toReadCommand;
        private ICommand _onLoadCommand;
        public ObservableCollection<IChapter> Chapters { get; set; }
        private bool _processingRingVisible;
        private bool _mainViewVisible;

        public AboutMangaPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            if (!(_navigationService.NavigatedParametr is ICatalogTile)) return;
            _catalogTile = (ICatalogTile)_navigationService.NavigatedParametr;
            PagesInfo = new MangaInfo { Chapters = new ObservableCollection<IChapter>() };
            MainViewVisible = false;
        }

        public bool ProcessingRingVisible
        {
            get { return _processingRingVisible; }
            set
            {
                _processingRingVisible = value;
                RaisePropertyChanged(() => ProcessingRingVisible);
            }
        }

        public bool MainViewVisible
        {
            get { return _mainViewVisible; }
            set
            {
                _mainViewVisible = value;
                RaisePropertyChanged(() => MainViewVisible);
            }
        }

        public IMangaInfo PagesInfo
        {
            get { return _mangaInfo; }
            set
            {
                _mangaInfo = value;
                RaisePropertyChanged(() => PagesInfo);
                ProcessingRingVisible = false;
                MainViewVisible = true;
            }
        }

        public ICommand OnLoadCommand
        {
            get
            {
                return _onLoadCommand ?? (_onLoadCommand = new RelayCommand(async () =>
                {
                    ProcessingRingVisible = true;
                    var parser = new InfoParser<MangaInfo, Tag, Chapter>(_catalogTile.UrlToInfo);
                    var nInf = await parser.GetInfoAsync();
                    nInf.Image = _catalogTile.Image;
                    nInf.EnName = _catalogTile.EnName;
                    nInf.RusName = _catalogTile.RusName;
                    PagesInfo = nInf;

                }));
            }
        }

        public ICommand ToReadCommand
        {
            get
            {
                return _toReadCommand ?? (_toReadCommand = new RelayCommand(() =>
                {
                    //_navigationService.Navigate(typeof(Page3), PagesInfo.ReadUrl);

                }));
            }
        }
    }
}
