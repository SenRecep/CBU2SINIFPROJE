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
        private readonly IGenericService<Actor> actorService;
        private readonly IGenericService<OfficeWorker> workerService;
        private readonly IGenericService<Company> companyService;

        public MainWindow(
            IGenericService<Actor> actorService,
            IGenericService<OfficeWorker> workerService,
            IGenericService<Company> companyService
            )
        {
            InitializeComponent();
            InitEvents();
            this.actorService = actorService;
            this.workerService = workerService;
            this.companyService = companyService;
        }
        public void InitEvents()
        {
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var actors = actorService.GetAll();
            var workers = workerService.GetAll();
            var companies = companyService.GetAll();
        }
    }
}
