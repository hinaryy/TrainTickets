using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrainTickets.Interfaces;

namespace TrainTickets.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private string _login;
        private string _password;
        private string _email;
        public ICommand SignUpCommand { get; }
        public ICommand NavigationToSignInCommand { get; }


        public INavigationService NavigationService
        {
            get => _navigationService;

            set
            {
                _navigationService = value;
                OnPropertyChanged();  
            }
        }

        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
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
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public SignUpViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigationToSignInCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignInViewModel>());
            SignUpCommand = new ViewModelCommand(ExecuteSignUpCommand, CanExecuteSignUpCommand);
        }


        private bool CanExecuteSignUpCommand(object obj)
        {
            return true;
        }

        private void ExecuteSignUpCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
