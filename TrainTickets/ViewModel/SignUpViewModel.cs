using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    public class SignUpViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _name;
        private string _password;
        private string _email;
        private string _errorMessage;
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
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
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

        public SignUpViewModel(INavigationService navigationService, ApplicationDbContext context)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToSignInCommand = new ViewModelCommand(i => NavigationService.NavigateTo<SignInViewModel>());
            SignUpCommand = new ViewModelCommand(ExecuteSignUpCommand, CanExecuteSignUpCommand);
        }


        private bool CanExecuteSignUpCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Email) || string.IsNullOrWhiteSpace(Password) ||
            Password.Length < 8 || !Email.Contains("@") || !Email.Contains(".") || Email.Length == 1)
            {
                return false;
            }

            return true;
        }

        private void ExecuteSignUpCommand(object obj)
        {
            var user = new User
            {
                Name = Name,
                Email = Email,
                Password = Password,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            NavigationService.NavigateTo<SignInViewModel>();


        }
    }
}
