using Models.DataProvider;
using Models.EF;
using Models.Model;
using PM_QLK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class InputViewModel : BaseViewModel
    {
        #region Input
        private ObservableCollection<Input> _ListInput;
        public ObservableCollection<Input> ListInput { get { return _ListInput; } set { _ListInput = value; OnPropertyChanged(); } }

        private string _DisplayNameInput;
        public string DisplayNameInput { get { return _DisplayNameInput; } set { _DisplayNameInput = value; OnPropertyChanged(); } }

        private DateTime? _DateInput;
        public DateTime? DateInput { get { return _DateInput; } set { _DateInput = value; OnPropertyChanged(); } }

        private Input _SelectedItemSource;
        public Input SelectedItemSource
        {
            get { return _SelectedItemSource; }
            set
            {
                _SelectedItemSource = value; OnPropertyChanged();
                if (SelectedItemSource != null)
                {
                    DisplayNameInput = SelectedItemSource.DisplayName;
                    DateInput = SelectedItemSource.DateInput;

                    //Get list inputInfo
                    var daoInputInfo = new InputInfoDao();
                    ListInputInfo = daoInputInfo.InputInfoModels(SelectedItemSource.ID);
                }
            }
        }

        public ICommand AddCommandInput { get; set; }
        public ICommand EditCommandInput { get; set; }
        public ICommand DeleteCommandInput { get; set; }
        #endregion



        #region InputInfo
        private ObservableCollection<InputInfoModel> _ListInputInfo;
        public ObservableCollection<InputInfoModel> ListInputInfo { get { return _ListInputInfo; } set { _ListInputInfo = value; OnPropertyChanged(); } }

        private Objects _SelectedObject;
        public Objects SelectedObject { get { return _SelectedObject; } set { _SelectedObject = value; OnPropertyChanged(); } }

        private InputInfoModel _SelectedItemSourceInfo;
        public InputInfoModel SelectedItemSourceInfo 
        { 
            get { return _SelectedItemSourceInfo; } 
            set 
            { 
                _SelectedItemSourceInfo = value; OnPropertyChanged(); 
                if(SelectedItemSourceInfo != null)
                {
                    Count = SelectedItemSourceInfo.Count;
                    InputPrice = SelectedItemSourceInfo.InputPrice;
                    Status = SelectedItemSourceInfo.Status;
                    Total = SelectedItemSourceInfo.Total;
                    SelectedObject = SelectedItemSourceInfo.Object;
                }
            }
        }

        private ObservableCollection<Objects> _ListObject;
        public ObservableCollection<Objects> ListObject { get { return _ListObject; } set { _ListObject = value; OnPropertyChanged(); } }

        private double _Count;
        public double Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }

        private double _InputPrice;
        public double InputPrice { get { return _InputPrice; } set { _InputPrice = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }

        private double _Total;
        public double Total { get { return _Total; } set { _Total = value; OnPropertyChanged(); } }

        public ICommand AddCommandInputInfo { get; set; }
        public ICommand EditCommandInputInfo { get; set; }
        public ICommand DeleteCommandInputInfo { get; set; }
        #endregion

        public InputViewModel()
        {
            #region Input
            //Input 
            var daoInput = new InputDao();
            var dao = new InputInfoDao();
            ListInput = daoInput.GetListAll();

            AddCommandInput = new RelayCommand<object>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayNameInput))
                {
                    return false;
                }
                var result = daoInput.GetByDisplayName(DisplayNameInput);
                if (result != null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var addInput = new Input();
                addInput.DisplayName = DisplayNameInput;
                addInput.DateInput = DateInput;

                var result = daoInput.Insert(addInput);
                ListInput.Add(addInput);
            });

            EditCommandInput = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var editInput = daoInput.GetByID(SelectedItemSource.ID);
                if (editInput != null)
                {
                    var result = daoInput.Edit(editInput, DisplayNameInput, DateInput);
                    if (result)
                    {
                        SelectedItemSource.DisplayName = DisplayNameInput;
                        SelectedItemSource.DateInput = DateInput;
                    }
                }
            });

            DeleteCommandInput = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteInput = daoInput.GetByID(SelectedItemSource.ID);
                if (deleteInput != null)
                {
                    //Delete Data
                    var result = daoInput.Delete(deleteInput);
                    var relateInputInfo = dao.GetListByIDInput(SelectedItemSource.ID);
                    dao.DeleteInfo(relateInputInfo);

                    //Delete List
                    ListInput.Remove(deleteInput);

                    var listInputInfo = ListInputInfo.Where(x => x.Input.ID == deleteInput.ID).ToList();
                    foreach(var item in listInputInfo)
                    {
                        ListInputInfo.Remove(item);
                    }
                }
            });
            #endregion





            #region Input Info
            //Input Info
            ListObject = dao.GetListObjects();
            AddCommandInputInfo = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null || SelectedObject == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                // add data
                var addInputInfo = new InputInfo();
                addInputInfo.STT = dao.GetSTT();
                addInputInfo.IDObject = SelectedObject.ID;
                addInputInfo.IDInput = SelectedItemSource.ID;
                addInputInfo.Count = Count;
                addInputInfo.InputPrice = InputPrice;
                addInputInfo.Status = Status;
                addInputInfo.Total = InputPrice * Count;
                var result = dao.Insert(addInputInfo);

                //add List
                var addList = new InputInfoModel();
                addList.STT = ListInputInfo.Count() + 1;
                addList.Object = SelectedObject;
                addList.Input = SelectedItemSource;
                addList.Suplier = dao.GetSuplier(SelectedObject.IDSuplier);
                addList.Unit = dao.GetUnit(SelectedObject.IDUnit);
                addList.Count = Count;
                addList.InputPrice = InputPrice;
                addList.Total = InputPrice * Count;
                addList.Status = Status;
                ListInputInfo.Add(addList);
            });

            EditCommandInputInfo = new RelayCommand<object>((p) =>
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
                var result = dao.EditData(editData, SelectedObject.ID,SelectedItemSource.ID, Count, InputPrice, Total, Status);

                //Edit List
                var res = ListInputInfo.FirstOrDefault(x => x.ID == SelectedItemSourceInfo.ID);
                if(res != null)
                {
                    SelectedItemSourceInfo.Object = SelectedObject;
                    SelectedItemSourceInfo.Input = SelectedItemSource;
                    SelectedItemSourceInfo.Suplier = dao.GetSuplier(SelectedObject.IDSuplier);
                    SelectedItemSourceInfo.Unit = dao.GetUnit(SelectedObject.IDUnit);
                    SelectedItemSourceInfo.Count = Count;
                    SelectedItemSourceInfo.InputPrice = InputPrice;
                    SelectedItemSourceInfo.Status = Status;
                    SelectedItemSourceInfo.Total = Total;
                }
            });

            DeleteCommandInputInfo = new RelayCommand<object>((p) =>
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
                var deleteInputInfo = dao.GetByID(SelectedItemSourceInfo.ID);
                if (deleteInputInfo != null)
                {
                    var result = dao.Delete(deleteInputInfo);
                    ListInputInfo.Remove(SelectedItemSourceInfo);
                }
            });
            #endregion
        }
    }
}
