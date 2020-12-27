using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            ActorAddModel model = DataContext.Cast<ActorAddModel>();
            if (!model.IsNull())
            {
                model.Field = cb_Fields.SelectedItem.Cast<ComboBoxItem>().Tag.Cast<string>().ToInt().Cast<Field>();
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
                Close();
            }
        }
    }
}
