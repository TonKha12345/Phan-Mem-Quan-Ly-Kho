using Models.DataProvider;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class SuplierViewModel: BaseViewModel
    {
        private ObservableCollection<Suplier> _ListSuplier;
        public ObservableCollection<Suplier> ListSuplier { get { return _ListSuplier; } set { _ListSuplier = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; OnPropertyChanged(); } }

        private string _Phone;
        public string Phone { get { return _Phone; } set { _Phone = value; OnPropertyChanged(); } }

        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; OnPropertyChanged(); } }

        private DateTime? _ContractDate;
        public DateTime? ContractDate { get { return _ContractDate; } set { _ContractDate = value; OnPropertyChanged(); } }

        private string _MoreInfo;
        public string MoreInfo { get { return _MoreInfo; } set { _MoreInfo = value; OnPropertyChanged(); } }

        private Suplier _SelectedItemSource;
        public Suplier SelectedItemSource
        {
            get { return _SelectedItemSource; }
            set
            {
                _SelectedItemSource = value; OnPropertyChanged();
                if (SelectedItemSource != null)
                {
                    DisplayName = SelectedItemSource.DisplayName;
                    Address = SelectedItemSource.Address;
                    Phone = SelectedItemSource.Phone;
                    Email = SelectedItemSource.Email;
                    ContractDate = SelectedItemSource.ContractDate;
                    MoreInfo = SelectedItemSource.MoreInfo;
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public SuplierViewModel()
        {
            var dao = new SuplierDao();
            ListSuplier = dao.GetListAll();

            AddCommand = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName))
                {
                    return false;
                }
                var result = dao.GetByDisplayName(DisplayName);
                if (result != null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var addSuplier = new Suplier();
                addSuplier.DisplayName = DisplayName;
                addSuplier.STT = dao.GetSTT();
                addSuplier.Address = Address;
                addSuplier.Phone = Phone;
                addSuplier.Email = Email;
                addSuplier.ContractDate = ContractDate;
                addSuplier.MoreInfo = MoreInfo;

                var result = dao.Insert(addSuplier);
                ListSuplier.Add(addSuplier);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var editSuplier = dao.GetByID(SelectedItemSource.ID);
                if (editSuplier != null)
                {
                    var result = dao.Edit(editSuplier, DisplayName, Address, Phone, Email, ContractDate, MoreInfo);
                    if (result)
                    {
                        SelectedItemSource.DisplayName = DisplayName;
                        SelectedItemSource.Address = Address;
                        SelectedItemSource.Phone = Phone;
                        SelectedItemSource.Email = Email;
                        SelectedItemSource.ContractDate = ContractDate;
                        SelectedItemSource.MoreInfo = MoreInfo;
                    }
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                var result = dao.GetByDisplayName(DisplayName);
                if (result == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteSuplier = dao.GetByID(SelectedItemSource.ID);
                if (deleteSuplier != null)
                {
                    var result = dao.Delete(deleteSuplier);
                    ListSuplier.Remove(deleteSuplier);
                }
            });
        }
    }
}
