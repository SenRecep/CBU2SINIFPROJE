using System.Linq;
using System.Windows;

using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for ListEmployeeWindow.xaml
    /// </summary>
    public partial class ListEmployeeWindow : Window
    {
        private readonly Project model;

        public ListEmployeeWindow(Project model)
        {
            InitializeComponent();
            Loaded += ListEmployeeWindow_Loaded;
            this.model = model;
        }

        private void ListEmployeeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (SessionContext.LoginManager.Role==Core.Enums.Role.MudurYardimcisi)
                tb_field.Visibility = Visibility.Collapsed;
            dg_actors.ItemsSource = model.Employees.Where(x => x is Actor).ToList();
            dg_ofw.ItemsSource = model.Employees.Where(x => x is OfficeWorker).ToList();
        }
    }
}
