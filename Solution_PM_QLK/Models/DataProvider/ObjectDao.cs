using Models.EF;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class ObjectDao
    {
        private QuanLyKhoDbContext db;

        public ObjectDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public List<Objects> GetListObject()
        {
            return db.Objects.ToList();
        }

        public Objects GetByID(int ID)
        {
            return db.Objects.Find(ID);
        }

        public Unit GetUnitByIDObject(int IDObject)
        { 
            var ob = db.Objects.Find(IDObject);
            return db.Units.FirstOrDefault(x => x.ID == ob.IDUnit);
        }

        public ObservableCollection<ObjectsModel> ObjectModels()
        {
            var data = (from a in db.Objects
                        join b in db.Units on a.IDUnit equals b.ID
                        join c in db.Supliers on a.IDSuplier equals c.ID
                        select new
                        {
                            ID = a.ID,
                            STT = a.STT,
                            DisplayName = a.DisplayName,
                            Unit = b,
                            Suplier = c,
                            QRCode = a.QRCode,
                            BarCode = a.BarCode,

                        }).AsEnumerable().Select(x => new ObjectsModel
                        {
                            ID = x.ID,
                            STT = x.STT,
                            DisplayName = x.DisplayName,
                            Unit = x.Unit,
                            Suplier = x.Suplier,
                            QRCode = x.QRCode,
                            BarCode = x.BarCode,
                        });
            return new ObservableCollection<ObjectsModel>(data);
        }

        public Objects GetByDisplayName(string DisplayName)
        {
            return db.Objects.FirstOrDefault(u => u.DisplayName == DisplayName);
        }
        public int GetSTT()
        {
            var objects = db.Objects.ToList();
            var lastObject = objects.LastOrDefault();
            int stt = lastObject.STT;
            return stt += 1;
        }

        public int Insert(Objects objects)
        {
            db.Objects.Add(objects);
            db.SaveChanges();
            return objects.ID;
        }

        public bool Edit(Objects objects, string DisplayName, int IDSuplier, int IDUnit, string BarCode, string QRCode)
        {
            try
            {
                var editObjects = db.Objects.FirstOrDefault(x => x.ID == objects.ID);
                editObjects.DisplayName = DisplayName;
                editObjects.IDSuplier = IDSuplier;
                editObjects.IDUnit = IDUnit;
                editObjects.BarCode = BarCode;
                editObjects.QRCode = QRCode;
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }

        public bool Delete(Objects objects)
        {
            try
            {
                var deleteObjects = db.Objects.Remove(objects);
                db.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
