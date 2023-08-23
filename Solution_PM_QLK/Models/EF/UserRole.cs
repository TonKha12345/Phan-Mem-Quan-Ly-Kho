namespace Models.EF
{
    using Models.Common;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserRole")]
    public partial class UserRole: BaseViewModel
    {
        private int _ID;
        public int ID { get { return _ID; } set { _ID = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }
    }
}
