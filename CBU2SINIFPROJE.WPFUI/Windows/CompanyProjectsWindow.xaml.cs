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
