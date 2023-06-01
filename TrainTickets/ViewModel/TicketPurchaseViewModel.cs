using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    class TicketPurchaseViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _fromStation;
        private string _toStation;
        private List<string> _stations;
        private List<Route> _routes;
        private Route _selectedRoute;
        private int _balance;
        private User _user;
        public Route SelectedRoute 
        { 
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged();
            } 
        }
        public List<string> Stations
        {
            get => _stations;
            set
            {
                _stations = value;
                OnPropertyChanged(nameof(Stations));
            }
        }
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
        public ICommand BuyTicketCommand { get; }
        public List<Route> Routes 
        { 
            get => _routes;
            set 
            {
                _routes = value;
                OnPropertyChanged();
            } 
        }
        public int Balance 
        { 
            get => _balance;
            set 
            {
                _balance = value;
                OnPropertyChanged();
            } 
        }
        public User User { get => _user; set => _user = value; }

        public TicketPurchaseViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>());
            SearchTicketsCommand = new ViewModelCommand(ExecuteSearchTicketsCommand, CanExecuteSearchTicketsCommand);
            BuyTicketCommand = new ViewModelCommand(ExecuteBuyTicketCommand, CanExecuteBuyTicketCommand);

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();

            Routes = _context.Routes.ToList();
            Routes.OrderByDescending(i => i.Date);

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("user.json"))!;

            User = _context.Users.FirstOrDefault(i => i.Id == user.Id)!;
            Balance = User.WalletBalance;

            SelectedRoute = Routes[0];
        }

        private bool CanExecuteBuyTicketCommand(object obj)
        {
            return (!Routes.IsNullOrEmpty() && Balance >= SelectedRoute.Price);
        }
        
        private void ExecuteBuyTicketCommand(object obj)
        {
            User.WalletBalance -= SelectedRoute.Price;
            _context.Users.Update(User);

            Balance = User.WalletBalance;

            var ticket = new Ticket
            {
                User = User,
                Route = SelectedRoute
            };

            _context.Tickets.Add(ticket);
            _context.SaveChanges();
        }

        private bool CanExecuteSearchTicketsCommand(object obj)
        {
            return !string.IsNullOrEmpty(ToStation)
                && !string.IsNullOrEmpty(FromStation);
        }

        private void ExecuteSearchTicketsCommand(object obj)
        {
            Routes = _context.Routes.Where(i => i.FromStation == FromStation && i.ToStation == ToStation).ToList();

            if(!Routes.IsNullOrEmpty())
                SelectedRoute = Routes[0];
        }
    }
}
