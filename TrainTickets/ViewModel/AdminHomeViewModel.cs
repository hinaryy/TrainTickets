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
        public ICommand NavigationToAddRoutePageCommand { get; }

        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        public AdminHomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToAddRoutePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<TicketPurchaseViewModel>());
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
