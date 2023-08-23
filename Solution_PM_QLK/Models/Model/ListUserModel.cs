using Models.Common;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM_QLK.Model
{
    public class ListUserModel: BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private string _Role;
        public string Role { get { return _Role; } set { _Role = value; OnPropertyChanged(); } }
    }
}
