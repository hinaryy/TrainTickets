using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Persistence;
using TrainTickets.Interfaces;
using System.Windows.Input;
using TrainTickets.Model;
using System.Windows;
using System.Collections.ObjectModel;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using TrainTickets.Services;

namespace TrainTickets.ViewModel
{
    class RouteAddingViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        private string _fromStation;
        private string _toStation;
        private DateTime _date = new DateTime(2023, 1, 1, 12, 00, 00);
        private int _price;
        private List<string> _stations;

        public List<string> Stations 
        { 
            get => _stations;
            set
            {
                _stations = value;
                OnPropertyChanged(nameof(Stations));
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

        public ICommand AddRouteCommand { get; set; }
        public ICommand NavigateToAdminHomePageCommand { get; }

        public RouteAddingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigateToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>());
            AddRouteCommand = new ViewModelCommand(ExecuteAddRouteCommand, CanExecuteAddRouteCommand);


            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();
        }

        private bool CanExecuteAddRouteCommand(object obj)
        {
            return !string.IsNullOrEmpty(FromStation)
                && !string.IsNullOrEmpty(ToStation)
                && !string.IsNullOrEmpty(Date.ToString())
                && !string.IsNullOrEmpty(Price.ToString())
                && !(Price == 0);
        }

        private void ExecuteAddRouteCommand(object obj)
        {
            var route = new Route
            {
                FromStation = FromStation,
                ToStation = ToStation,
                Date = Date,
                Price = Price
            };

            _context.Routes.Add(route);
            _context.SaveChanges();

            MessageBox.Show("Маршрут успешно добавлен");

            FromStation = "";
            ToStation = "";
            Date = new DateTime(2023, 1, 1, 12, 00, 00);
            Price = 0;
        }


    }
}
