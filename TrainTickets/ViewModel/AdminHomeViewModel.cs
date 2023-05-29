using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    class AdminHomeViewModel : ViewModelBase
    {
        public ICommand NavigationToRouteAddingPageCommand { get; }
        public ICommand NavigationToStationAddingPageCommand { get; }
        public ICommand NavigationToSignInPageCommand { get; }

        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private int _balance;
        public int Balance { get => _balance; set => _balance = value; }

        public AdminHomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToRouteAddingPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<RouteAddingViewModel>());
            NavigationToStationAddingPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<StationAddingViewModel>());
            NavigationToSignInPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignInViewModel>());

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("admin.json"))!;

            Balance = user.WalletBalance;

        }

        public INavigationService NavigationService
        {
            get => _navigationService;

            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }


    }
}
