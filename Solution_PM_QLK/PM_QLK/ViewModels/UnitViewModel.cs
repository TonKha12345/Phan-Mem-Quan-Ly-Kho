using Models.Common;
using Models.DataProvider;
using Models.EF;
using PM_QLK.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class UnitViewModel: BaseViewModel
    {
        #region Property
        private ObservableCollection<Unit> _ListUnit;
        public ObservableCollection<Unit> ListUnit { get { return _ListUnit; } set { _ListUnit = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }
        #endregion


        private Unit _SelectedItemSource;
        public Unit SelectedItemSource { get { return _SelectedItemSource; } 
            set 
            { 
                _SelectedItemSource = value; OnPropertyChanged(); 
                if(SelectedItemSource != null)
                {
                    DisplayName = SelectedItemSource.DisplayName;
                }
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public UnitViewModel()
        {
            var dao = new UnitDao();
            #region Function

            //Get List Unit
            #region Get List Unit
            ListUnit = dao.GetListAll();
            #endregion

            AddCommand = new RelayCommand<object>((p) => 
            { 
                if(string.IsNullOrEmpty(DisplayName))
                {
                    return false;
                }
                var result = dao.GetByDisplayName(DisplayName);
                if(result != null)
                {
                    return false;
                }
                return true;
            }, 
            (p) =>
            {
                var addUnit = new Unit();
                addUnit.DisplayName = DisplayName;
                addUnit.STT = dao.GetSTT();
                var result = dao.Insert(addUnit);
                ListUnit.Add(addUnit);
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null || SelectedItemSource.DisplayName == DisplayName)
                {
                    return false;
                }
                var result = dao.GetByDisplayName(DisplayName);
                if(result != null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var editUnit = dao.GetByID(SelectedItemSource.ID);
                if(editUnit != null)
                {
                    var result = dao.Edit(editUnit, DisplayName);
                    if (result)
                    {
                        SelectedItemSource.DisplayName = DisplayName;
                    }
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                var result = dao.GetByDisplayName(DisplayName);
                if (result == null)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteUnit = dao.GetByID(SelectedItemSource.ID);
                if (deleteUnit != null)
                {
                    var result = dao.Delete(deleteUnit);
                    ListUnit.Remove(deleteUnit);
                }
            });

            #endregion
        }

    }
}
