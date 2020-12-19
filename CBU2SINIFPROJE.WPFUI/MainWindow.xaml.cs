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
        private readonly IGenericService<Manager> managerService;

        public MainWindow(IGenericService<Manager> managerService)
        {
            InitializeComponent();
            InitEvents();
            this.managerService = managerService;
        }
        public void InitEvents()
        {
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var managers= managerService.GetAll();
        }
    }
}
