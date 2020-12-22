using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Core.Enums;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.ViewModels.Actor;
using CBU2SINIFPROJE.WPFUI.Windows;

using Microsoft.Extensions.DependencyInjection;

namespace CBU2SINIFPROJE.WPFUI.Pages
{
    /// <summary>
    /// Interaction logic for OyuncuIslemleri.xaml
    /// </summary>
    public partial class OyuncuIslemleri : Page
    {
        private readonly IGenericService<Actor> genericActorService;
        private readonly IActorService actorService;
        private readonly IServiceProvider serviceProvider;


        private ActorWindow actorWindow;

        public OyuncuIslemleri(IGenericService<Actor> genericActorService, IActorService actorService, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            InitEvents();
            this.genericActorService = genericActorService;
            this.actorService = actorService;
            this.serviceProvider = serviceProvider;
            actorWindow = serviceProvider.GetService<ActorWindow>();
        }
        private void InitEvents()
        {
            Loaded += OyuncuIslemleri_Loaded;
            Edit_Actor.Click += Edit_Actor_Click;
            Delete_Actor.Click += Delete_Actor_Click;
            Btn_actorAdd.Click += Btn_actorAdd_Click;
            Izin_Actor.Click += Izin_Actor_Click;
        }

        private void Izin_Actor_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Btn_actorAdd_Click(object sender, RoutedEventArgs e)
        {
            actorWindow = serviceProvider.GetService<ActorWindow>();
            actorWindow.EditMode = false;
            actorWindow.DataContext = new ActorAddModel();
            actorWindow.ShowDialog();
            if (actorWindow.IsSaved)
            {
                dg_Actor.Items.Refresh();
                actorWindow.IsSaved = false;
            }
        }

        private void Delete_Actor_Click(object sender, RoutedEventArgs e)
        {
            Actor selectedActor = dg_Actor.SelectedItem?.Cast<Actor>();
            if (!selectedActor.IsNull())
            {
                actorService.DeleteActor(selectedActor);
                dg_Actor.Items.Refresh();
            }
        }

        private void Edit_Actor_Click(object sender, RoutedEventArgs e)
        {
            Actor selectedActor = dg_Actor.SelectedItem.Cast<Actor>();
            if (!selectedActor.IsNull())
            {
                ActorAddModel model = new()
                {
                    Id = selectedActor.Id,
                    Adress = new(selectedActor.Adress.City, selectedActor.Adress.Town, selectedActor.Adress.AdressDetail),
                    Field = selectedActor.Field,
                    FirstName = selectedActor.FirstName,
                    LastName = selectedActor.LastName,
                    Salary = selectedActor.Salary
                };
                actorWindow = serviceProvider.GetService<ActorWindow>();
                actorWindow.EditMode = true;
                actorWindow.DataContext = model;
                actorWindow.cb_Fields.SelectedIndex = model.Field.Cast<int>();
                actorWindow.ShowDialog();
                if (actorWindow.IsSaved)
                {
                    dg_Actor.Items.Refresh();
                    actorWindow.IsSaved = false;
                }
            }
        }

        private void OyuncuIslemleri_Loaded(object sender, RoutedEventArgs e)
        {
            if (SessionContext.LoginManager.Role == Role.MudurYardimcisi)
                dtc_field.Visibility = Edit_Actor.Visibility = Delete_Actor.Visibility = Visibility.Collapsed;
            dg_Actor.ItemsSource = genericActorService.GetAll();
        }
    }
}
