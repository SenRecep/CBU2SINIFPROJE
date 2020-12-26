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

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.Company;
using CBU2SINIFPROJE.WPFUI.Windows;

using Microsoft.Extensions.DependencyInjection;
namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for FirmaIslemleri.xaml
    /// </summary>
    public partial class FirmaIslemleri : Page
    {
        private readonly IGenericService<Company> genericCompanyService;
        private readonly ICompanyService companyService;
        private readonly IServiceProvider serviceProvider;

        public FirmaIslemleri(IGenericService<Company> genericCompanyService , ICompanyService companyService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitEvents();
            this.genericCompanyService = genericCompanyService;
            this.companyService = companyService;
            this.serviceProvider = serviceProvider;
        }

        private void InitEvents()
        {
            Loaded += FirmaIslemleri_Loaded;
            Delete_Company.Click += Delete_Company_Click;
            Edit_Company.Click += Edit_Company_Click;
            Btn_companyAdd.Click += Btn_companyAdd_Click;
            List_Projects.Click += List_Projects_Click;
        }

        private void List_Projects_Click(object sender, RoutedEventArgs e)
        {
            Company company = dg_Company.SelectedItem.Cast<Company>();
            if (!company.IsNull())
               new CompanyProjectsWindow(company).ShowDialog();
        }

        private void Btn_companyAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = serviceProvider.GetService<CompanyAddWindow>();
            window.ShowDialog();
            dg_Company.Items.Refresh();
        }

        private void Edit_Company_Click(object sender, RoutedEventArgs e)
        {
            Company company = dg_Company.SelectedItem.Cast<Company>();
            if (!company.IsNull())
            {
                CompanyAddModel model = new()
                {
                    Adress=new(company.Adress.City, company.Adress.Town, company.Adress.AdressDetail),
                    Id=company.Id,
                    Name=company.Name
                };
                var window = serviceProvider.GetService<CompanyAddWindow>();
                window.EditMode = true;
                window.DataContext = model;
                window.ShowDialog();
                dg_Company.Items.Refresh();
            }

        }

        private void Delete_Company_Click(object sender, RoutedEventArgs e)
        {
            Company company = dg_Company.SelectedItem.Cast<Company>();
            if (!company.IsNull())
            {
                var messageBoxResult = MessageBox.Show($"{company.Name} adlı firmayı silmek istediğinizden emin misiniz","Uyarı",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                if (messageBoxResult==MessageBoxResult.Yes)
                {
                    companyService.Delete(company);
                    dg_Company.Items.Refresh();
                }
                else
                    MessageBox.Show("Silme islemi iptal edilmistir");
            }
        }

        private void FirmaIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            dg_Company.ItemsSource = genericCompanyService.GetAll();
        }
    }
}
