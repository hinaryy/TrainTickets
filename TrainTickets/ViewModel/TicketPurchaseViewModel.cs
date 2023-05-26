﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TrainTickets.Interfaces;
using TrainTickets.Model;
using TrainTickets.Persistence;

namespace TrainTickets.ViewModel
{
    class TicketPurchaseViewModel : ViewModelBase
    {
        private ApplicationDbContext _context;
        private INavigationService _navigationService;
        private string _fromStation;
        private string _toStation;
        private List<string> _stations;
        private List<Route> _routes;
        public List<string> Stations
        {
            get => _stations;
            set
            {
                _stations = value;
                OnPropertyChanged(nameof(Stations));
            }
        }
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
        public ICommand SearchTicketsCommand { get; }
        public List<Route> Routes 
        { 
            get => _routes;
            set 
            {
                _routes = value;
                OnPropertyChanged();
            } 
        }

        public TicketPurchaseViewModel(ApplicationDbContext context, INavigationService navigationService)
        {
            _context = context;
            _navigationService = navigationService;
            NavigationToHomePageCommand = new ViewModelCommand(i => NavigationService.NavigateTo<HomeViewModel>());
            SearchTicketsCommand = new ViewModelCommand(ExecuteSearchTicketsCommand, CanExecuteSearchTicketsCommand);

            Stations = _context.Stations.Select(i => i.Name).ToList();
            Stations.Sort();

            Routes = _context.Routes.ToList();
            Routes.OrderByDescending(i => i.Date);
        }

        private bool CanExecuteSearchTicketsCommand(object obj)
        {
            return !string.IsNullOrEmpty(ToStation)
                && !string.IsNullOrEmpty(FromStation);
        }

        private void ExecuteSearchTicketsCommand(object obj)
        {
            //int fromStationId = _context.Stations.FirstOrDefault(i => i.Name == FromStation).Id;
            //int toStationId = _context.Stations.FirstOrDefault(i => i.Name == ToStation).Id;

            Routes = _context.Routes.Where(i => i.FromStation == FromStation && i.ToStation == ToStation).ToList();
        }
    }
}
