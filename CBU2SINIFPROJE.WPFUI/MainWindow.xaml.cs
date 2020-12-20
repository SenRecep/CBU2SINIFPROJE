using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using CBU2SINIFPROJE.BLL.Concrete;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Enums;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

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
            this.Loaded += MainWindow_Loaded;
            Btn_Logout.Click += (s, e) => Environment.Exit(1); 
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in navigatorButtons.Children)
                if (item is Button navigatorButton)
                    navigatorButton.Click += NavigatorButton_Click;
        }

        private void NavigatorButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button navigatorButton)
            {
                var pagename = navigatorButton.Tag.ToString();
                Title = pagename;
                pageView.Source = new Uri($"/Pages/{pagename}.xaml", UriKind.RelativeOrAbsolute);
            }
        }
    }
}
