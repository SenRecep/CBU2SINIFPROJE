using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CBU2SINIFPROJE.WPFUI.Pages;

using Microsoft.Extensions.DependencyInjection;
namespace CBU2SINIFPROJE.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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
            Btn_Logout.Click += (s, e) => Environment.Exit(1);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
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
