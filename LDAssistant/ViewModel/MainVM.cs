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
        public ObservableCollection<Planting> PlantingSource
        {
            get { return plantingSource; }
            set
            {
                plantingSource = value;
                OnPropertyChanged("PlantingSource");
            }
        }

        public Planting SelectedPlanting { get; set; }

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
        int ID;

        public MainVM(LDA dbcontext, int ID)
        {
            db = dbcontext;
            this.ID = ID;
            LoadPlantings();
            AddPlantingCommand = new RelayCommand(AddPlanting);
            UpdatePlantingCommand = new RelayCommand(UpdatePlanting, CanExecute);
            DeletePlantingCommand = new RelayCommand(DeletePlanting, CanExecute);
            //AddSourceCommand = new RelayCommand(AddSource);
        }

        private void LoadPlantings()
        {
            //db.Plantings.Include(i => i.Source_of_income).Include(i => i.User).Load();
            PlantingSource = new ObservableCollection<Planting>(db.Plantings.Where(i => i.Planting_ID == ID).ToList());
        }

        public void AddPlanting(object parameter)
        {
            Window window = new View.EditPlanting();
            window.DataContext = new EditPlantingVM(db, null, ID);
            window.Title = "Добавить";
            window.ShowDialog();
            //PlantingSource = new ObservableCollection<Planting>(db.Plantings.Where(i => i.User.Id == ID).ToList());
        }

        public void UpdatePlanting(object parameter)
        {
            Window window = new View.EditPlanting();
            window.DataContext = new EditPlantingVM(db, SelectedPlanting, ID);
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
