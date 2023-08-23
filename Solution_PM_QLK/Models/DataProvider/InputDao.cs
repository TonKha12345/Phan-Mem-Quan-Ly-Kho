using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class InputDao
    {
        private QuanLyKhoDbContext db;

        public InputDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public ObservableCollection<Input> GetListAll()
        {
            return new ObservableCollection<Input>(db.Inputs.OrderBy(x => x.ID));
        }
        public Input GetByID(int ID)
        {
            return db.Inputs.FirstOrDefault(u => u.ID == ID);
        }

        public Input GetByDisplayName(string DisplayName)
        {
            return db.Inputs.FirstOrDefault(u => u.DisplayName == DisplayName);
        }

        public int Insert(Input input)
        {
            db.Inputs.Add(input);
            db.SaveChanges();
            return input.ID;
        }

        public bool Edit(Input input, string DisplayName, DateTime? dateInput)
        {
            var editInput = db.Inputs.FirstOrDefault(x => x.ID == input.ID);
            editInput.DisplayName = DisplayName;
            editInput.DateInput = dateInput;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Input input)
        {
            var deleteInput = db.Inputs.Remove(input);
            db.SaveChanges();
            return true;
        }
    }
}
