using BLL;
using DAL;
using LDAssistant.ViewModel.Edit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LDAssistant.ViewModel
{
    public class ProjectVM : BaseVM
    {
        DBOperations db;
        LDA ll;

        private ObservableCollection<Project> projectSource;
        public ObservableCollection<Project> ProjectSource
        {
            get { return projectSource; }
            set
            {
                projectSource = value;
                OnPropertyChanged("ProjectSource");
            }
        }

        Project selectedProject;
        public Project SelectedProject
        {
            get { return selectedProject; }
            set
            {
                selectedProject = value;
                OnPropertyChanged("SelectedProject");

            }
        }

        public ProjectVM()
        {
            ll = new LDA();
            db = new DBOperations(ll);
            db.GetAllProjects();
            projectSource = db.GetAllProjects();
        }

        public void AddProject()
        {
            Window window = new View.EditProject();
            window.DataContext = new EditProjectVM(ll);
            window.Title = "Добавить";
            window.ShowDialog();
            ProjectSource = new ObservableCollection<Project>(db.GetAllProjects().ToList());
        }

        public void UpdateSProject()
        {
            Window window = new View.EditProject();
            window.DataContext = new EditProjectVM(ll, SelectedProject);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        private ICommand updateProject;
        public ICommand UpdateProject
        {
            get
            {
                return updateProject ??
                      (updateProject = new RelayCommand(obj => UpdateSProject(), (obj) => SelectedProject != null));

            }
        }

        private ICommand deleteSelectProject;
        public ICommand DeleteSelectProject
        {
            get
            {
                return deleteSelectProject ??
                      (deleteSelectProject = new RelayCommand(obj => DeleteProject(), (obj) => SelectedProject != null));
            }
        }

        void DeleteProject()
        {
            db.DeleteProject(SelectedProject.Project_ID);
            ProjectSource.Remove(SelectedProject);
            db.Save();
        }

        private ICommand createProject;
        public ICommand CreateProject
        {
            get
            {
                return createProject ??
                      (createProject = new RelayCommand(obj =>
                      {
                          AddProject();
                      }));

            }
        }
    }

   
}
