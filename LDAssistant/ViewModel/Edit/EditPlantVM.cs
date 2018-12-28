using BLL;
using DAL;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LDAssistant.ViewModel.Edit
{
    public class EditPlantVM : BaseVM
    {
        DBOperations db;
        LDA ll;

        bool? dr;
        public bool? DialogResult { get { return dr; } set { dr = value; } }

        public ObservableCollection<Fertilizer> FertSource { get; set; }
        public ObservableCollection<Soil_Type> SoilTSource { get; set; }
        public ObservableCollection<Lifespan> LifeSSource { get; set; }
        public ObservableCollection<Life_Form> LifeFSource { get; set; }

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

        public EditPlantVM(LDA l)
        {
            ll = l;
            db = new DBOperations(ll);

            db.GetAllFert();
            db.GetAllSoilT();
            db.GetAllLifeS();
            db.GetAllLifeF();

            FertSource = new ObservableCollection<Fertilizer>();
            SoilTSource = new ObservableCollection<Soil_Type>();
            LifeSSource = new ObservableCollection<Lifespan>();
            LifeFSource = new ObservableCollection<Life_Form>();

            FertSource = db.GetAllFert();
            SoilTSource = db.GetAllSoilT();
            LifeSSource = db.GetAllLifeS();
            LifeFSource = db.GetAllLifeF();

            selectedPlant = new Plant();
        }

        public EditPlantVM(LDA l, Plant sp)
        {
            ll = l;
            db = new DBOperations(ll);

            db.GetAllFert();
            db.GetAllSoilT();
            db.GetAllLifeS();
            db.GetAllLifeF();

            FertSource = new ObservableCollection<Fertilizer>();
            SoilTSource = new ObservableCollection<Soil_Type>();
            LifeSSource = new ObservableCollection<Lifespan>();
            LifeFSource = new ObservableCollection<Life_Form>();

            FertSource = db.GetAllFert();
            SoilTSource = db.GetAllSoilT();
            LifeSSource = db.GetAllLifeS();
            LifeFSource = db.GetAllLifeF();

            selectedPlant = new Plant();
            selectedPlant = sp;
        }

        private void AddPlant()
        {
            try
            {
                DialogResult = true;
                if (selectedPlant.Plant_ID <= 0)
                    //db.Plants.Add(selectedPlant);  
                    db.CreatePlant(selectedPlant);
                else
                    db.UpdatePlant(selectedPlant);
                //db.SaveChanges();
                db.Save();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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

        public void OFD()
        {
            
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == true )
            {
                Console.WriteLine("проверку прошли");
                string sFileName = openFileDialog1.FileName;
                Console.WriteLine(sFileName);
                selectedPlant.Image = sFileName;                    
            }

        }

        private ICommand openfd;
        public ICommand OpenFD
        {
            get
            {
                return openfd ??
                      (openfd = new RelayCommand(obj =>
                      {
                          OFD();
                      }));

            }
        }




    }
}
