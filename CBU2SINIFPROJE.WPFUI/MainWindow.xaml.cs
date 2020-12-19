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

using CBU2SINIFPROJE.BLL.Concrete;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.Entities.Enums;

namespace CBU2SINIFPROJE.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitEvents();
        }
        public void InitEvents()
        {
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Kotu kullanim di implemantasyonu yapilmasi gerekli
            IActorService actorService = new ActorManager(new MDActorDal(),new MDGenericRepository<Actor>());
        }
    }
}
