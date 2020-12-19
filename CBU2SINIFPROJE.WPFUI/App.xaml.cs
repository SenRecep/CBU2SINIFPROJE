using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using CBU2SINIFPROJE.BLL.Concrete;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories;
using CBU2SINIFPROJE.DAL.Interfaces;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CBU2SINIFPROJE.WPFUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; init; }

        public IConfiguration Configuration { get; set; }

        public App()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);

            services.AddScoped(typeof(IGenericService<>) , typeof(GenericManager<>));
            services.AddScoped(typeof(IGenericRepository<>) , typeof(MDGenericRepository<>));

            services.AddScoped<IActorService, ActorManager>();
            services.AddScoped<IManagerService, ManagerManager>();
            services.AddScoped<IOfficeWorkerService, OfficeWorkerManager>();
            services.AddScoped<ICompanyService, CompanyManager>();

            services.AddScoped<IActorDal,MDActorDal>();
            services.AddScoped<IManagerDal,MDManagerDal>();
            services.AddScoped<IOfficeWorkerDal,MDOfficeWorkerDal>();
            services.AddScoped<ICompanyDal,MDCompanyDal>();

            services.AddTransient(typeof(MainWindow));
        }

    }
}
