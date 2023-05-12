using TrainTickets.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace TrainTickets.ViewModel
{
    public class SignInViewModel : ViewModelBase
    {
        private string _login;
        private string _password;

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

        public SignInViewModel() 
        {
            SignInCommand = new ViewModelCommand(executeAction, canExecuteAction);
        }

        public bool canExecuteAction(object obj)
        {
            return true;
        }

        public void executeAction(object obj)
        {
            MessageBox.Show("Пароль: " + Password);
        }

    }
}
