using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Interfaces;
using TrainTickets.ViewModel;

namespace TrainTickets.Services
{
    class NavigationService : ViewModelBase, INavigationService
    {
        private readonly Func<Type, ViewModelBase> _viewFactory;
        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();

            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public void NavigateTo<TViewModel>() where TViewModel : ViewModelBase
        {
            ViewModelBase viewModel = _viewFactory.Invoke(typeof(TViewModel));
            CurrentView = viewModel;
        }
    }
}
