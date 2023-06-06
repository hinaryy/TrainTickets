using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    class StationAddingViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;

        private string _name;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddStationCommand { get; set; }
        public ICommand NavigateToAdminHomePageCommand { get; }
        public string Name 
        { 
            get => _name; 
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }

        public StationAddingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigateToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>(true));
            AddStationCommand = new ViewModelCommand(ExecuteAddStationCommand, CanExecuteAddStationCommand);
        }

        private bool CanExecuteAddStationCommand(object obj)
        {
            return !string.IsNullOrEmpty(Name);
        }

        private void ExecuteAddStationCommand(object obj)
        {

            var station = new Station
            {
                Name = Name,
            };

            _context.Stations.Add(station);
            _context.SaveChanges();

            MessageBox.Show("Станция успешно добавлена");

            Name = "";

        }



    }
}
