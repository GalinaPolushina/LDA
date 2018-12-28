using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DBOperations
    {
        LDA db;

        public DBOperations(LDA l)
        {
            this.db = l;            
        }

        public ObservableCollection<Plant> GetAllPlants()
        {
            db.Plants.Load();
            return db.Plants.Local;
        }

        public Plant GetPlant(int id)
        {
            return db.Plants.Find(id);
        }

        public void UpdatePlant(Plant Plant)
        {
            db.Entry(Plant).State = EntityState.Modified;
        }

        public bool DeletePlant(int id)
        {
            Plant Plant = db.Plants.Find(id);
            if (Plant != null)
            {
                db.Plants.Remove(Plant);
            }
            return Save();
        }

        public bool CreatePlant(Plant Plant)
        {
            db.Plants.Add(Plant);
            return Save();
        }

        public ObservableCollection<Planting> GetAllPlantings()
        {
            db.Plantings.Load();
            return db.Plantings.Local;
        }

        public Planting GetPlanting(int id)
        {
            return db.Plantings.Find(id);
        }

        public void UpdatePlanting(Planting Planting)
        {
            db.Entry(Planting).State = EntityState.Modified;
        }

        public bool DeletePlanting(int id)
        {
            Planting Planting = db.Plantings.Find(id);
            if (Planting != null)
            {
                db.Plantings.Remove(Planting);
            }
            return Save();
        }

        public bool CreatePlanting(Planting Planting)
        {
            db.Plantings.Add(Planting);
            return Save();
        }

        public Project GetProject(int id)
        {
            return db.Projects.Find(id);
        }

        public void UpdateProject(Project Project)
        {
            db.Entry(Project).State = EntityState.Modified;
        }

        public bool DeleteProject(int id)
        {
            Project Project = db.Projects.Find(id);
            if (Project != null)
            {
                db.Projects.Remove(Project);
            }
            return Save();
        }

        public bool CreateProject(Project Project)
        {
            db.Projects.Add(Project);
            return Save();
        }

        public ObservableCollection<Status> GetAllStatus()
        {
            db.Status.Load();
            return db.Status.Local;
        }

        public ObservableCollection<Project> GetAllProjects()
        {
            db.Projects.Load();
            return db.Projects.Local;
        }

        public ObservableCollection<Soil_Type> GetAllSoilT()
        {
            db.Soil_Type.Load();
            return db.Soil_Type.Local;
        }

        public ObservableCollection<Fertilizer> GetAllFert()
        {
            db.Fertilizers.Load();
            return db.Fertilizers.Local;
        }

        public ObservableCollection<Lifespan> GetAllLifeS()
        {
            db.Lifespans.Load();
            return db.Lifespans.Local;
        }

        public ObservableCollection<Life_Form> GetAllLifeF()
        {
            db.Life_Form.Load();
            return db.Life_Form.Local;
        }

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
