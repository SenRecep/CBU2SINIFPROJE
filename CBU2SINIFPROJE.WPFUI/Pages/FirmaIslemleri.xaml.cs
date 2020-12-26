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

namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for FirmaIslemleri.xaml
    /// </summary>
    public partial class FirmaIslemleri : Page
    {
        private readonly IGenericService<Company> genericCompanyService;

        public FirmaIslemleri(IGenericService<Company> genericCompanyService)
        {
            InitializeComponent();
            InitEvents();
            this.genericCompanyService = genericCompanyService;
        }

        private void InitEvents()
        {
            Loaded += FirmaIslemleri_Loaded;
            Delete_Company.Click += Delete_Company_Click;
        }

        private void Delete_Company_Click(object sender, RoutedEventArgs e)
        {
            Company company = dg_Company.SelectedItem.Cast<Company>();
            if (!company.IsNull())
            {
                var messageBoxResult = MessageBox.Show($"{company.Name} adlı firmayı silmek istediğinizden emin misiniz","Uyarı",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                if (messageBoxResult==MessageBoxResult.Yes)
                {
                    genericCompanyService.Delete(company);
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
