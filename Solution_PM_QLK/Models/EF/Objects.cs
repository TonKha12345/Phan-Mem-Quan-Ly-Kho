namespace Models.EF
{
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Objects: BaseViewModel
    {

        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private int _IDUnit;
        public int IDUnit { get { return _IDUnit; } set { _IDUnit = value; OnPropertyChanged(); } }

        private int _IDSuplier;
        public int IDSuplier { get { return _IDSuplier; } set { _IDSuplier = value; OnPropertyChanged(); } }

        private string _QRCode;
        public string QRCode { get { return _QRCode; } set { _QRCode = value; OnPropertyChanged(); } }

        private string _BarCode;
        public string BarCode { get { return _BarCode; } set { _BarCode = value; OnPropertyChanged(); } }
    }
}
