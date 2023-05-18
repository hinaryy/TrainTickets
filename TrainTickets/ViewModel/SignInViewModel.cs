using TrainTickets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TrainTickets.Interfaces;
using TrainTickets.Persistence;
using TrainTickets.Model;
using System.Threading;

namespace TrainTickets.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _name;
        private string _password;
        private string _errorMessage;

        public INavigationService NavigationService
        {
            get => _navigationService;

            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));  
            }
        }
        public string Password 
        { 
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));   
            } 
        }
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public ICommand SignInCommand { get; }

        public ICommand NavigationToSignUpCommand { get; }

        public SignInViewModel(INavigationService navigationService, ApplicationDbContext context) 
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToSignUpCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignUpViewModel>());
            SignInCommand = new ViewModelCommand(ExecuteSignInCommand, CanExecuteSignInCommand);
        }

        private bool CanExecuteSignInCommand(object obj)
        {
            return true;
        }

        private void ExecuteSignInCommand(object obj)
        {

            var user = _context.Users.FirstOrDefault(i => i.Name == Name && i.Password == Password);

            if (user != null) 
            {
                NavigationService.NavigateTo<HomeViewModel>();
            }
            else
            {
                ErrorMessage = "Пароль или логин некорректный";
            }
        }
    }
}
