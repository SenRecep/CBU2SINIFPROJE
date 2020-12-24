using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.WPFUI.Windows;

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
        private readonly IGenericService<Project> genericProjectService;
        private readonly IServiceProvider serviceProvider;

        public ProjeIslemleri(IGenericService<Project> genericProjectService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            this.genericProjectService = genericProjectService;
            this.serviceProvider = serviceProvider;
            InitEvents();
        }

        private void InitEvents()
        {
            this.Loaded += ProjeIslemleri_Loaded;
            ListCalisanlar.Click += ListCaslisanlar_Click;
            Delete_Project.Click += Delete_Project_Click;
            Btn_projectAdd.Click += Btn_projectAdd_Click;
        }

        private void Btn_projectAdd_Click(object sender, RoutedEventArgs e)
        {
            ProjectWindow window = serviceProvider.GetService(typeof(ProjectWindow)).Cast<ProjectWindow>();
            window.ShowDialog();
            dg_Project.Items.Refresh();
        }

        private void Delete_Project_Click(object sender, RoutedEventArgs e)
        {
            Project selectedProject = dg_Project.SelectedItem?.Cast<Project>();
            if(!selectedProject.IsNull())
            {
                genericProjectService.Delete(selectedProject);
                dg_Project.Items.Refresh();
            }

        }

        private void ListCaslisanlar_Click(object sender, RoutedEventArgs e)
        {
            var model = dg_Project.SelectedItem.Cast<Project>();
            if (!model.IsNull())
            {
                Window employees = new ListEmployeeWindow(model);
                employees.ShowDialog();
            }
        }

        private void ProjeIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            if (SessionContext.LoginManager.Role == Role.MudurYardimcisi)
                Edit_Project.Visibility = Delete_Project.Visibility = Visibility.Collapsed;
            dg_Project.ItemsSource = genericProjectService.GetAll();
        }
    }
}
