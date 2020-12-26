using CBU2SINIFPROJE.BLL.ExtensionMethods;
using CBU2SINIFPROJE.BLL.Interfaces;
using CBU2SINIFPROJE.BLL.Status;
using CBU2SINIFPROJE.Entities.Concrete;
using CBU2SINIFPROJE.WPFUI.Models;

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

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for ProjectWindow.xaml
    /// </summary>
    public partial class ProjectWindow : Window
    {
        private readonly IGenericService<Company> genericCompanyService;
        private readonly IGenericService<Project> genericProjectService;
        private readonly IGenericService<Actor> genericActorService;
        private readonly IGenericService<OfficeWorker> genericOfficeWorkerService;
        private readonly IProjectService projectService;
        private readonly IActorService actorService;
        private readonly IOfficeWorkerService officeWorkerService;

        private Project project;

        public ProjectWindow(IGenericService<Company> genericCompanyService, IGenericService<Project> genericProjectService, IGenericService<Actor> genericActorService, IGenericService<OfficeWorker> genericOfficeWorkerService, IProjectService projectService, IActorService actorService, IOfficeWorkerService officeWorkerService)
        {
            InitializeComponent();
            
            this.genericCompanyService = genericCompanyService;
            this.genericProjectService = genericProjectService;
            this.genericActorService = genericActorService;
            this.genericOfficeWorkerService = genericOfficeWorkerService;
            this.projectService = projectService;
            this.actorService = actorService;
            this.officeWorkerService = officeWorkerService;
            InitEvents();
        }

        private void InitEvents()
        {
            Loaded += ProjectWindow_Loaded;
            btn_Submit.Click += Btn_Submit_Click;
            dp_baslangic.SelectedDateChanged += Dp_SelectedDateChanged;
            dp_bitis.SelectedDateChanged += Dp_SelectedDateChanged;
        }

        private void Dp_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dp_baslangic.SelectedDate.HasValue && dp_bitis.SelectedDate.HasValue)
            {
                var duration = GetProjectDuration();
                if (!duration.IsNull())
                {
                    var model = DataContext.Cast<ProjectAddViewModel>();
                    model.Actors.Clear();
                    model.OfficeWorkers.Clear();
                    model.Actors.AddRange(actorService.GetAllFreeActor(duration).ToList());
                    model.OfficeWorkers.AddRange(officeWorkerService.GetAllFreeOfficeWorker(duration).ToList());
                    dg_actors.Items.Refresh();
                    dg_ofw.Items.Refresh();
                }

            }
        }

        public bool EditMode { get; set; }
        private Entities.Concrete.Duration GetProjectDuration()
        {
            if (dp_baslangic.SelectedDate.IsNull() || dp_bitis.SelectedDate.IsNull())
            {
                MessageBox.Show("Başlangıç ve bitiş tarihlerini seçiniz");
                return null;
            }
            if (dp_baslangic.SelectedDate.Value > dp_bitis.SelectedDate.Value)
            {
                MessageBox.Show("Başlangıç tarihi bitis tarihinden sonra olamaz");
                return null;
            }

            Entities.Concrete.Duration duration = new(dp_baslangic.SelectedDate.Value, dp_bitis.SelectedDate.Value);

            return duration;
        }


        private void Btn_Submit_Click(object sender, RoutedEventArgs e)
        {
            var model = DataContext.Cast<ProjectAddViewModel>();
            if (!model.IsNull())
            {
                model.Project.Duration = GetProjectDuration();
                if (model.Project.Duration.IsNull())
                    return;
                var actors = dg_actors.SelectedItems.Cast<Actor>().ToList();
                var officeWorkers = dg_ofw.SelectedItems.Cast<OfficeWorker>().ToList();
                if (EditMode)
                    projectService.UpdateProject(actors, officeWorkers, model.Company, project);
                else
                {
                    int? totalProjectsCount = model.Company.Projects?.Count+1;
                    if (totalProjectsCount.HasValue && totalProjectsCount.Value>3)
                    {
                        var discountPrice = project.Cost * 0.8;
                        MessageBox.Show($"{model.Company.Name} firması ile {totalProjectsCount}. Projeniz olduğundan dolayı %20'lik indirim uygulanarak\n{model.Project.Cost} -> {discountPrice}\nOlarak Hesaplanmiştır");
                        project.Cost = discountPrice;
                    }
                    projectService.AddProject(actors, officeWorkers, model.Company, project);
                }
                   
                MessageBox.Show("Kaydedildi");
                this.Close();
            }
        }

        public void Init(Project project)
        {
            this.project = project;
            EditMode = true;
        }

        private void ProjectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (SessionContext.LoginManager.Role == Core.Enums.Role.MudurYardimcisi)
                tb_field.Visibility = Visibility.Collapsed;
            ProjectAddViewModel model = new();
            if (project.IsNull())
                this.project = new();

            model.Project = project;
            model.Companies = genericCompanyService.GetAll();
            model.Actors = new();
            model.OfficeWorkers = new();
            model.Company = project.Company;
            this.DataContext = model;

            if (project.Duration.IsNull())
            {
                dp_baslangic.DisplayDateStart = DateTime.Now;
                dp_bitis.DisplayDateStart = DateTime.Now.AddDays(1);
            }
            else
            {
                dp_baslangic.DisplayDateStart = project.Duration.StartDate;
                dp_bitis.DisplayDateStart = project.Duration.StartDate.AddDays(1);
                dp_baslangic.SelectedDate = project.Duration.StartDate;
                dp_bitis.SelectedDate = project.Duration.EndDate;
            }


        }
    }
}
