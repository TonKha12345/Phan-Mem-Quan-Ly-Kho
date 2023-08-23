using Models.Common;
using Models.DataProvider;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class AddUserViewModel: BaseViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private string _DisplayName;
        public string DisplayName { get { return _DisplayName; } set { _DisplayName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }

        private string _RePassword;
        public string RePassword { get { return _RePassword; } set { _RePassword = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _Role;
        public ObservableCollection<string> Role { get { return _Role; } set { _Role = value; OnPropertyChanged(); } }

        private string _SelectedRole;
        public string SelectedRole { get { return _SelectedRole; } set { _SelectedRole = value; OnPropertyChanged(); } }

        public ICommand PasswordCommand { get; set; }
        public ICommand RePasswordCommand { get; set; }
        public ICommand AddCommand { get; set; }
        public ICommand CloseCommand { get; set; }

        public AddUserViewModel()
        {
            var userdao = new UserDao();
            Role = userdao.GetListRoles();

            PasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });

            RePasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                RePassword = p.Password;
            });

            AddCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(DisplayName) || string.IsNullOrEmpty(Password) 
                || string.IsNullOrEmpty(RePassword) || string.IsNullOrEmpty(SelectedRole) 
                || string.IsNullOrEmpty(UserName))
                {
                    return false;
                }
                var result = userdao.GetByUserName(UserName);
                if (result)
                {
                    return false;
                }
                if(Password != RePassword) return false;
                return true;
            },
            (p) =>
            {
                var addUser = new User();
                addUser.UserName = UserName;
                addUser.DisplayName = DisplayName;
                addUser.Password = userdao.MD5Hash(Password);
                addUser.IDRole = userdao.GetRoleByDisplayName(SelectedRole).ID;

                var result = userdao.Insert(addUser);
                p.Close();
            });

            CloseCommand = new RelayCommand<Window>((p) =>{return true;},(p) =>
            {
                p.Close();
            });
        }
    }
}
