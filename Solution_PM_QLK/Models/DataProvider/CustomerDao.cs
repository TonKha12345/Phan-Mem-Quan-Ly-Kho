using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class CustomerDao
    {
        private QuanLyKhoDbContext db;

        public CustomerDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public ObservableCollection<Customer> GetListAll()
        {
            return new ObservableCollection<Customer>(db.Customers.OrderBy(x => x.STT));
        }

        public Customer GetByID(int ID)
        {
            return db.Customers.FirstOrDefault(u => u.ID == ID);
        }

        public Customer GetByDisplayName(string DisplayName)
        {
            return db.Customers.FirstOrDefault(u => u.DisplayName == DisplayName);
        }

        public int GetSTT()
        {
            var customer = db.Customers.ToList();
            var lastCustomer = customer.LastOrDefault();
            int stt = lastCustomer.STT;
            return stt += 1;
        }

        public int Insert(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
            return customer.ID;
        }

        public bool Edit(Customer customer, string DisplayName, string Address, string Phone, string Email, DateTime? ContractDate, string MoreInfo)
        {
            var editCustomer = db.Customers.FirstOrDefault(x => x.ID == customer.ID);
            editCustomer.DisplayName = DisplayName;
            editCustomer.Address = Address;
            editCustomer.Phone = Phone;
            editCustomer.Email = Email;
            editCustomer.ContractDate = ContractDate;
            editCustomer.MoreInfo = MoreInfo;
            db.SaveChanges();
            return true;
        }

        public bool Delete(Customer customer)
        {
            db.Customers.Remove(customer);
            db.SaveChanges();
            return true;
        }
    }
}
