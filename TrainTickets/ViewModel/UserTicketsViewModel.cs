using Microsoft.Office.Interop.Word;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    public class UserTicketsViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _fromStation;
        private string _toStation;
        private Route _selectedRoute;
        private int _balance;
        
        private List<Route> _routes;
        private List<Ticket> _tickets;
        public string FromStation
        {
            get => _fromStation;
            set
            {
                _fromStation = value;
                OnPropertyChanged(nameof(FromStation));
            }
        }
        public string ToStation
        {
            get => _toStation;
            set
            {
                _toStation = value;
                OnPropertyChanged(nameof(ToStation));
            }
        }
        public Route SelectedRoute
        {
            get => _selectedRoute;
            set
            {
                _selectedRoute = value;
                OnPropertyChanged();
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
        public ICommand PrintTicketCommand { get; }
        public List<Route> Routes { get => _routes; set => _routes = value; }
        public List<Ticket> Tickets { get => _tickets; set => _tickets = value; }

        public UserTicketsViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>(true));
            PrintTicketCommand = new ViewModelCommand(ExecutePrintTicketCommand, CanExecutePrintTicketCommand);

            var user = JsonConvert.DeserializeObject<User>(File.ReadAllText("user.json"))!;

            user = _context.Users.FirstOrDefault(i => i.Id == user.Id)!;
            Balance = user.WalletBalance;

            var r = _context.Routes.ToList();

            Tickets = _context.Tickets.Where(i => i.User.Id == user.Id).ToList();

            Routes = Tickets.Select(i => i.Route).ToList();

        }

        private bool CanExecutePrintTicketCommand(object obj)
        {
            return SelectedRoute != null;
        }

        private void ExecutePrintTicketCommand(object obj)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Документ Word (*.docx)|*.docx";
            saveFileDialog.Title = "Сохранить документ Word";
            saveFileDialog.FileName = SelectedRoute.FromStation + "-" + SelectedRoute.ToStation + " " + SelectedRoute.Date.ToShortDateString();

            if (saveFileDialog.FileName != "" && saveFileDialog.ShowDialog() == true)
            {
                Application word = new Application();
                Document doc = word.Documents.Add();

                doc.PageSetup.PaperSize = WdPaperSize.wdPaperA4;

                Paragraph para = doc.Paragraphs.Add();

                para.Range.Text = "Билетик №" + Tickets.FirstOrDefault(i => i.Route == SelectedRoute)!.Id + "\n";
                para.Range.Bold = 1;

                para.Range.Text += "Откуда: ";
                para.Range.Bold = 1;

                para.Range.Text += SelectedRoute.FromStation;
                para.Range.Bold = 0;

                para.Range.Text += "\nКуда: ";
                para.Range.Bold = 1;

                para.Range.Text += SelectedRoute.ToStation;
                para.Range.Bold = 0;

                para.Range.Text += "\nДата: ";
                para.Range.Bold = 1;

                para.Range.Text += SelectedRoute.Date.ToShortDateString();
                para.Range.Bold = 0;

                doc.SaveAs2(saveFileDialog.FileName);

                word.Quit();

                SelectedRoute = null!;

                System.Windows.MessageBox.Show("Билетик успешно распечатан");
            }
        }

    }
}
