using Models.EF;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class InputInfoDao
    {
        private QuanLyKhoDbContext db;

        public InputInfoDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public List<InputInfo> GetByIDObject( int ID)
        {
            return db.InputInfoes.Where(x => x.IDObject == ID).ToList();
        }

        public InputInfo GetByID(int ID)
        {
            return db.InputInfoes.FirstOrDefault(u => u.ID == ID);
        }

        public int Insert(InputInfo inputInfo)
        {
            db.InputInfoes.Add(inputInfo);
            db.SaveChanges();
            return inputInfo.ID;
        }

        public bool EditData(InputInfo inputInfo, int IDObject, int IDInput, double Count, double InputPrice, double Total, string Status)
        {
            var editData = db.InputInfoes.FirstOrDefault(x => x.ID == inputInfo.ID);
            if(editData != null)
            {
                editData.IDObject = IDObject;
                editData.IDInput = IDInput;
                editData.Count = Count;
                editData.InputPrice = InputPrice;
                editData.Total = Total;
                editData.Status = Status;
                db.SaveChanges();
                return true;
            }
            return false;
            
        }

        public bool Delete(InputInfo inputInfo)
        {
            var deleteInputInfo = db.InputInfoes.Remove(inputInfo);
            db.SaveChanges();
            return true;
        }

        public bool DeleteInfo(List<InputInfo> list)
        {
            var deleteInputInfo = db.InputInfoes.RemoveRange(list);
            db.SaveChanges();
            return true;
        }

        public bool DeleteByIDInput(int IDInput)
        {
            var list = db.InputInfoes.Where(x => x.IDInput == IDInput).ToList();
            var deleteInputInfo = db.InputInfoes.RemoveRange(list);
            db.SaveChanges();
            return true;
        }

        public List<InputInfo> GetListByIDInput(int IDInput)
        {
            return db.InputInfoes.Where(x => x.IDInput == IDInput).ToList();
        }

        public int GetSTT()
        {
            var inputInfo = db.InputInfoes.ToList();
            var lastInfo = inputInfo.LastOrDefault();
            if(lastInfo == null)
            {
                return 1; 
            }
            else
            {
                int stt = lastInfo.STT;
                return stt += 1;
            }
        }

        public ObservableCollection<Objects> GetListObjects()
        {
            return new ObservableCollection<Objects>(db.Objects.OrderBy(x => x.STT));
        }

        public Suplier GetSuplier(int IDSuplier)
        {
            return db.Supliers.FirstOrDefault(x => x.ID == IDSuplier);
        }

        public Unit GetUnit(int IDUnit)
        {
            return db.Units.FirstOrDefault(x => x.ID == IDUnit);
        }

        public ObservableCollection<InputInfoModel> InputInfoModels()
        {
            var data = (from a in db.InputInfoes
                        join b in db.Objects on a.IDObject equals b.ID
                        join c in db.Inputs on a.IDInput equals c.ID
                        join d in db.Supliers on b.IDSuplier equals d.ID
                        join e in db.Units on b.IDUnit equals e.ID
                        select new
                        {
                            ID = a.ID,
                            STT = a.STT,
                            Object = b,
                            Unit = e,
                            Input = c,
                            Suplier = d,
                            Count = a.Count,
                            InputPrice = a.InputPrice,
                            Total = a.Total,
                            Status = a.Status,
                        }).AsEnumerable().Select(x => new InputInfoModel
                        {
                            ID = x.ID,
                            STT = x.STT,
                            Object = x.Object,
                            Input = x.Input,
                            Unit = x.Unit,
                            Suplier = x.Suplier,
                            Count = x.Count,
                            InputPrice = x.InputPrice,
                            Total = x.Total,
                            Status = x.Status,
                        });
            return new ObservableCollection<InputInfoModel>(data);
        }

        public ObservableCollection<InputInfoModel> InputInfoModels(int IDInput)
        {
            var data = (from a in db.InputInfoes
                        join b in db.Objects on a.IDObject equals b.ID
                        join c in db.Inputs on a.IDInput equals c.ID
                        join d in db.Supliers on b.IDSuplier equals d.ID
                        join e in db.Units on b.IDUnit equals e.ID
                        where a.IDInput == IDInput
                        select new
                        {
                            ID = a.ID,
                            STT = a.STT,
                            Object = b,
                            Unit = e,
                            Input = c,
                            Suplier = d,
                            Count = a.Count,
                            InputPrice = a.InputPrice,
                            Total = a.Total,
                            Status = a.Status,
                        }).AsEnumerable().Select(x => new InputInfoModel
                        {
                            ID = x.ID,
                            STT = x.STT,
                            Object = x.Object,
                            Unit = x.Unit,
                            Input = x.Input,
                            Suplier = x.Suplier,
                            Count = x.Count,
                            InputPrice = x.InputPrice,
                            Total = x.Total,
                            Status = x.Status,
                        });
            return new ObservableCollection<InputInfoModel>(data);
        }
    }
}
