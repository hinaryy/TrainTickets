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
    class TicketPurchaseViewModel : ViewModelBase
    {
        public ICommand NavigationToHomePageCommand { get; }

        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        public TicketPurchaseViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>());
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
