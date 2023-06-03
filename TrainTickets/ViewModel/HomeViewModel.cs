using Microsoft.Extensions.DependencyInjection;
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
using TrainTickets.View;

namespace TrainTickets.ViewModel
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand NavigationToTicketPurchasePageCommand { get; }
        public ICommand NavigationToUserTickersPageCommand { get; }
        public ICommand NavigationToSignInPageCommand { get; }
        public ICommand OpenBalanceReplenishmentWindowCommand { get; }
        public int Balance { get => _balance; set => _balance = value; }

        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private int _balance;

        public HomeViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToTicketPurchasePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<TicketPurchaseViewModel>());
            NavigationToUserTickersPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<UserTicketsViewModel>());
            NavigationToSignInPageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignInViewModel>());
            OpenBalanceReplenishmentWindowCommand = new ViewModelCommand(ExecuteOpenBalanceReplenishmentWindowCommand, CanExecuteOpenBalanceReplenishmentWindowCommand);

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("user.json"))!;
            user = _context.Users.FirstOrDefault(i => i.Id == user.Id)!;
            Balance = user.WalletBalance;
        }

        private bool CanExecuteOpenBalanceReplenishmentWindowCommand(object obj) => true;

        private void ExecuteOpenBalanceReplenishmentWindowCommand(object obj)
        {

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

    }
}
