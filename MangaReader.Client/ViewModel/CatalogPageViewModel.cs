using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MangaReader.Client.Navigate;
using MangaReader.Interfaces.Entity;
using MangachanParser.Entity;
using MangachanParser.Parser;
using MangaReader.Client.View.Pages;

namespace MangaReader.Client.ViewModel
{
    class CatalogPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private ICommand _onLoadCommand;
        private ICommand _onScrollCommand;
        private bool _processingRingVisible;
        private double _verticalOffset;
        private double _holdVerticalOffset;
        private RelayCommand<ICatalogTile> _showMangaInfo;
        readonly CatalogParser<CatalogTile> _parser;
        public ObservableCollection<ICatalogTile> Tiles { get; set; }

        public CatalogPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Tiles = new ObservableCollection<ICatalogTile>();
            _parser = new CatalogParser<CatalogTile>();

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

        public double VerticalOffset
        {
            get { return _verticalOffset; }
            set
            {
                _verticalOffset = value;
                RaisePropertyChanged(() => VerticalOffset);
            }
        }

        public ICommand OnLoadCommand
        {
            get
            {
                return _onLoadCommand ?? (_onLoadCommand = new RelayCommand(() =>
                {


                    if (Tiles.Count != 0)
                    {
                        VerticalOffset = 0;
                        VerticalOffset = _holdVerticalOffset;
                        return;
                    }
                    ProcessingRingVisible = true;
                    Tiles.CollectionChanged += Tiles_CollectionChanged;
                    _parser.GetCatalogAsync(Tiles);
                }));
            }
        }

        public ICommand OnScrollCommand
        {
            get
            {
                return _onScrollCommand ?? (_onScrollCommand = new RelayCommand(() =>
                {
                    ProcessingRingVisible = true;
                    _parser.GetCatalogAsync(Tiles, Tiles.Count);
                }));
            }
        }

        private void Tiles_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            ProcessingRingVisible = false;
        }

        public RelayCommand<ICatalogTile> ShowMangaInfo
        {
            get
            {
                return _showMangaInfo ?? (_showMangaInfo = new RelayCommand<ICatalogTile>(o =>
                {
                    _holdVerticalOffset = VerticalOffset;
                    _navigationService.Navigate(typeof(AboutMangaPageView), o);

                }));
            }
        }
    }
}

