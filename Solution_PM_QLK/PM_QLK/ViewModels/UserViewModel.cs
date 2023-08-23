using Models.Common;
using Models.DataProvider;
using Models.EF;
using PM_QLK.Model;
using PM_QLK.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class UserViewModel: BaseViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _Role;
        public ObservableCollection<string> Role { get { return _Role; } set { _Role = value; OnPropertyChanged(); } }

        private string _SelectedRole;
        public string SelectedRole { get { return _SelectedRole; } set { _SelectedRole = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private ObservableCollection<ListUserModel> _ListUser;
        public ObservableCollection<ListUserModel> ListUser { get { return _ListUser; } set { _ListUser = value; OnPropertyChanged(); } }

        private ListUserModel _SelectedItemSource;
        public ListUserModel SelectedItemSource 
        { 
            get { return _SelectedItemSource; } 
            set 
            { 
                _SelectedItemSource = value; OnPropertyChanged(); 
                if(SelectedItemSource != null)
                {
                    UserName = SelectedItemSource.UserName;
                    SelectedRole = SelectedItemSource.Role;
                    DisplayName = SelectedItemSource.DisplayName;
                }
            } 
        }

        private int _STT;
        public int STT { get { return _STT; } set { _STT = value; OnPropertyChanged(); } }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }

        public UserViewModel()
        {
            var userdao = new UserDao();
            Role = userdao.GetListRoles();
            ListUser = userdao.ListUser();
            int stt = 1;
            
            foreach(var item in ListUser)
            {
                item.STT = stt;
                stt++;
            }
            //Get List User
            AddCommand = new RelayCommand<object>((p) => 
            {
                var checkUser = userdao.checkAdmin(UserHelper.Role);
                if(checkUser == false)
                {
                    return false;
                }
                return true; 
            }, 
            (p) =>
            {
                var window = new AddUserWindow();
                window.ShowDialog();
            });

            EditCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }

                var checkUser = userdao.checkAdmin(UserHelper.Role);
                if (checkUser == false)
                {
                    return false;
                }

                return true;
            },
            (p) =>
            {
                //Edit data
                var editUser = userdao.GetUserByUserName(SelectedItemSource.UserName);
                var IDRole = userdao.GetIDRoleByUserName(SelectedItemSource.UserName);
                var result = userdao.Edit(editUser, UserName, DisplayName, IDRole);

                //EDIT List
                var res = ListUser.FirstOrDefault(x => x.UserName == SelectedItemSource.UserName);
                if (res != null)
                {
                    SelectedItemSource.UserName = UserName;
                    SelectedItemSource.DisplayName = DisplayName;
                    SelectedItemSource.Role = SelectedRole;
                }
            });

            DeleteCommand = new RelayCommand<object>((p) =>
            {
                if (SelectedItemSource == null)
                {
                    return false;
                }
                var checkUser = userdao.checkAdmin(UserHelper.Role);
                if (checkUser == false)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                var deleteUser = userdao.GetUserByUserName(SelectedItemSource.UserName);
                if (deleteUser != null)
                {
                    //Delete Data
                    var result = userdao.Delete(deleteUser);

                    //Delete List
                    ListUser.Remove(SelectedItemSource);
                }
            });

            ChangePasswordCommand = new RelayCommand<object>((p) => { return true; }, (p) =>
            {
                var window = new ChangePasswordWindow();
                window.ShowDialog();
            });
        }
    }
}
