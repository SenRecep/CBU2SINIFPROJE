using CBU2SINIFPROJE.BLL.Interfaces;
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

        public ProjectWindow(IGenericService<Company> genericCompanyService,IGenericService<Project> genericProjectService, IGenericService<Actor> genericActorService, IGenericService<OfficeWorker> genericOfficeWorkerService, IProjectService projectService, IActorService actorService,IOfficeWorkerService officeWorkerService)
        {
            InitializeComponent();
            Loaded += ProjectWindow_Loaded;
            this.genericCompanyService = genericCompanyService;
            this.genericProjectService = genericProjectService;
            this.genericActorService = genericActorService;
            this.genericOfficeWorkerService = genericOfficeWorkerService;
            this.projectService = projectService;
            this.actorService = actorService;
            this.officeWorkerService = officeWorkerService;
        }

        private void ProjectWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ProjectAddViewModel model=new();
            model.Companies = genericCompanyService.GetAll();
           

        }
    }
}
