using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrainTickets.Interfaces;
using TrainTickets.Persistence;
using TrainTickets.Services;
using TrainTickets.View;
using TrainTickets.ViewModel;

namespace TrainTickets
{
    public partial class App
    {

        private readonly IApplicationDbContext _applicationDbContext;
        private IServiceProvider _serviceProvider;
        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<MainWindow>(provider => new MainWindow
            {
                DataContext = provider.GetRequiredService<MainViewModel>()
            });

           
            services.AddSingleton<SignUpViewModel>();
            services.AddSingleton<SignInViewModel>();
            services.AddSingleton<AdminHomeViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddSingleton<TicketPurchaseViewModel>();
            services.AddSingleton<MainViewModel>();
            services.AddSingleton<INavigationService, NavigationService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Data Source=HINARY\\SQLEXPRESS;Initial Catalog=TrainTickets;Integrated Security=True; Encrypt=false",
                builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<Func<Type, ViewModelBase>>(serviceProvider => viewModelType =>
            (ViewModelBase)serviceProvider.GetRequiredService(viewModelType));

            _serviceProvider = services.BuildServiceProvider();

        }
        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }
    }
}
