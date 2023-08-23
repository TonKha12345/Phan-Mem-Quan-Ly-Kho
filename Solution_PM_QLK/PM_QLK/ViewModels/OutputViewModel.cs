using Models.DataProvider;
using Models.EF;
using Models.Model;
using PM_QLK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class OutputViewModel : BaseViewModel
    {
        #region Input
        private ObservableCollection<Output> _ListOutput;
        public ObservableCollection<Output> ListOutput { get { return _ListOutput; } set { _ListOutput = value; OnPropertyChanged(); } }

        private string _DisplayNameOutput;
        public string DisplayNameOutput { get { return _DisplayNameOutput; } set { _DisplayNameOutput = value; OnPropertyChanged(); } }

        private DateTime? _DateOutput;
        public DateTime? DateOutput { get { return _DateOutput; } set { _DateOutput = value; OnPropertyChanged(); } }

        private Output _SelectedItemSource;
        public Output SelectedItemSource
        {
            get { return _SelectedItemSource; }
            set
            {
                _SelectedItemSource = value; OnPropertyChanged();
                if (SelectedItemSource != null)
                {
                    DisplayNameOutput = SelectedItemSource.DisplayName;
                    DateOutput = SelectedItemSource.DateOutput;

                    //Get list outputInfo
                    var daoOutputInfo = new OutputInfoDao();
                    ListOutputInfo = daoOutputInfo.OutputInfoModels(SelectedItemSource.ID);
                }
            }
        }

        public ICommand AddCommandOutput { get; set; }
        public ICommand EditCommandOutput { get; set; }
        public ICommand DeleteCommandOutput { get; set; }
        #endregion



        #region OutputInfo
        private ObservableCollection<OutputInfoModel> _ListOutputInfo;
        public ObservableCollection<OutputInfoModel> ListOutputInfo { get { return _ListOutputInfo; } set { _ListOutputInfo = value; OnPropertyChanged(); } }

        private Objects _SelectedObject;
        public Objects SelectedObject { get { return _SelectedObject; } set { _SelectedObject = value; OnPropertyChanged(); } }

        private OutputInfoModel _SelectedItemSourceInfo;
        public OutputInfoModel SelectedItemSourceInfo
        {
            get { return _SelectedItemSourceInfo; }
            set
            {
                _SelectedItemSourceInfo = value; OnPropertyChanged();
                if (SelectedItemSourceInfo != null)
                {
                    Count = SelectedItemSourceInfo.Count;
                    OutputPrice = SelectedItemSourceInfo.OutputPrice;
                    Status = SelectedItemSourceInfo.Status;
                    Total = SelectedItemSourceInfo.Total;
                    SelectedObject = SelectedItemSourceInfo.Object;
                    SelectedCustomer = SelectedItemSourceInfo.Customer;
                }
            }
        }

        private ObservableCollection<Objects> _ListObject;
        public ObservableCollection<Objects> ListObject { get { return _ListObject; } set { _ListObject = value; OnPropertyChanged(); } }

        private ObservableCollection<Customer> _ListCustomer;
        public ObservableCollection<Customer> ListCustomer { get { return _ListCustomer; } set { _ListCustomer = value; OnPropertyChanged(); } }

        private Customer _SelectedCustomer;
        public Customer SelectedCustomer { get { return _SelectedCustomer; } set { _SelectedCustomer = value; OnPropertyChanged(); } }

        private double _Count;
        public double Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }

        private double _OutputPrice;
        public double OutputPrice { get { return _OutputPrice; } set { _OutputPrice = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }

        private double _Total;
        public double Total { get { return _Total; } set { _Total = value; OnPropertyChanged(); } }

        public ICommand AddCommandOutputInfo { get; set; }
        public ICommand EditCommandOutputInfo { get; set; }
        public ICommand DeleteCommandOutputInfo { get; set; }
        #endregion

        public OutputViewModel()
        {
            #region Output
            //Output 
            var daoOutput = new OutputDao();
            var dao = new OutputInfoDao();
            ListOutput = daoOutput.GetListAll();

            AddCommandOutput = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayNameOutput))
                {
                    return false;
                }
                var result = daoOutput.GetByDisplayName(DisplayNameOutput);
                if (result != null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var addOutput = new Output();
                addOutput.DisplayName = DisplayNameOutput;
                addOutput.DateOutput = DateOutput;

                var result = daoOutput.Insert(addOutput);
                ListOutput.Add(addOutput);
            });

            EditCommandOutput = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var editOutput = daoOutput.GetByID(SelectedItemSource.ID);
                if (editOutput != null)
                {
                    var result = daoOutput.Edit(editOutput, DisplayNameOutput, DateOutput);
                    if (result)
                    {
                        SelectedItemSource.DisplayName = DisplayNameOutput;
                        SelectedItemSource.DateOutput = DateOutput;
                    }
                }
            });

            DeleteCommandOutput = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteOutput = daoOutput.GetByID(SelectedItemSource.ID);
                if (deleteOutput != null)
                {
                    //Delete Data
                    var result = daoOutput.Delete(deleteOutput);
                    var relateOutputInfo = dao.GetListByIDOutput(SelectedItemSource.ID);
                    dao.DeleteInfo(relateOutputInfo);

                    //Delete List
                    ListOutput.Remove(deleteOutput);

                    var listOutputInfo = ListOutputInfo.Where(x => x.Output.ID == deleteOutput.ID).ToList();
                    foreach (var item in listOutputInfo)
                    {
                        ListOutputInfo.Remove(item);
                    }
                }
            });
            #endregion

            #region Output Info
            //Output Info

            ListObject = dao.GetListObjects();
            ListCustomer = dao.GetListCustomer();
            AddCommandOutputInfo = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null || SelectedObject == null || SelectedCustomer == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                //add data
                var addOutputInfo = new OutputInfo();
                addOutputInfo.STT = dao.GetSTT();
                addOutputInfo.IDObject = SelectedObject.ID;
                addOutputInfo.IDOutput = SelectedItemSource.ID;
                addOutputInfo.IDCustomer = SelectedCustomer.ID;
                addOutputInfo.Count = Count;
                addOutputInfo.OutputPrice = OutputPrice;
                addOutputInfo.Status = Status;
                addOutputInfo.Total = OutputPrice * Count;
                var result = dao.Insert(addOutputInfo);

                //add List
                var addList = new OutputInfoModel();
                addList.STT = ListOutputInfo.Count() + 1;
                addList.Object = SelectedObject;
                addList.Output = SelectedItemSource;
                addList.Customer = SelectedCustomer;
                addList.Unit = dao.GetUnit(SelectedObject.IDUnit);
                addList.Count = Count;
                addList.OutputPrice = OutputPrice;
                addList.Total = OutputPrice * Count;
                addList.Status = Status;
                ListOutputInfo.Add(addList);

            });

            EditCommandOutputInfo = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSourceInfo == null)
                {
                    return false;
                }

                return true;
            },
            (p) =>
            {
                //Edit data
                var editData = dao.GetByID(SelectedItemSourceInfo.ID);
                var result = dao.EditData(editData, SelectedObject.ID, SelectedItemSource.ID,SelectedCustomer.ID, Count, OutputPrice, Total, Status);

                //EDIT List
                var res = ListOutputInfo.FirstOrDefault(x => x.ID == SelectedItemSourceInfo.ID);
                if (res != null)
                {
                    SelectedItemSourceInfo.Object = SelectedObject;
                    SelectedItemSourceInfo.Output = SelectedItemSource;
                    SelectedItemSourceInfo.Customer = SelectedCustomer;
                    SelectedItemSourceInfo.Unit = dao.GetUnit(SelectedObject.IDUnit);
                    SelectedItemSourceInfo.Count = Count;
                    SelectedItemSourceInfo.OutputPrice = OutputPrice;
                    SelectedItemSourceInfo.Status = Status;
                    SelectedItemSourceInfo.Total = Total;
                }
            });

            DeleteCommandOutputInfo = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                //Delete Data
                var deleteOutputInfo = dao.GetByID(SelectedItemSourceInfo.ID);
                if (deleteOutputInfo != null)
                {
                    var result = dao.Delete(deleteOutputInfo);
                    ListOutputInfo.Remove(SelectedItemSourceInfo);
                }
            });
            #endregion
        }
    }
}
