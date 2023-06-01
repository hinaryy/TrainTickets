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
    public class UserTicketsViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _fromStation;
        private string _toStation;
        private Route _selectedRoute;

        private List<Route> _routes;
        private List<Ticket> _tickets;
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
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged();
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
        public ICommand PrintTicketCommand { get; }
        public List<Route> Routes { get => _routes; set => _routes = value; }
        public List<Ticket> Tickets { get => _tickets; set => _tickets = value; }

        public UserTicketsViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>());
            PrintTicketCommand = new ViewModelCommand(ExecutePrintTicketCommandCommand, CanExecutePrintTicketCommandCommand);

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("user.json"))!;

            var r = _context.Routes.ToList();

            Tickets = _context.Tickets.Where(i => i.User.Id == user.Id).ToList();

            Routes = Tickets.Select(i => i.Route).ToList();
        }

        private bool CanExecutePrintTicketCommandCommand(object obj)
        {
            return true;
        }

        private void ExecutePrintTicketCommandCommand(object obj)
        {

        }

    }
}
