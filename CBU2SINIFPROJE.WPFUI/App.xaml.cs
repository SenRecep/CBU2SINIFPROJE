using System;
using System.IO;
using System.Windows;

using CBU2SINIFPROJE.BLL.Containers.MicrosoftIOC;
using CBU2SINIFPROJE.WPFUI.Windows;

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
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            SeedDatabase seedDatabase= ServiceProvider.GetRequiredService<SeedDatabase>();
            seedDatabase.Seed();
            base.OnStartup(e);
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);
            services.AddScoped<SeedDatabase>();
            services.AddTransient(typeof(LoginWindow));
            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(ActorWindow));
            services.AddTransient(typeof(Pages.OyuncuIslemleri));
            services.AddTransient(typeof(Pages.FirmaIslemleri));
            services.AddTransient(typeof(Pages.MuhasebeIslemleri));
            services.AddTransient(typeof(Pages.PersonelIslemleri));
            services.AddTransient(typeof(Pages.ProjeIslemleri));
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Window window = ServiceProvider.GetRequiredService<LoginWindow>();
            window.Show();
        }
    }
}
