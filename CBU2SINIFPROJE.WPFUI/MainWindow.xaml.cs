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

using CBU2SINIFPROJE.DAL.Concrete.MemoryDatabase.Repositories;
using CBU2SINIFPROJE.DAL.Interfaces;
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
            Actor actor = new()
            {
                FirstName = "Recep",
                LastName = "Sen",
                Field = Field.Radyo,
                Adress = new Adress() { City = "Istanbul", Town = "Arnavutkoy", AdressDetail = "Detaylar" },
                Salary = 100000,
            };
            var dal = new MDGenericRepository<Actor>();
            dal.Add(actor);
            var list = dal.GetAll();
            Actor updateActor = new()
            {
                Id = actor.Id,
                FirstName = "Yusuf",
                LastName = "Topkaya",
                Field = Field.Radyo,
                Adress = new Adress() { City = "Istanbul", Town = "Kagithane", AdressDetail = "Detaylar" },
                Salary = 50000,
            };
            dal.Update(updateActor);

            list = dal.GetAll();

            dal.Delete(actor);
            list = dal.GetAll();

        }
    }
}
