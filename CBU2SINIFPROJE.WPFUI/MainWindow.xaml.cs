using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CBU2SINIFPROJE.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            InitEvents();
        }
        public void InitEvents()
        {
            Loaded += MainWindow_Loaded;
            Btn_Logout.Click += (s, e) => Environment.Exit(1);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (Button navigatorButton in navigatorButtons.Children.OfType<Button>())
                navigatorButton.Click += (s, e) =>
                    pageView.Source = new($"/Pages/{navigatorButton.Tag}.xaml", UriKind.Relative);
        }
    }
}
