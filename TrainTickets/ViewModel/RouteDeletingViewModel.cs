using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    class RouteDeletingViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private Route _selectedRoute;

        private List<Route> _routes;
        private List<string> _stations;
        private string _fromStation;
        private string _toStation;
        private DateTime _date = new DateTime(2023, 01, 01);
        private int _price;
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;

                FromStation = _selectedRoute.FromStation;
                ToStation = _selectedRoute.ToStation;
                Date = _selectedRoute.Date;
                Price = _selectedRoute.Price;

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
        public ICommand NavigationToAdminHomePageCommand { get; }
        public ICommand DeleteRouteCommand { get; }
        public ICommand SaveEditedRouteCommand { get; }

        public List<Route> Routes
        {
            get => _routes;
            set
            {
                _routes = value;
                OnPropertyChanged(nameof(Routes));
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
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }
        public int Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }


        public RouteDeletingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>());
            DeleteRouteCommand = new ViewModelCommand(ExecuteDeleteRouteCommand, CanExecuteDeleteRouteCommand);
            SaveEditedRouteCommand = new ViewModelCommand(ExecuteSaveEditedRouteCommand, CanExecuteSaveEditedRouteCommand);

            Routes = _context.Routes.ToList();

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();
        }

        private bool CanExecuteSaveEditedRouteCommand(object obj)
        {
            return true;
        }

        private void ExecuteSaveEditedRouteCommand(object obj)
        {
            if(SelectedRoute != null)
            {
                SelectedRoute.FromStation = FromStation;
                SelectedRoute.ToStation = ToStation;
                SelectedRoute.Date = Date;
                SelectedRoute.Price = Price;

                _context.Update(SelectedRoute);
                _context.SaveChanges();

                Routes = _context.Routes.ToList();
            }
        }
        private bool CanExecuteDeleteRouteCommand(object obj)
        {
            return SelectedRoute != null;
        }

        private void ExecuteDeleteRouteCommand(object obj)
        {
            var Tickets = _context.Tickets.Where(i => i.Route == SelectedRoute).ToList();

            for (int i = 0; i < Tickets.Count; i++)
            {
                _context.Tickets.Remove(Tickets[i]);
            }

            if (SelectedRoute != null)
                _context.Routes.Remove(SelectedRoute);

            _context.SaveChanges();

            Routes = _context.Routes.ToList();

        }

    }
}
