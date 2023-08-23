using Models.DataProvider;
using Models.EF;
using Models.Model;
using PM_QLK.Model;
using PM_QLK.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Common
        public bool isLoaded { get; set; } = false;
        public ICommand LoadedWindownCommand { get; set; }
        public ICommand InputCommand { get; set; }
        public ICommand OutputCommand { get; set; }
        public ICommand ObjectCommand { get; set; }
        public ICommand UnitCommand { get; set; }
        public ICommand SupplierCommand { get; set; }
        public ICommand CustomerCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        #endregion

        #region Filter
        //Input Filter
        #region Function
        private ObservableCollection<TonKhoModel> _LuongNhap;
        public ObservableCollection<TonKhoModel> LuongNhap
        {
            get { return _LuongNhap; }
            set
            {
                _LuongNhap = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TonKhoModel> _LuongXuat;
        public ObservableCollection<TonKhoModel> LuongXuat
        {
            get { return _LuongXuat; }
            set
            {
                _LuongXuat = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<TonKhoModel> _TonKho;
        public ObservableCollection<TonKhoModel> TonKho
        {
            get { return _TonKho; }
            set
            {
                _TonKho = value;
                OnPropertyChanged();
            }
        }

        private DateTime? _StartDate;
        public DateTime? StartDate
        {
            get { return _StartDate; }
            set { _StartDate = value; OnPropertyChanged(); }
        }

        private DateTime? _EndDate;
        public DateTime? EndDate
        {
            get { return _EndDate; }
            set { _EndDate = value; OnPropertyChanged(); }
        }
        #endregion

        private ObservableCollection<TonKhoModel> _ListTonKhoMain;
        public ObservableCollection<TonKhoModel> ListTonKhoMain
        {
            get { return _ListTonKhoMain; }
            set
            {
                _ListTonKhoMain = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            #region Common
            LoadedWindownCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                if (!isLoaded)
                {
                    isLoaded = true;
                    p.Hide();
                    var loginWindow = new LoginWindow();
                    loginWindow.ShowDialog();

                    var isLogin = (LoginViewModel)loginWindow.DataContext;
                    if (isLogin.IsLogin)
                    {
                        p.Show();
                    }
                    else
                    {
                        p.Hide();
                    }
                }
            });
            InputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new InputWindow();
                window.ShowDialog();
            });
            OutputCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new OutputWindow();
                window.ShowDialog();
            });
            ObjectCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new ObjectWindow();
                window.ShowDialog();
            });
            UnitCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new UnitWindow();
                window.ShowDialog();
            });
            SupplierCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new SuplierWindow();
                window.ShowDialog();
            });
            CustomerCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new CustomerWindow();
                window.ShowDialog();
            });
            UserCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new UserWindow();
                window.ShowDialog();
            });
            FilterCommand = new RelayCommand<object>((p) =>
            {
                if (StartDate == null || EndDate == null) return false;
                return true;
            }, (p) => { Filter(); });
            #endregion


            #region Function

            //List Ton Kho main
            #region List Ton Kho Main
            ListTonKhoMain = new ObservableCollection<TonKhoModel>();
            var objetcList = new ObjectDao().GetListObject();
            int stt = 1;
            if (objetcList != null)
            {
                foreach (var item in objetcList)
                {
                    var inputList = new InputInfoDao().GetByIDObject(item.ID);
                    var outputList = new OutputInfoDao().GetByIDObject(item.ID);
                    double sumInput = 0;
                    double sumOutput = 0;
                    if (inputList != null)
                    {
                        sumInput = inputList.Sum(x => x.Count);
                    }
                    if (outputList != null)
                    {
                        sumOutput = outputList.Sum(x => x.Count);
                    }

                    var tonkho = new TonKhoModel();
                    tonkho.STT = stt;
                    tonkho.Object = item;
                    tonkho.Count = sumInput - sumOutput;
                    tonkho.Unit = new UnitDao().GetByID(item.IDUnit);
                    if(tonkho.Count > 0 ) ListTonKhoMain.Add(tonkho);
                    stt++;
                }
            }
            else
            {
                MessageBox.Show("Không có danh sách vật tư");
            }
            #endregion

            void Filter()
            {
                //Contruction
                var objectDao = new ObjectDao();
                var inputInfoDao = new InputInfoDao();
                var outputInfoDao = new OutputInfoDao();

                LuongNhap = new ObservableCollection<TonKhoModel>();
                LuongXuat = new ObservableCollection<TonKhoModel>();
                TonKho = new ObservableCollection<TonKhoModel>();

                var inputInfo = inputInfoDao.InputInfoModels();
                var outputInfo = outputInfoDao.OutputInfoModels();

                var objectList = objectDao.GetListObject();
                if(objectList.Count() > 0)
                {
                    foreach(var item in objectList)
                    {
                        var inputListBefore = inputInfo.Where(x => x.Object.ID == item.ID && x.Input.DateInput >= StartDate && x.Input.DateInput <= EndDate);
                        var outputListBefore = outputInfo.Where(x => x.Object.ID == item.ID && x.Output.DateOutput >= StartDate && x.Output.DateOutput <= EndDate);

                        double sumInput = 0;
                        double sumOutput = 0;

                        if(inputListBefore != null && inputListBefore.Count() > 0)
                        {
                            TonKhoModel luongNhap = new TonKhoModel();
                            luongNhap.Object = item;
                            luongNhap.Unit = objectDao.GetUnitByIDObject(item.ID);
                            sumInput = luongNhap.Count = inputListBefore.Sum(x => x.Count);
                            LuongNhap.Add(luongNhap);
                        }

                        if (outputListBefore != null && outputListBefore.Count() > 0)
                        {
                            TonKhoModel luongXuat = new TonKhoModel();
                            luongXuat.Object = item;
                            luongXuat.Unit = objectDao.GetUnitByIDObject(item.ID);
                            sumOutput = luongXuat.Count = outputListBefore.Sum(x => x.Count);
                            LuongXuat.Add(luongXuat);
                        }

                        TonKhoModel tonkho = new TonKhoModel();
                        tonkho.Object = item;
                        tonkho.Unit = objectDao.GetUnitByIDObject(item.ID);
                        tonkho.Count = sumInput - sumOutput;
                        if(tonkho.Count > 0 ) TonKho.Add(tonkho);
                    }
                }
            }
            #endregion
        }
    }
}
#endregion

