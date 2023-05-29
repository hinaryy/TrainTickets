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
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigationToTicketPurchasePageCommand { get; }
        public ICommand NavigationToUserTickersPageCommand { get; }
        public ICommand NavigationToSignInPageCommand { get; }

        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        public HomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToTicketPurchasePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<TicketPurchaseViewModel>());
            NavigationToUserTickersPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<UserTicketsViewModel>());
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
