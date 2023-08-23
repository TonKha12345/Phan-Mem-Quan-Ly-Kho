using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class SuplierDao
    {
        private QuanLyKhoDbContext db;
        public SuplierDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public ObservableCollection<Suplier> GetListAll()
        {
            return new ObservableCollection<Suplier>(db.Supliers.OrderBy(x => x.STT));
        }

        public Suplier GetByID(int ID)
        {
            return db.Supliers.FirstOrDefault(u => u.ID == ID);
        }

        public Suplier GetByDisplayName(string DisplayName)
        {
            return db.Supliers.FirstOrDefault(u => u.DisplayName == DisplayName);
        }

        public int GetSTT()
        {
            var suplier = db.Supliers.ToList();
            var lastSuplier = suplier.LastOrDefault();
            int stt = lastSuplier.STT;
            return stt += 1;
        }

        public int Insert(Suplier suplier)
        {
            db.Supliers.Add(suplier);
            db.SaveChanges();
            return suplier.ID;
        }

        public bool Edit(Suplier suplier, string DisplayName, string Address, string Phone, string Email, DateTime? ContractDate, string MoreInfo)
        {
            var editSuplier = db.Supliers.FirstOrDefault(x => x.ID == suplier.ID);
            editSuplier.DisplayName = DisplayName;
            editSuplier.Address = Address;
            editSuplier.Phone = Phone;
            editSuplier.Email = Email;
            editSuplier.ContractDate = ContractDate;
            editSuplier.MoreInfo = MoreInfo;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Suplier suplier)
        {
            db.Supliers.Remove(suplier);
            db.SaveChanges();
            return true;
        }
    }
}

