using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class UnitDao
    {
        private QuanLyKhoDbContext db;

        public UnitDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public Unit GetByID(int ID)
        {
            return db.Units.FirstOrDefault(u => u.ID == ID);
        }

        public Unit GetByDisplayName(string DisplayName)
        {
            return db.Units.FirstOrDefault(u => u.DisplayName == DisplayName);
        }

        public ObservableCollection<Unit> GetListAll()
        {
            return new ObservableCollection<Unit>(db.Units.OrderBy(x => x.STT));
        }

        public int Insert(Unit unit)
        {
            db.Units.Add(unit);
            db.SaveChanges();
            return unit.ID;
        }

        public bool Edit(Unit unit, string DisplayName)
        {
            var editUnit = db.Units.FirstOrDefault(x => x.ID == unit.ID);
            editUnit.DisplayName = DisplayName;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Unit unit)
        { 
            var deleteUnit = db.Units.Remove(unit);
            db.SaveChanges();
            return true;
        }

        public int GetSTT()
        {
            var units = db.Units.ToList();
            var lastUnit = units.LastOrDefault();
            int stt = lastUnit.STT;
            return stt+=1;
        }
    }
}
