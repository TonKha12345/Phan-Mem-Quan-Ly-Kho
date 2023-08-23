namespace Models.EF
{
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OutputInfo")]
    public partial class OutputInfo : BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private int _IDObject;
        public int IDObject { get { return _IDObject; } set { _IDObject = value; OnPropertyChanged(); } }

        private int _IDOutput;
        public int IDOutput { get { return _IDOutput; } set { _IDOutput = value; OnPropertyChanged(); } }

        private int _IDCustomer;
        public int IDCustomer { get { return _IDCustomer; } set { _IDCustomer = value; OnPropertyChanged(); } }

        private double _Count;
        public double Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }

        [Column(TypeName = "money")]
        private double _OutputPrice;
        public double OutputPrice { get { return _OutputPrice; } set { _OutputPrice = value; OnPropertyChanged(); } }

        [Column(TypeName = "money")]
        private double _Total;
        public double Total { get { return _Total; } set { _Total = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }
    }
}
