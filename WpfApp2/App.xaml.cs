using AutoMapper;
using DALEF.Conc;
using DALEF.Mapping;
using DALEF.Models;
using DTO.Entity;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WpfApp2.ViewModel;

namespace WpfApp2
{
    public partial class App : Application
    {
        public static ServiceProvider ServiceProvider { get; private set; }

        private void ConfigureServices(IServiceCollection services)
        {

            string connectionString = "Data Source=HP_DANIK\\SQLEXPRESS01;Initial Catalog=TradingCompany;Integrated Security=True;Encrypt=False;";

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile(new MovieProfile());
            });
            IMapper mapper = config.CreateMapper();

            services.AddTransient<GoodsDalEf>(provider => new GoodsDalEf(connectionString, provider.GetRequiredService<IMapper>()));
            services.AddTransient<ShippingDalEf>(provider => new ShippingDalEf(connectionString, provider.GetRequiredService<IMapper>()));

            services.AddSingleton<IMapper>(mapper);
            services.AddTransient<UsersDalEf>(provider => new UsersDalEf(connectionString, provider.GetRequiredService<IMapper>()));
            services.AddTransient<ManagersDalEf>(provider => new ManagersDalEf(connectionString, provider.GetRequiredService<IMapper>()));
            services.AddTransient<LoginWindow>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<StartWindow>();
            services.AddTransient<RegisterWindow>(); // Додайте RegisterWindow, якщо ще не додали
            services.AddTransient<ManagerRegisterWindow>(); // Додайте ManagerRegisterWindow, якщо ще не додали
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var usersDalEf = ServiceProvider.GetRequiredService<UsersDalEf>();
            var managersDalEf = ServiceProvider.GetRequiredService<ManagersDalEf>(); // Отримайте ManagersDalEf
            var startWindow = new StartWindow(usersDalEf, managersDalEf); // Передайте обидва DAL
            startWindow.Show();
        }
    }
}
