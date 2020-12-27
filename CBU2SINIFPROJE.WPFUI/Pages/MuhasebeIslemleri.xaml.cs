using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;

namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for MuhasebeIslemleri.xaml
    /// </summary>
    public partial class MuhasebeIslemleri : Page
    {
        private readonly IAccountingService accountingService;

        public MuhasebeIslemleri(IAccountingService accountingService)
        {
            InitializeComponent();
            this.accountingService = accountingService;
            Loaded += MuhasebeIslemleri_Loaded;
        }

        private void MuhasebeIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            lbl_title.Content = $"{DateTime.Now.Month}.Ay Gelir Gider Raporu";

            double revenue = accountingService.TotalCost();
            totalProjectRevenue.Text = $"{revenue.ToString("c")}";

            int payments = accountingService.TotalWages();
            totalEmployeePayments.Text = $"{payments.ToString("c")}";

            int fixedExpenses = FixedExpenses.Text.ToInt();
            FixedExpenses.Text= $"{fixedExpenses.ToString("c")}";

            double result = revenue - payments - fixedExpenses;

            net.Text = $"{result.ToString("c")}";
            if (result<0)
                net.Foreground= (SolidColorBrush)(new BrushConverter().ConvertFrom("#e74c3c"));
        }
    }
}
