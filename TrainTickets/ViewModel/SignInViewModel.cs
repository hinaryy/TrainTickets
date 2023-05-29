using System.Linq;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Persistence;
using System.IO;
using Newtonsoft.Json;

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

            if (user == null)
            {
                ErrorMessage = "Пароль или логин некорректный";

            }
            else if (user.Name.EndsWith("admin"))
            {
                NavigationService.NavigateTo<AdminHomeViewModel>();
            }
            else if (user != null)
            {
                using (StreamWriter file = File.CreateText("user.json"))
                {
                    JsonSerializer serializer = new JsonSerializer()
                    {
                        Formatting = Formatting.Indented
                    };

                    serializer.Serialize(file, user);
                }

                NavigationService.NavigateTo<HomeViewModel>();
            }
        }
    }
}
