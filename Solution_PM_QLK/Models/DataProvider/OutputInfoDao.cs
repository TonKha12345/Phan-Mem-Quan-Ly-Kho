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
    public class OutputInfoDao
    {
        private QuanLyKhoDbContext db;

        public OutputInfoDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public List<OutputInfo> GetByIDObject(int ID)
        {
            return db.OutputInfoes.Where(x => x.IDObject == ID).ToList();
        }

        public Objects GetObject(int ID)
        {
            return db.Objects.FirstOrDefault(x => x.ID == ID);
        }

        public Customer GetCustomer(int ID)
        {
            return db.Customers.FirstOrDefault(x => x.ID == ID);
        }

        public Output GetOutput(int ID)
        {
            return db.Outputs.FirstOrDefault(x => x.ID == ID);
        }

        public ObservableCollection<OutputInfo> GetListAll()
        {
            return new ObservableCollection<OutputInfo>(db.OutputInfoes.OrderBy(x => x.ID));
        }
        public OutputInfo GetByID(int ID)
        {
            return db.OutputInfoes.FirstOrDefault(u => u.ID == ID);
        }

        public int Insert(OutputInfo outputInfo)
        {
            db.OutputInfoes.Add(outputInfo);
            db.SaveChanges();
            return outputInfo.ID;
        }

        public bool EditData(OutputInfo outputInfo, int IDObject, int IDOutput,int IDCustomer, double Count, double OutputPrice, double Total, string Status)
        {
            var editData = db.OutputInfoes.FirstOrDefault(x => x.ID == outputInfo.ID);
            if (editData != null)
            {
                editData.IDObject = IDObject;
                editData.IDOutput = IDOutput;
                editData.IDCustomer = IDCustomer;
                editData.Count = Count;
                editData.OutputPrice = OutputPrice;
                editData.Total = Total;
                editData.Status = Status;
                db.SaveChanges();
                return true;
            }
            return false;

        }



        public bool Delete(OutputInfo outputInfo)
        {
            var deleteOutputInfo = db.OutputInfoes.Remove(outputInfo);
            db.SaveChanges();
            return true;
        }

        public bool DeleteInfo(List<OutputInfo> list)
        {
            var deleteOutputInfo = db.OutputInfoes.RemoveRange(list);
            db.SaveChanges();
            return true;
        }

        public bool DeleteByIDOutput(int IDOutput)
        {
            var list = db.OutputInfoes.Where(x => x.IDOutput == IDOutput).ToList();
            var deleteInputInfo = db.OutputInfoes.RemoveRange(list);
            db.SaveChanges();
            return true;
        }

        public List<OutputInfo> GetListByIDOutput(int IDOutput)
        {
            return db.OutputInfoes.Where(x => x.IDOutput == IDOutput).ToList();
        }

        public int GetSTT()
        {
            var outputInfo = db.OutputInfoes.ToList();
            var lastInfo = outputInfo.LastOrDefault();
            int stt = lastInfo.STT;
            return stt += 1;
        }

        public ObservableCollection<Objects> GetListObjects()
        {
            return new ObservableCollection<Objects>(db.Objects.OrderBy(x => x.STT));
        }

        public ObservableCollection<Customer> GetListCustomer()
        {
            return new ObservableCollection<Customer>(db.Customers.OrderBy(x => x.STT));
        }

        public Unit GetUnit(int IDUnit)
        {
            return db.Units.FirstOrDefault(x => x.ID == IDUnit);
        }

        public ObservableCollection<OutputInfoModel> OutputInfoModels()
        {
            var data = (from a in db.OutputInfoes
                        join b in db.Objects on a.IDObject equals b.ID
                        join c in db.Outputs on a.IDOutput equals c.ID
                        join d in db.Customers on a.IDCustomer equals d.ID
                        join e in db.Units on b.IDUnit equals e.ID
                        select new
                        {
                            ID = a.ID,
                            STT = a.STT,
                            Object = b,
                            Unit  =e,
                            Output = c,
                            Customer = d,
                            Count = a.Count,
                            OutputPrice = a.OutputPrice,
                            Total = a.Total,
                            Status = a.Status,
                        }).AsEnumerable().Select(x => new OutputInfoModel
                        {
                            ID = x.ID,
                            STT = x.STT,
                            Object = x.Object,
                            Unit =x.Unit,
                            Output = x.Output,
                            Customer = x.Customer,
                            Count = x.Count,
                            OutputPrice = x.OutputPrice,
                            Total = x.Total,
                            Status = x.Status,
                        });
            return new ObservableCollection<OutputInfoModel>(data);
        }

        public ObservableCollection<OutputInfoModel> OutputInfoModels(int IDOutput)
        {
            var data = (from a in db.OutputInfoes
                        join b in db.Objects on a.IDObject equals b.ID
                        join c in db.Outputs on a.IDOutput equals c.ID
                        join d in db.Customers on a.IDCustomer equals d.ID
                        join e in db.Units on b.IDUnit equals e.ID
                        where a.IDOutput == IDOutput
                        select new
                        {
                            ID = a.ID,
                            STT = a.STT,
                            Object = b,
                            Unit = e,
                            Output = c,
                            Customer = d,
                            Count = a.Count,
                            OutputPrice = a.OutputPrice,
                            Total = a.Total,
                            Status = a.Status,
                        }).AsEnumerable().Select(x => new OutputInfoModel
                        {
                            ID = x.ID,
                            STT = x.STT,
                            Object = x.Object,
                            Unit = x.Unit,
                            Output = x.Output,
                            Customer = x.Customer,
                            Count = x.Count,
                            OutputPrice = x.OutputPrice,
                            Total = x.Total,
                            Status = x.Status,
                        });
            return new ObservableCollection<OutputInfoModel>(data);
        }
    }
}
