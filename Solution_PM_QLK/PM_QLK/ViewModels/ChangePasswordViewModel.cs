using Models.DataProvider;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PM_QLK.ViewModels
{
    public class ChangePasswordViewModel: BaseViewModel
    {
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }

        private string _NewPassword;
        public string NewPassword { get { return _NewPassword; } set { _NewPassword = value; OnPropertyChanged(); } }

        public ICommand PasswordCommand { get; set; }
        public ICommand NewPasswordCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public ChangePasswordViewModel()
        {
            var userdao = new UserDao();    
            PasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });

            NewPasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                NewPassword = p.Password;
            });

            EditCommand = new RelayCommand<Window>((p) =>
            {
                if (string.IsNullOrEmpty(UserName) || string.IsNullOrEmpty(Password)
                || string.IsNullOrEmpty(NewPassword))
                {
                    return false;
                }
                var user = userdao.CheckChangePassword(UserName, Password);
                if (user == null)
                {
                    return false;
                }
                if (Password == NewPassword)
                {
                    return false;
                }
                return true;
            },
            (p) =>
            {
                userdao.ChangePassword(UserName, Password, NewPassword);
                p.Close();
            });

            CloseCommand = new RelayCommand<Window>((p) =>
            {
                return true;
            },
            (p) =>
            {
                p.Close();
            });
        }
    }
}
