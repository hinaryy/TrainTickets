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
        private Route _selectedRoute;

        private List<Station> _stations;
        private List<Ticket> _tickets;
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
        public ICommand NavigationToAdminHomePageCommand { get; }
        public List<Station> Stations { get => _stations; set => _stations = value; }
        public List<Ticket> Tickets { get => _tickets; set => _tickets = value; }

        public StationDeletingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>());

            Stations = _context.Stations.ToList();

        }


    }
}
