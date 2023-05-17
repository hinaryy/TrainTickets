using TrainTickets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using TrainTickets.Interfaces;

namespace TrainTickets.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        private string _login;
        private string _password;

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

        public ICommand SignInCommand { get; }

        public ICommand NavigationToSignUpCommand { get; }

        public SignInViewModel(INavigationService navigationService) 
        {
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
            throw new NotImplementedException();
        }
    }
}
