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

        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        public HomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToTicketPurchasePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<TicketPurchaseViewModel>());
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
