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

using Microsoft.Extensions.DependencyInjection;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.WPFUI.Status;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IGenericService<Credential> credentialService;
        private readonly IServiceProvider serviceProvider;

        public LoginWindow(IGenericService<Credential> credentialService,IServiceProvider serviceProvider)
        {
            InitializeComponent();
            btn_submit.Click += Btn_submit_Click;
            this.credentialService = credentialService;
            this.serviceProvider = serviceProvider;
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            string username = tb_userName.Text;
            string password = pb_password.Password;
            if (username.IsEmpty() || password.IsEmpty())
            {
                MessageBox.Show("Kullanıcı adı veya Parolanız boş olamaz","Uyarı",MessageBoxButton.OK,MessageBoxImage.Warning);
                return;
            }
            var credentials = credentialService.GetAll();
            var found = credentials.FirstOrDefault(x=>x.UserName.Equals(username) && x.Password.Equals(password));
            if (found.IsNull())
            {
                MessageBox.Show("Girdiğiniz bilgiler ile eşleşen bir kullanıcı bulunamadı", "Uyarı", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            SessionContext.LoginManager = found.Manager;
            MainWindow mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
            this.Close();
        }
    }
}
