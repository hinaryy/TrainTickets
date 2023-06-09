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
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                Border border = doc.Content.Borders[WdBorderType.wdBorderTop];
                border.LineStyle = WdLineStyle.wdLineStyleSingle;
                border.Color = WdColor.wdColorBlack;
                border.LineWidth = WdLineWidth.wdLineWidth225pt;

                Microsoft.Office.Interop.Word.Range range = doc.Content;
                range.Text = "***";
                range.Font.Size = 24;
                range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                range.InsertParagraphAfter();

                Paragraph title = doc.Content.Paragraphs.Add();
                title.Range.Text = "Билет на электричку";
                title.Range.Font.Size = 18;
                title.Range.Font.Bold = 1;
                title.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
                title.Range.InsertParagraphAfter();

                Paragraph fromStation = doc.Content.Paragraphs.Add();
                fromStation.Range.Text = "Станция отправления: \t.\t.\t.\t.\t.\t.\t.\t" + SelectedRoute.FromStation;
                fromStation.Range.Font.Size = 14;
                fromStation.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                fromStation.Range.InsertParagraphAfter();

                Paragraph toStation = doc.Content.Paragraphs.Add();
                toStation.Range.Text = "Станция прибытия: \t.\t.\t.\t.\t.\t.\t.\t" + SelectedRoute.ToStation;
                toStation.Range.Font.Size = 14;
                toStation.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                toStation.Range.InsertParagraphAfter();

                Paragraph date = doc.Content.Paragraphs.Add();
                date.Range.Text = "Дата и время отправления: \t.\t.\t.\t.\t.\t.\t" + SelectedRoute.Date.ToShortDateString();
                date.Range.Font.Size = 14;
                date.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                date.Range.InsertParagraphAfter();

                Paragraph price = doc.Content.Paragraphs.Add();
                price.Range.Text = "Цена билета: \t.\t.\t.\t.\t.\t.\t.\t.\t" + SelectedRoute.Price;
                price.Range.Font.Size = 14;
                price.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
                price.Range.InsertParagraphAfter();

                doc.SaveAs2(saveFileDialog.FileName);

                doc.Close();
                word.Quit();
            }
        }
    }
}
