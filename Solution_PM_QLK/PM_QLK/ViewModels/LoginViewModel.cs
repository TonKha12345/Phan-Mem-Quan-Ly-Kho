using Models.Common;
using Models.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PM_QLK.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _Username;
        public string UserName { get { return _Username; } set { _Username = value; OnPropertyChanged(); } }

        private string _Password;
        public string Password { get { return _Password; } set { _Password = value; OnPropertyChanged(); } }

        public int IDRole { get; set; }

        public bool IsLogin { get; set; }

        public ICommand LoginCommand { get; set; }
        public ICommand CloseCommand { get; set; }
        public ICommand PasswordCommand { get; set; }

        public LoginViewModel()
        {
            var userdao = new UserDao();
            PasswordCommand = new RelayCommand<PasswordBox>((p) => { return true; }, (p) =>
            {
                Password = p.Password;
            });

            IsLogin = false;
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) =>
            {
                var result = userdao.Login(UserName, Password);
                if (result == 0)
                {
                    MessageBox.Show("Sai tên đăng nhập !");
                }
                else if (result == -1)
                {
                    MessageBox.Show("Sai mật khẩu !");
                }
                else if (result == -2)
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                }
                else if (result == -3)
                {
                    MessageBox.Show("Vui lòng nhập mật khẩu!");
                }
                else
                {
                    IsLogin = true;
                    UserHelper.Role = userdao.GetIDRoleByUserName(UserName);
                    p.Close();
                }
            });
        }
    }
}
