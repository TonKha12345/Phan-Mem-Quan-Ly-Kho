using Models.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class ObjectsModel: BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private Unit _Unit;
        public Unit Unit { get { return _Unit; } set { _Unit = value; OnPropertyChanged(); } }

        private Suplier _Suplier;
        public Suplier Suplier { get { return _Suplier; } set { _Suplier = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get { return _QRCode; } set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get { return _BarCode; } set { _BarCode = value; OnPropertyChanged(); } }
    }
}
