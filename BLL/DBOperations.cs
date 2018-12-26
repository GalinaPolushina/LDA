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

        public DBOperations()
        {
            this.db = new LDA();
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

        public bool Save()
        {
            if (db.SaveChanges() > 0) return true;
            return false;
        }
    }
}
