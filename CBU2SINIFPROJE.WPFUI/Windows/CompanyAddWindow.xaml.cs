using System.Linq;
using System.Windows;

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
            CompanyAddModel model = DataContext.Cast<CompanyAddModel>();
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
                Close();
            }
        }
    }
}
