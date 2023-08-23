using Models.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Model
{
    public class TonKhoModel: BaseViewModel
    {
        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private Objects _Object;
        public Objects Object { get { return _Object; } set { _Object = value; OnPropertyChanged(); } }

        private double _Count;
        public double Count { get { return _Count; } set { _Count = value; OnPropertyChanged(); } }

        private Unit _Unit;
        public Unit Unit { get { return _Unit; } set { _Unit = value; OnPropertyChanged(); } }
    }
}
