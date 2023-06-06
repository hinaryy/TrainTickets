using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.ViewModel;

namespace TrainTickets.Interfaces
{
    public interface INavigationService
    {
        ViewModelBase CurrentView { get; }
        ViewModelBase ExternalView { get; }

        void NavigateTo<T>(bool ? isCurrent = null) where T : ViewModelBase;

    }
}
