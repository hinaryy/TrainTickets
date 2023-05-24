using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Interfaces;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
            NavigationService.NavigateTo<AdminHomeViewModel>();
        }
    }
}
