using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using ChatAPP.DataBase.Entity;
using ChatAPP.DataBase.MyDBcontext;
using Microsoft.EntityFrameworkCore;

namespace ChatAPP
{
    public class RulesCode
    {
        //برای تکراری نبودن نام کاربری 
        public bool IsUsernameExists(string username)
        {
            using var dbContext = new myDbcontext();
            return dbContext.UserAccs.Any(u => u.NameAcc == username);
        }
        // برای اضافه کردن کاربر : 
        public void AdduserSignUpAcc(string userName , string password)
        {
            if (userName != null && userName != " " && password != null && password != " ")
            {
                if (IsUsernameExists(userName))
                {
                    MessageBox.Show("This username has already been entered", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {

                   
                    using (var context = new myDbcontext())
                    {
                        var newUser = new UserAcc()
                        {
                            NameAcc = userName,
                            Password = password
                        };

                        context.UserAccs.Add(newUser);
                        context.SaveChanges();

                        MessageBox.Show("Registration complete.");
                    }
                  
                }
            }
            else
            {
                MessageBox.Show("The entered inputs cannot be empty.", "Error", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }


        //برای وارد شدن به اکانت : 
        public void LoginAcc(string username, string password)
        {
            using (var db = new myDbcontext())
            {
                var login = db.UserAccs.FirstOrDefault(u => u.NameAcc == username && u.Password == password);
                if (login != null)
                {
                    MainAPP main = new MainAPP();
                   
                    MessageBox.Show("You have successfully logged in", "information", MessageBoxButton.OK, MessageBoxImage.Information);
                    
                    main.Show();
                    GLV.ID = login.Id;
                    GLV.username = login.NameAcc;
                    GLV.password = login.Password;
                    GLV.inputOK = 1;
                }
                else
                {
                    MessageBox.Show("The information is wrong (please register if you don't have an account)", "information", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        public void SettingCode(string HexCode)
        {
            if (IsValidHexCode(HexCode))
            {
                using (var db = new myDbcontext())
                {
                    db.UserSettings.RemoveRange(db.UserSettings);
                    var newCode = new UserSetting()
                    {
                        CodeHEX = HexCode
                    };
                    db.UserSettings.Add(newCode);
                    db.SaveChanges();
                    MessageBox.Show("با موفقیت رنگ تغییر کرد");
                }
            }
            else
            {
                MessageBox.Show("کد وارد شده نامعتبر است یا باکس خالی است ", "خطا", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool IsValidHexCode(string hexCode)
        {
            
            string pattern = "^#([0-9A-Fa-f]{3}|[0-9A-Fa-f]{6})$";

            
            return Regex.IsMatch(hexCode, pattern);
        }

    }
}
