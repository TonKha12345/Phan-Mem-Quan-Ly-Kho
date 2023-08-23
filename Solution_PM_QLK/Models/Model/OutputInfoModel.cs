﻿using Models.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Models.Model
{
    public class OutputInfoModel: BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private Objects _Object;
        public Objects Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }

        private Unit _Unit;
        public Unit Unit { get { return _Unit; } set { _Unit = value; OnPropertyChanged(); } }

        private Output _Output;
        public Output Output { get { return _Output; } set { _Output = value; OnPropertyChanged(); } }

        private Customer _Customer;
        public Customer Customer { get { return _Customer; } set { _Customer = value; OnPropertyChanged(); } }

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
