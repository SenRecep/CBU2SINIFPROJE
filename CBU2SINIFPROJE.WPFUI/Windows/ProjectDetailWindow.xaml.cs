using System;
using System.Collections.Generic;
using System.Windows;

using CBU2SINIFPROJE.Entities.Concrete;

namespace CBU2SINIFPROJE.WPFUI.Windows
{
    /// <summary>
    /// Interaction logic for ProjectDetailWindow.xaml
    /// </summary>
    public partial class ProjectDetailWindow : Window
    {
        private readonly Employee employee;

        public ProjectDetailWindow(Employee employee)
        {
            InitializeComponent();
            this.employee = employee;
            Loaded += ProjectDetailWindow_Loaded;
        }

        private void ProjectDetailWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Project> projects = null;
            Project lastProject = null;
            if (employee is Actor actor)
                projects = actor.Projects;
            if (employee is OfficeWorker officeWorker)
                projects = officeWorker.Projects;
            dg_projects.ItemsSource = projects;

            foreach (Project item in projects)
                if (item.Duration.StartDate <= DateTime.Now && item.Duration.EndDate >= DateTime.Now)
                {
                    lastProject = item;
                    break;
                }
            last_projectName.Content = lastProject.Name;
            last_projectStart.Content = lastProject.Duration.StartDate.ToShortDateString();
            last_projectEnd.Content = lastProject.Duration.EndDate.ToShortDateString();
        }
    }
}
