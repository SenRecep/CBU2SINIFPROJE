using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
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
using Microsoft.Extensions.DependencyInjection;
using CBU2SINIFPROJE.ViewModels.OfficeWorker;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Core.Enums;

namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for PersonelIslemleri.xaml
    /// </summary>
    public partial class PersonelIslemleri : Page
    {
        private readonly IGenericService<OfficeWorker> genericOfwService;
        private readonly IServiceProvider serviceProvider;
        private readonly IOfficeWorkerService ofwService;

        private OfWWindow window;

        public PersonelIslemleri(IGenericService<OfficeWorker> genericOfwService, IOfficeWorkerService ofwService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitEvents();
            this.genericOfwService = genericOfwService;
            this.ofwService = ofwService;
            this.serviceProvider = serviceProvider;
            window = serviceProvider.GetService<OfWWindow>();
        }

        private void InitEvents()
        {
            Loaded += PersonelIslemleri_Loaded;
            Delete_Employee.Click += Delete_Employee_Click;
            Edit_Employee.Click += Edit_Employee_Click;
            Izin_Employee.Click += Izin_Employee_Click;
            Btn_employeeAdd.Click += Btn_employeeAdd_Click;
            Project_Detail.Click += Project_Detail_Click;
        }

        private void Btn_employeeAdd_Click(object sender, RoutedEventArgs e)
        {
            window = serviceProvider.GetService<OfWWindow>();
            window.EditMode = false;
            window.DataContext = new OfWAddModel();
            window.ShowDialog();
            if (window.IsSaved)
            {
                dg_Employee.Items.Refresh();
                window.IsSaved = false;
            }
        }
        private void Project_Detail_Click(object sender, RoutedEventArgs e)
        {
            OfficeWorker selectedActor = dg_Employee.SelectedItem?.Cast<OfficeWorker>();
            if (!selectedActor.IsNull())
                if (!selectedActor.Projects.IsNull() && selectedActor.Projects.Any())
                    new ProjectDetailWindow(selectedActor).ShowDialog();
                else
                    MessageBox.Show("Sectiginiz calisanin mevcutta veya gecmiste bir projesi bulunmamaktadir");
        }
        private void PersonelIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            if (SessionContext.LoginManager.Role == Role.MudurYardimcisi)
                    Edit_Employee.Visibility =Delete_Employee.Visibility = Visibility.Collapsed;
            dg_Employee.ItemsSource = null;
            var entities = genericOfwService.GetAll();
            entities.ForEach(item => {
                item.State = ofwService.IsFree(item);
            });
            dg_Employee.ItemsSource = entities;
        }

        private void Izin_Employee_Click(object sender, RoutedEventArgs e)
        {
            Employee selected = dg_Employee.SelectedItem?.Cast<Employee>();
            if (!selected.IsNull())
            {
                var window = serviceProvider.GetService<IzinAtaWindow>();
                window.Init(selected);
                window.ShowDialog();
                NavigationService.Refresh();
            }
        }

        private void Delete_Employee_Click(object sender, RoutedEventArgs e)
        {
            OfficeWorker selectedOfW = dg_Employee.SelectedItem?.Cast<OfficeWorker>();
            if(!selectedOfW.IsNull())
            {
                genericOfwService.Delete(selectedOfW);
                dg_Employee.Items.Refresh();
            }
        }

        private void Edit_Employee_Click(object sender, RoutedEventArgs e)
        {
            OfficeWorker selectedOfW = dg_Employee.SelectedItem?.Cast<OfficeWorker>();
            OfWWindow window = serviceProvider.GetService<OfWWindow>();
            
            if (!selectedOfW.IsNull())
            {
                OfWAddModel model = new()
                {
                    Id = selectedOfW.Id,
                    Adress = new(selectedOfW.Adress.City, selectedOfW.Adress.Town, selectedOfW.Adress.AdressDetail),
                    Position = selectedOfW.Position,
                    FirstName = selectedOfW.FirstName,
                    LastName = selectedOfW.LastName,
                    Salary = selectedOfW.Salary
                };               
                window.EditMode = true;
                window.DataContext = model;
                window.cb_Positions.SelectedIndex = model.Position.Cast<int>();
                window.ShowDialog();
                if (window.IsSaved)
                {
                    dg_Employee.Items.Refresh();
                    window.IsSaved = false;
                }
            }
        }

        
    }
}
