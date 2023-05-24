using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainTickets.Interfaces;
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

        public AdminHomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToRouteAddingPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<RouteAddingViewModel>());
            NavigationToStationAddingPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<StationAddingViewModel>());
            NavigationToSignInPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignInViewModel>());
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
