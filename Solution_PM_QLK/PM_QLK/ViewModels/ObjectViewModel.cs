using Models.DataProvider;
using Models.EF;
using Models.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class ObjectViewModel : BaseViewModel
    {
        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private ObservableCollection<Unit> _Unit;
        public ObservableCollection<Unit> Unit { get { return _Unit; } set { _Unit = value; OnPropertyChanged(); } }

        private Unit _SelectedUnit;
        public Unit SelectedUnit { get { return _SelectedUnit; } set { _SelectedUnit = value; OnPropertyChanged(); } }

        private ObservableCollection<ObjectsModel> _ListObject;
        public ObservableCollection<ObjectsModel> ListObject { get { return _ListObject; } set { _ListObject = value; OnPropertyChanged(); } }

        private ObjectsModel _SelectedItemSource;
        public ObjectsModel SelectedItemSource
        {
            get { return _SelectedItemSource; }
            set
            {
                _SelectedItemSource = value; OnPropertyChanged();
                if (SelectedItemSource != null)
                {
                    DisplayName = SelectedItemSource.DisplayName;
                    QRCode = SelectedItemSource.QRCode;
                    BarCode = SelectedItemSource.BarCode;
                    SelectedUnit = SelectedItemSource.Unit;
                    SelectedSuplier = SelectedItemSource.Suplier;
                }
            }
        }

        private ObservableCollection<Suplier> _Suplier;
        public ObservableCollection<Suplier> Suplier { get { return _Suplier; } set { _Suplier = value; OnPropertyChanged(); } }

        private Suplier _SelectedSuplier;
        public Suplier SelectedSuplier { get { return _SelectedSuplier; } set { _SelectedSuplier = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get { return _QRCode; } set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get { return _BarCode; } set { _BarCode = value; OnPropertyChanged(); } }


        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ObjectViewModel()
        {
            var dao = new ObjectDao();
            ListObject = dao.ObjectModels();
            Unit = new UnitDao().GetListAll();
            Suplier = new SuplierDao().GetListAll();

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
                var addObject = new Objects();
                addObject.DisplayName = DisplayName;
                addObject.IDSuplier = SelectedSuplier.ID;
                addObject.IDUnit = SelectedUnit.ID;
                addObject.BarCode = BarCode;
                addObject.QRCode = QRCode;
                addObject.STT = dao.GetSTT();
                var result = dao.Insert(addObject);

                var addList = new ObjectsModel();
                addList.DisplayName = DisplayName;
                addList.Suplier = SelectedSuplier;
                addList.Unit = SelectedUnit;
                addList.BarCode = BarCode;
                addList.QRCode = QRCode;
                addList.STT = addObject.STT;
                ListObject.Add(addList);
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
                var editObject = dao.GetByID(SelectedItemSource.ID);
                if (editObject != null)
                {
                    var result = dao.Edit(editObject, DisplayName, SelectedSuplier.ID, SelectedUnit.ID, BarCode, QRCode);
                    if (result)
                    {
                        SelectedItemSource.DisplayName = DisplayName;
                        SelectedItemSource.Suplier = SelectedSuplier;
                        SelectedItemSource.Unit = SelectedUnit;
                        SelectedItemSource.BarCode = BarCode;
                        SelectedItemSource.QRCode = QRCode;
                    }
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteObjects = dao.GetByID(SelectedItemSource.ID);
                if (deleteObjects != null)
                {
                    var result = dao.Delete(deleteObjects);
                    if (result)
                    {
                        ListObject.Remove(SelectedItemSource);
                    }
                }
            });
        }
    }
}
