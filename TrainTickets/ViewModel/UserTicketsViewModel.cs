using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    public class UserTicketsViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _fromStation;
        private string _toStation;

        private Ticket _ticket;
        public string FromStation
        {
            get => _fromStation;
            set
            {
                _fromStation = value;
                OnPropertyChanged(nameof(FromStation));
            }
        }
        public string ToStation
        {
            get => _toStation;
            set
            {
                _toStation = value;
                OnPropertyChanged(nameof(ToStation));
            }
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
        public ICommand NavigationToHomePageCommand { get; }
        public ICommand SearchTicketsCommand { get; }
        public Ticket Ticket { get => _ticket; set => _ticket = value; }

        public UserTicketsViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>());
            SearchTicketsCommand = new ViewModelCommand(ExecuteSearchTicketsCommand, CanExecuteSearchTicketsCommand);

        }

        private bool CanExecuteSearchTicketsCommand(object obj)
        {
            return !string.IsNullOrEmpty(ToStation)
                && !string.IsNullOrEmpty(FromStation);
        }

        private void ExecuteSearchTicketsCommand(object obj)
        {

        }

    }
}
