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
    public class MainVM : BaseVM
    {
        DBOperations db;
        LDA ll;
        
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

        public MainVM()
        {
            ll = new LDA();
            db = new DBOperations(ll);
            db.GetAllPlantings();
            db.GetAllPlants();
            plantingSource = db.GetAllPlantings();
            plantSource = db.GetAllPlants();
        }

        public void AddPlanting()
        {
            Window window = new View.EditPlanting();
            window.DataContext = new EditPlantingVM(ll);
            window.Title = "Добавить";
            window.ShowDialog();
            PlantingSource = new ObservableCollection<Planting>(db.GetAllPlantings().ToList());
        }

        public void AddPlant()
        {
            Window window = new View.EditPlant();
            window.DataContext = new EditPlantVM(ll);
            window.Title = "Добавить";
            window.ShowDialog();
            PlantSource = new ObservableCollection<Plant>(db.GetAllPlants().ToList());
        }

        public void UpdateSPlanting()
        {
            Window window = new View.EditPlanting();
            window.DataContext = new EditPlantingVM(ll, SelectedPlanting);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        public void AboutShow()
        {
            Window window = new View.About();
            window.Show();
        }

        public void HelpShow()
        {
            Window window = new View.Help();
            window.Show();
        }
        

        public void UpdateSPlant()
        {
            Window window = new View.EditPlant();
            window.DataContext = new EditPlantVM(ll, SelectedPlant);
            window.Title = "Изменить";
            window.ShowDialog();
        }

        private ICommand updatePlanting;
        public ICommand UpdatePlanting
        {
            get
            {
                return updatePlanting ??
                      (updatePlanting = new RelayCommand(obj => UpdateSPlanting(), (obj) => SelectedPlanting != null));

            }
        }

        private ICommand updatePlant;
        public ICommand UpdatePlant
        {
            get
            {
                return updatePlant ??
                      (updatePlant = new RelayCommand(obj => UpdateSPlant(), (obj) => SelectedPlant != null));

            }
        }

        private ICommand deleteSelectPlanting;
        public ICommand DeleteSelectPlanting
        {
            get
            {
                return deleteSelectPlanting ??
                      (deleteSelectPlanting = new RelayCommand(obj => DeletePlanting(), (obj) => SelectedPlanting != null));
            }
        }

        private ICommand deleteSelectPlant;
        public ICommand DeleteSelectPlant
        {
            get
            {
                return deleteSelectPlant ??
                      (deleteSelectPlant = new RelayCommand(obj => DeletePlant(),
                      (obj) => SelectedPlant != null));
            }
        }

        void DeletePlanting()
        {
            db.DeletePlanting(SelectedPlanting.Planting_ID);
            PlantingSource.Remove(SelectedPlanting);
            db.Save();
        }

        void DeletePlant()
        {
            db.DeletePlant(SelectedPlant.Plant_ID);
            PlantSource.Remove(SelectedPlant);
            db.Save();
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

        private ICommand createPlant;
        public ICommand CreatePlant
        {
            get
            {
                return createPlant ??
                      (createPlant = new RelayCommand(obj =>
                      {
                          AddPlant();
                      }));

            }
        }

        private ICommand sa;
        public ICommand SA
        {
            get
            {
                return sa ??
                      (sa = new RelayCommand(obj =>
                      {
                          AboutShow();
                      }));

            }
        }

        private ICommand sh;
        public ICommand SH
        {
            get
            {
                return sh ??
                      (sh = new RelayCommand(obj =>
                      {
                          HelpShow();
                      }));

            }
        }
        
    }
}
