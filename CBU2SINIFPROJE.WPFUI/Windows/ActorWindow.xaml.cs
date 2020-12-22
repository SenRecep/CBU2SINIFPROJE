using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.Actor;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for ActorWindow.xaml
    /// </summary>
    public partial class ActorWindow : Window
    {
        public bool IsSaved { get; set; }
        public bool EditMode { get; set; }
        private readonly IGenericService<Actor> actorService;

        public ActorWindow(IGenericService<Actor> actorService)
        {
            InitializeComponent();
            btn_Submit.Click += Btn_Submit_Click;
            this.actorService = actorService;
        }
        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            var model = this.DataContext.Cast<ActorAddModel>();
            if (!model.IsNull())
            {
                model.Field = int.Parse(cb_Fields.SelectedItem.Cast<ComboBoxItem>().Tag.Cast<string>()).Cast<Field>();
                Actor entity = new()
                {
                    Id=model.Id,
                    Field = model.Field,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Salary=model.Salary,
                    Adress=new (model.Adress.City,model.Adress.Town,model.Adress.AdressDetail)
                };
                if (EditMode)
                    actorService.Update(entity);
                else
                    actorService.Add(entity);
                IsSaved = true;
                MessageBox.Show("Kaydedildi");
                this.Close();
            }
        }
    }
}
