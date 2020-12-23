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
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for IzinAtaWindow.xaml
    /// </summary>
    public partial class IzinAtaWindow : Window
    {
        private readonly Employee employee;

        public IzinAtaWindow(Employee employee)
        {
            InitializeComponent();
            InitEvents();
            this.employee = employee;
        }
        public void InitEvents()
        {
            Loaded += IzinAtaWindow_Loaded;
            IzinIptal.Click += IzinIptal_Click;
            btn_submit.Click += Btn_submit_Click;
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (dp_baslangic.SelectedDate.IsNull() || dp_bitis.SelectedDate.IsNull())
            {
                MessageBox.Show("Başlangıç ve bitiş tarihlerini seçiniz");
                return;
            }
            if (dp_baslangic.SelectedDate.Value>dp_bitis.SelectedDate.Value)
            {
                MessageBox.Show("Başlangıç tarihi bitis tarihinden sonra olamaz");
                return;
            }
            Vacation vacation = new()
            {
                Manager=SessionContext.LoginManager,
                Duration=new(dp_baslangic.SelectedDate.Value,dp_bitis.SelectedDate.Value)
            };
            if (employee.Vacations.IsNull())
            {
                employee.Vacations = new List<Vacation>();
                dg_izinler.ItemsSource = employee.Vacations;
            }
            employee.Vacations.Add(vacation);
            dg_izinler.Items.Refresh();
            MessageBox.Show("Kaydedildi");

        }

        private void IzinIptal_Click(object sender, RoutedEventArgs e)
        {
            var model = dg_izinler.SelectedItem.Cast<Vacation>();
            if (!model.IsNull())
            {
                if (model.Duration.EndDate<DateTime.Now)
                {
                    MessageBox.Show("Geçmiş tarihli izinleri iptal edemessiniz");
                    return;
                }
                employee.Vacations.Remove(model);
                dg_izinler.Items.Refresh();
                MessageBox.Show("Izin iptal edilmistir");
            }
        }

        private void IzinAtaWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dg_izinler.ItemsSource = employee.Vacations;
            dp_baslangic.DisplayDateStart = DateTime.Now;
            dp_bitis.DisplayDateStart = DateTime.Now.AddDays(1);
        }
    }
}
