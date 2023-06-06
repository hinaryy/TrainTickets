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

        private ViewModelBase _currentView = null!;
        private ViewModelBase _externalView = null!;

        public ViewModelBase CurrentView
        {
            get => _currentView;
            private set
            {
                _currentView = value;
                OnPropertyChanged();

            }
        }
        public ViewModelBase ExternalView
        {
            get => _externalView;
            private set
            {
                _externalView = value;
                OnPropertyChanged();

            }
        }

        public NavigationService(Func<Type, ViewModelBase> viewFactory)
        {
            _viewFactory = viewFactory;
        }

        public void NavigateTo<TViewModel>(bool ? isCurrent = null) where TViewModel : ViewModelBase
        {
            var viewModel = _viewFactory.Invoke(typeof(TViewModel));

            if (isCurrent.HasValue)
                CurrentView = viewModel;
            else
                ExternalView = viewModel;
        }
    }
}
