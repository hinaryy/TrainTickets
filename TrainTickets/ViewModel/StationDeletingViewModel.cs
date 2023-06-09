using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
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
    class StationDeletingViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _selectedStation;

        private List<string> _stations;
        private List<Ticket> _tickets;
        public string SelectedStation
        {
            get => _selectedStation;
            set
            {
                _selectedStation = value;
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
        public ICommand DeleteStationCommand { get; }
        public List<string> Stations 
        { 
            get => _stations;
            set 
            {
                _stations = value;
                OnPropertyChanged(nameof(Stations));
            } 
        }
        public List<Ticket> Tickets { get => _tickets; set => _tickets = value; }

        public StationDeletingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>(true));
            DeleteStationCommand = new ViewModelCommand(ExecuteDeleteStationCommand, CanExecuteDeleteStationCommand);

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();
        }

        private bool CanExecuteDeleteStationCommand(object obj)
        {
            return SelectedStation != null;
        }

        private void ExecuteDeleteStationCommand(object obj)
        {
            var selStation = _context.Stations.FirstOrDefault(i => i.Name == SelectedStation)!;
            var routes = _context.Routes.Where(i => i.FromStation == SelectedStation || i.ToStation == SelectedStation).ToList();
            var tickets = _context.Tickets.Where(i => i.Route.ToStation == SelectedStation || i.Route.FromStation == SelectedStation).ToList();

            foreach (var ticket in tickets)
                _context.Tickets.Remove(ticket);
            _context.SaveChanges();

            foreach (var route in routes)
                _context.Routes.Remove(route);
            _context.SaveChanges();

            _context.Stations.Remove(selStation);
            _context.SaveChanges();

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();
        }
    }
}
