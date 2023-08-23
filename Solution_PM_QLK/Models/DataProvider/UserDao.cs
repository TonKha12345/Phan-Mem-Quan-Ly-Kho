using Models.EF;
using PM_QLK.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataProvider
{
    public class UserDao
    {
        private QuanLyKhoDbContext db;

        public UserDao()
        {
            db = new QuanLyKhoDbContext();
        }

        public List<User> GetListUsers()
        {
            return db.Users.ToList();
        }

        public ObservableCollection<string> GetListRoles()
        {
            return new ObservableCollection<string>(db.UserRoles.Select(x => x.DisplayName));
        }

        public double Login(string UserName, string Password)
        {
            if (string.IsNullOrEmpty(UserName))
            {
                return -2;
            }
            if (string.IsNullOrEmpty(Password))
            {
                return -3;
            }
            var checkUserName = db.Users.SingleOrDefault(x => x.UserName == UserName);
            if (checkUserName != null)
            {
                string passwordToMD5 = MD5Hash(Password);
                var checkPassword = db.Users.SingleOrDefault(x => x.Password == passwordToMD5 && x.UserName == UserName);
                if (checkPassword != null)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// String to MD5
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

        public ObservableCollection<ListUserModel> ListUser()
        {
            //var List = new ObservableCollection<ListUserModel>();
            var data = (from a in db.Users
                        join b in db.UserRoles on a.IDRole equals b.ID
                        select new
                        {
                            RoleID = a.ID,
                            RoleDisplayName = a.DisplayName,
                            RoleUserName = a.UserName,
                            Role = b.DisplayName
                        }).AsEnumerable().Select(x => new ListUserModel()
                        {
                            ID = x.RoleID,
                            DisplayName = x.RoleDisplayName,
                            UserName = x.RoleUserName,
                            Role = x.Role
                        });
            return new ObservableCollection<ListUserModel>(data);
        }

        public UserRole GetRoleByID(int id)
        {
            return db.UserRoles.FirstOrDefault(x => x.ID == id);
        }

        public UserRole GetRoleByDisplayName(string displayname)
        {
            return db.UserRoles.FirstOrDefault(x => x.DisplayName == displayname);
        }

        public bool GetByUserName(string username)
        {
            return db.Users.Where(x => x.UserName == username).Count() > 0;
        }

        public User GetUserByUserName(string username)
        {
            return db.Users.FirstOrDefault(x => x.UserName == username);
        }

        public bool Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public bool Edit(User user, string UserName, string DisplayName, int IDRole)
        {
            var editUser = db.Users.FirstOrDefault(x => x.ID == user.ID);
            editUser.UserName = UserName;
            editUser.DisplayName = DisplayName;
            editUser.IDRole = IDRole;
            db.SaveChanges();
            return true;
        }

        public bool Delete(User user)
        {
            db.Users.Remove(user);
            db.SaveChanges();
            return true;
        }

        public bool checkAdmin(int IDRole)
        {
            var res = db.UserRoles.FirstOrDefault(x => x.ID == IDRole);
            if (res.ID == 1)
            {
                return true;
            }
            return false;
        }

        public int GetIDRoleByUserName(string username)
        {
            var i = db.Users.FirstOrDefault(x => x.UserName == username);
            return i.IDRole;
        }

        public User CheckChangePassword(string username, string password)
        {
            var Password = MD5Hash(password);
            var user = db.Users.FirstOrDefault(x => x.UserName == username && x.Password == Password);
            return user;
        }

        public bool ChangePassword(string username, string password, string newpassword)
        {
            var Password = MD5Hash(password);
            var res = db.Users.FirstOrDefault(x => x.UserName == username && x.Password == Password);
            if (res != null)
            {
                res.Password = MD5Hash(newpassword);
                db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
