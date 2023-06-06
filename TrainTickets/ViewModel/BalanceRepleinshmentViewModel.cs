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
    class BalanceRepleinshmentViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private int _balance;
        private int _amount = 100;
        private string _cardNumber;
        private string _cardHolder;
        private DateTime _validityPeriod = DateTime.Today;
        private int _cvvCode;
        private User _user;


        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public ICommand NavigationToHomePageCommand { get; }
        public ICommand ReplenishBalanceCommand { get; }
        public string CardNumber
        {
            get => _cardNumber;
            set
            {
                _cardNumber = value;
                OnPropertyChanged(nameof(CardNumber));
            }
        }
        public string CardHolder
        {
            get => _cardHolder;
            set
            {
                _cardHolder = value;
                OnPropertyChanged(nameof(CardHolder));
            }
        }
        public DateTime ValidityPeriod
        {
            get => _validityPeriod;
            set
            {
                _validityPeriod = value;
                OnPropertyChanged(nameof(ValidityPeriod));
            }
        }
        public int CvvCode
        {
            get => _cvvCode;
            set
            {
                _cvvCode = value;
                OnPropertyChanged(nameof(CvvCode));
            }
        }
        public int Amount
        {
            get => _amount;
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }
        public int Balance
        {
            get => _balance;
            set
            {
                _balance = value;
                OnPropertyChanged(nameof(Balance));
            }
        }
        public User User 
        { 
            get => _user;
            set 
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            } 
        }

        public BalanceRepleinshmentViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>(true));
            ReplenishBalanceCommand = new ViewModelCommand(ExecuteReplenishBalanceCommand, CanExecuteReplenishBalanceCommand);

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("user.json"))!;

            User = _context.Users.FirstOrDefault(i => i.Id == user.Id)!;
            Balance = User.WalletBalance;


        }

        private bool CanExecuteReplenishBalanceCommand(object obj)
        {
            return !string.IsNullOrEmpty(CardNumber)
                && !string.IsNullOrEmpty(CardHolder)
                && !string.IsNullOrEmpty(ValidityPeriod.ToString())
                && !string.IsNullOrEmpty(CvvCode.ToString())
                && !string.IsNullOrEmpty(Amount.ToString())
                && !int.IsNegative(Amount)
                && !(Amount == 0)
                && !(CvvCode.ToString().Length != 3)
                && !(CardNumber.ToString().Length != 16);
        }

        private void ExecuteReplenishBalanceCommand(object obj)
        {
            User.WalletBalance += Amount;

            _context.Update(User);
            _context.SaveChanges();

            Balance = User.WalletBalance;
        }
    }

}
