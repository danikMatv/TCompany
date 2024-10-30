using AutoMapper;
using DALEF.Conc;
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
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton<IMapper>(mapper);
            services.AddTransient<UsersDalEf>(provider => new UsersDalEf(connectionString, provider.GetRequiredService<IMapper>()));
            services.AddTransient<ManagersDalEf>(provider => new ManagersDalEf(connectionString, provider.GetRequiredService<IMapper>()));
            services.AddTransient<LoginWindow>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<StartWindow>();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            var usersDalEf = ServiceProvider.GetRequiredService<UsersDalEf>();
            var startWindow = new StartWindow(usersDalEf);
            startWindow.Show();
        }

    }
}
