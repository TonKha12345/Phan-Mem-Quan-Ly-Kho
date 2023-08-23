using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class OutputDao
    {
        private QuanLyKhoDbContext db;

        public OutputDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public ObservableCollection<Output> GetListAll()
        {
            return new ObservableCollection<Output>(db.Outputs.OrderBy(x => x.ID));
        }
        public Output GetByID(int ID)
        {
            return db.Outputs.FirstOrDefault(u => u.ID == ID);
        }

        public Output GetByDisplayName(string DisplayName)
        {
            return db.Outputs.FirstOrDefault(u => u.DisplayName == DisplayName);
        }

        public int Insert(Output output)
        {
            db.Outputs.Add(output);
            db.SaveChanges();
            return output.ID;
        }

        public bool Edit(Output output, string DisplayName, DateTime? dateOutput)
        {
            var editOutput = db.Outputs.FirstOrDefault(x => x.ID == output.ID);
            editOutput.DisplayName = DisplayName;
            editOutput.DateOutput = dateOutput;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Output output)
        {
            var deleteOutput = db.Outputs.Remove(output);
            db.SaveChanges();
            return true;
        }
    }
}
