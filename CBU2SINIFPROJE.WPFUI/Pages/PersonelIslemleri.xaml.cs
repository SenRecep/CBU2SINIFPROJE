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
        private readonly IOfficeWorkerService ofwService;
        private readonly IServiceProvider serviceProvider;

        public PersonelIslemleri(IGenericService<OfficeWorker> genericOfwService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitEvents();
            this.genericOfwService = genericOfwService;
            this.serviceProvider = serviceProvider;
        }

        private void InitEvents()
        {
            Delete_Employee.Click += Delete_Employee_Click;
            Edit_Employee.Click += Edit_Employee_Click;
            Izin_Employee.Click += Izin_Employee_Click;
            Btn_employeeAdd.Click += Btn_employeeAdd_Click;
            this.Loaded += PersonelIslemleri_Loaded;
        }

        private void Btn_employeeAdd_Click(object sender, RoutedEventArgs e)
        {
            OfWWindow window = serviceProvider.GetService<OfWWindow>();
            window.EditMode = false;
            window.DataContext = new OfWAddModel();
            window.ShowDialog();
            if (window.IsSaved)
            {
                dg_Employee.Items.Refresh();
                window.IsSaved = false;
            }
        }

        private void PersonelIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            dg_Employee.ItemsSource = genericOfwService.GetAll();
            if (SessionContext.LoginManager.Role == Role.MudurYardimcisi)
                    Edit_Employee.Visibility =Delete_Employee.Visibility = Visibility.Collapsed;
        }

        private void Izin_Employee_Click(object sender, RoutedEventArgs e)
        {
            
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
