using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MangachanParser.Entity;
using MangachanParser.Parser;
using MangaReader.Client.Navigate;

namespace MangaReader.Client.ViewModel
{
    class LoginPageViewModel : ViewModelBase
    {
        private ParserHelper _parserManager;
        private ICommand _onLoginCommand;
        private string _login;
        private string _password;
        private INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            _parserManager = new ParserHelper();

        }
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged(() => Login);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }
        public ICommand OnLoginCommand
        {
            get
            {
                return _onLoginCommand ?? (_onLoginCommand = new RelayCommand(async () =>
                {
                    var userManager = new UserParser();
                    var user = await userManager.GetUser(Login, Password);
                }));
            }
        }
    }
}
