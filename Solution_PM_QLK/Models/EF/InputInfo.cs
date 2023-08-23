namespace Models.EF
{
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InputInfo")]
    public partial class InputInfo: BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private int _IDObject;
        public int IDObject { get { return _IDObject; } set { _IDObject = value; OnPropertyChanged(); } }

        private int _IDInput;
        public int IDInput { get { return _IDInput; } set { _IDInput = value; OnPropertyChanged(); } }

        private double _Count;
        public double Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }

        [Column(TypeName = "money")]
        private double _InputPrice;
        public double InputPrice { get { return _InputPrice; } set { _InputPrice = value; OnPropertyChanged(); } }

        [Column(TypeName = "money")]
        private double _Total;
        public double Total { get { return _Total; } set { _Total = value; OnPropertyChanged(); } }

        private string _Status;
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged(); } }
    }
}
