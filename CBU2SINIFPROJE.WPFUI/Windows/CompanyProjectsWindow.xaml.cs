using System.Windows;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for CompanyProjectsWindow.xaml
    /// </summary>
    public partial class CompanyProjectsWindow : Window
    {
        public CompanyProjectsWindow(Company company)
        {
            InitializeComponent();
            dg_Project.ItemsSource = company.Projects;
        }
    }
}
