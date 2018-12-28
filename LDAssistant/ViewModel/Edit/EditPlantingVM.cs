using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using BLL;
using DAL;

namespace LDAssistant.ViewModel
{
    public class EditPlantingVM : BaseVM
    {
        DBOperations db;
        LDA ll;


        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        public ObservableCollection<Status> StatusSource { get; set; }
        public ObservableCollection<Plant> PlantSource { get; set; }
        public ObservableCollection<Project> ProjectSource { get; set; }

        Planting selectedPlanting;
        public Planting SelectedPlanting
        {
            get { return selectedPlanting; }
            set
            {
                selectedPlanting = value;
                OnPropertyChanged("SelectedPlanting");
            }
        }

        public EditPlantingVM(LDA l)
            {
                ll = l;
                db = new DBOperations(ll);                

                db.GetAllPlants();
                db.GetAllStatus();
                db.GetAllProjects();

                StatusSource = new ObservableCollection<Status>();
                PlantSource = new ObservableCollection<Plant>();
                ProjectSource = new ObservableCollection<Project>();
            
                StatusSource = db.GetAllStatus();
                PlantSource = db.GetAllPlants();
                ProjectSource = db.GetAllProjects();                

                selectedPlanting = new Planting();
            }
        
        public EditPlantingVM(LDA l, Planting sp)
        {
            ll = l;
            db = new DBOperations(ll);

            db.GetAllPlants();
            db.GetAllStatus();
            db.GetAllProjects();

            StatusSource = new ObservableCollection<Status>();
            PlantSource = new ObservableCollection<Plant>();
            ProjectSource = new ObservableCollection<Project>();

            StatusSource = db.GetAllStatus();
            PlantSource = db.GetAllPlants();
            ProjectSource = db.GetAllProjects();


            selectedPlanting = new Planting();
            selectedPlanting = sp;
        }

        private void AddPlanting()
        {
            try
            {
                DialogResult = true;
                if (selectedPlanting.Planting_ID <= 0)
                    db.CreatePlanting(selectedPlanting);
                else
                    db.UpdatePlanting(selectedPlanting);
                db.Save();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private ICommand createPlanting;
        public ICommand CreatePlanting
        {
            get
            {
                return createPlanting ??
                      (createPlanting = new RelayCommand(obj =>
                      {
                          AddPlanting();
                      }));

            }
        }


    }
}
