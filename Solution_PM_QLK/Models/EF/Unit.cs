namespace Models.EF
{
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Unit")]
    public partial class Unit: BaseViewModel 
    {
        public int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; OnPropertyChanged(); }
        }

        private int _STT;
        public int STT
        {
            get { return _STT; }
            set { _STT = value; OnPropertyChanged(); }
        }

        [StringLength(100)]
        public string _DisplayName;
        public string DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; OnPropertyChanged(); }
        }
        
    }
}
