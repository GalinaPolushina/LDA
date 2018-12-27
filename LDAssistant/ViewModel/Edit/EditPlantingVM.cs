using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace LDAssistant.ViewModel
{
    public class EditPlantingVM : BaseVM
    {
        LDA db;

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

        public EditPlantingVM()
            {
                db = new LDA();

                db.Plants.Load();
                db.Status.Load();
                db.Projects.Load();

                StatusSource = new ObservableCollection<Status>();
                PlantSource = new ObservableCollection<Plant>();
                ProjectSource = new ObservableCollection<Project>();

                StatusSource = db.Status.Local;
                PlantSource = db.Plants.Local;
                ProjectSource = db.Projects.Local;
                

                selectedPlanting = new Planting();
            }


    }
}
