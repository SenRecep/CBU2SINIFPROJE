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
using System.Windows.Shapes;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.Company;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for CompanyAddWindow.xaml
    /// </summary>
    public partial class CompanyAddWindow : Window
    {
        public bool EditMode { get; set; }

        private readonly IGenericService<Company> genericCompanyService;

        public CompanyAddWindow(IGenericService<Company> genericCompanyService)
        {
            InitializeComponent();
            btn_Submit.Click += Btn_Submit_Click;
            this.genericCompanyService = genericCompanyService;
        }

        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            var model = DataContext.Cast<CompanyAddModel>();
            if (!model.IsNull())
            {
                Company company = new()
                {
                    Id=model.Id,
                    Adress=new(model.Adress.City, model.Adress.Town, model.Adress.AdressDetail),
                    Name=model.Name
                };
                if (EditMode)
                    genericCompanyService.Update(company);
                else
                {
                    company.Projects = new();
                    genericCompanyService.Add(company);
                }
                MessageBox.Show("Kaydedildi");
                this.Close();
            }
        }
    }
}
