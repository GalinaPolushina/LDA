using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LDAssistant.ViewModel.Edit
{
    public class EditProjectVM : BaseVM
    {
        DBOperations db;
        LDA ll;

        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

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

        public EditProjectVM(LDA l)
        {
            ll = l;
            db = new DBOperations(ll);

            selectedProject = new Project();
        }

        public EditProjectVM(LDA l, Project p)
        {
            ll = l;
            db = new DBOperations(ll);

            selectedProject = new Project();
            selectedProject = p;
        }

        private void AddProject()
        {
            try
            {
                DialogResult = true;
                if (selectedProject.Project_ID <= 0)
                    //db.Projects.Add(selectedProject);  
                    db.CreateProject(selectedProject);
                else
                    db.UpdateProject(selectedProject);
                //db.SaveChanges();
                db.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
