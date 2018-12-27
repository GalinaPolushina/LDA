using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;

namespace LDAssistant.ViewModel
{
    public class MainVM : BaseVM
    {
        private ObservableCollection<Planting> plantingSource;
        //свойство 
        public ObservableCollection<Planting> PlantingSource
        {
            get { return plantingSource; }
            set
            {
                plantingSource = value;
                OnPropertyChanged("PlantingSource");

            }
        }

        private ObservableCollection<Plant> plantSource;
        //свойство 
        public ObservableCollection<Plant> PlantSource
        {
            get { return plantSource; }
            set
            {
                plantSource = value;
                OnPropertyChanged("PlantSource");

            }
        }

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

        Plant selectedPlant;
        public Plant SelectedPlant
        {
            get { return selectedPlant; }
            set
            {
                selectedPlant = value;
                OnPropertyChanged("SelectedPlant");

            }
        }

        RelayCommand addPlantingCommand;
        public RelayCommand AddPlantingCommand
        {
            get { return addPlantingCommand; }
            set { addPlantingCommand = value; }
        }

        RelayCommand updatePlantingCommand;
        public RelayCommand UpdatePlantingCommand
        {
            get { return updatePlantingCommand; }
            set { updatePlantingCommand = value; }
        }

        RelayCommand deletePlantingCommand;
        public RelayCommand DeletePlantingCommand
        {
            get { return deletePlantingCommand; }
            set { deletePlantingCommand = value; }
        }

        private LDA db;

        public MainVM()
        {
            db = new LDA();
            db.Plants.Load();
            db.Plantings.Load();
            plantingSource = db.Plantings.Local;
            plantSource = db.Plants.Local;
            AddPlantingCommand = new RelayCommand(AddPlanting);
            UpdatePlantingCommand = new RelayCommand(UpdatePlanting, CanExecute);
            DeletePlantingCommand = new RelayCommand(DeletePlanting, CanExecute);
            //AddSourceCommand = new RelayCommand(AddSource);
        }

        public void AddPlanting(object parameter)
        {
            Window window = new View.EditPlanting();
            //window.DataContext = new EditPlantingVM(db, null);
            window.Title = "Добавить";
            window.ShowDialog();
            //PlantingSource = new ObservableCollection<Planting>(db.Plantings.Where(i => i.User.Id == ID).ToList());
        }

        public void UpdatePlanting(object parameter)
        {
            Window window = new View.EditPlanting();
            //window.DataContext = new EditPlantingVM(db, SelectedPlanting);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void DeletePlanting(Object parameter)
        {

            //if (ConfirmDialog.Confirm($"Удалить посадку?"))
            //{
                db.Plantings.Local.Remove(SelectedPlanting);
                PlantingSource.Remove(SelectedPlanting);
                db.SaveChanges();
            //}
        }

        public bool CanExecute(object parameter)
        {
            return SelectedPlanting != null;
        }
    }
}
