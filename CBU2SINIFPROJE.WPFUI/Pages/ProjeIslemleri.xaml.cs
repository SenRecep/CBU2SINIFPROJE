using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
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

namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for ProjeIslemleri.xaml
    /// </summary>
    public partial class ProjeIslemleri : Page
    {
        private readonly IGenericService<Project> projectService;

        public ProjeIslemleri(IGenericService<Project>projectService)
        {
            InitializeComponent();
            this.projectService = projectService;
            this.Loaded += ProjeIslemleri_Loaded;
        }

        private void ProjeIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            dg_Project.ItemsSource = projectService.GetAll();
        }
    }
}
