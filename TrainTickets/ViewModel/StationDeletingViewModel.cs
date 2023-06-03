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
            NavigationToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>());
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
            Station selStation = _context.Stations.FirstOrDefault(i => i.Name == SelectedStation)!;

            _context.Stations.Remove(selStation);
            _context.SaveChanges();

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();
        }
    }
}
