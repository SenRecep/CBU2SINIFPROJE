using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.WPFUI.Pages;
using CBU2SINIFPROJE.WPFUI.Windows;

using Microsoft.Extensions.DependencyInjection;
namespace CBU2SINIFPROJE.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isLogout;
        private readonly IServiceProvider serviceProvider;

        public MainWindow(IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitEvents();
            this.serviceProvider = serviceProvider;
        }
        public void InitEvents()
        {
            Loaded += MainWindow_Loaded;
            Btn_Logout.Click += Btn_Logout_Click;
        }

        private void Btn_Logout_Click(object sender, RoutedEventArgs e)
        {
            SessionContext.LoginManager = null;
            LoginWindow window = serviceProvider.GetService<LoginWindow>();
            isLogout = true;
            window.ShowDialog();
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!isLogout)
                Application.Current.Shutdown();
            isLogout = !isLogout;
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Title = $"Hoşgeldin {SessionContext.LoginManager.FullName} - {SessionContext.LoginManager.Role}";
            foreach (Button navigatorButton in navigatorButtons.Children.OfType<Button>())
                navigatorButton.Click += (s, e) =>
                {
                    pageView.Navigate(navigatorButton.Tag.ToString() switch
                    {
                        "OyuncuIslemleri" => serviceProvider.GetService<OyuncuIslemleri>(),
                        "PersonelIslemleri" => serviceProvider.GetService<PersonelIslemleri>(),
                        "ProjeIslemleri" => serviceProvider.GetService<ProjeIslemleri>(),
                        "FirmaIslemleri" => serviceProvider.GetService<FirmaIslemleri>(),
                        "MuhasebeIslemleri" => serviceProvider.GetService<MuhasebeIslemleri>(),
                        _ => throw new NotImplementedException()
                    });
                };
        }
    }
}
