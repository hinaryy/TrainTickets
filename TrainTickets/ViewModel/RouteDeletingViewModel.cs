using Microsoft.IdentityModel.Tokens;
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
    class RouteDeletingViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private Route _selectedRoute;

        private List<Route> _routes;
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
        public ICommand DeleteRouteCommand { get; }
        public List<Route> Routes 
        { 
            get => _routes;
            set 
            {
                _routes = value;
                OnPropertyChanged(nameof(Routes));
            }
        }

        public RouteDeletingViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToAdminHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<AdminHomeViewModel>());
            DeleteRouteCommand = new ViewModelCommand(ExecuteDeleteRouteCommand, CanExecuteDeleteRouteCommand);

            Routes = _context.Routes.ToList();
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
