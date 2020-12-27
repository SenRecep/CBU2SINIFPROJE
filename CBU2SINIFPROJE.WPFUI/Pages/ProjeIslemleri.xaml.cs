using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.WPFUI.Windows;


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
            Loaded += ProjeIslemleri_Loaded;
            ListCalisanlar.Click += ListCaslisanlar_Click;
            Delete_Project.Click += Delete_Project_Click;
            Btn_projectAdd.Click += Btn_projectAdd_Click;
            Edit_Project.Click += Edit_Project_Click;
        }

        private void Edit_Project_Click(object sender, RoutedEventArgs e)
        {
            Project model = dg_Project.SelectedItem.Cast<Project>();
            if (!model.IsNull())
            {
                Window employees = new ListEmployeeWindow(model);
                employees.Show();
                ProjectWindow window = serviceProvider.GetService(typeof(ProjectWindow)).Cast<ProjectWindow>();
                window.Init(model);
                window.Show();
                employees.Left = 0;
                window.Left = employees.ActualWidth+20;
                App.Current.MainWindow.IsEnabled = false;
                IsEnabled = false;
                window.Closed += (s, ev) =>
                {
                    employees.Close();
                    dg_Project.Items.Refresh();
                    IsEnabled = true;
                };
            }

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
            if (!selectedProject.IsNull())
            {
                genericProjectService.Delete(selectedProject);
                dg_Project.Items.Refresh();
            }

        }

        private void ListCaslisanlar_Click(object sender, RoutedEventArgs e)
        {
            Project model = dg_Project.SelectedItem.Cast<Project>();
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
