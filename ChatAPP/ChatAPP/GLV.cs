using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatAPP
{
    public static class GLV
    {
     
        //login: 
        //نام کاربری اکانت وارد شده 
        public static string username { get; set; }
        //رمز ورود اکانت وارد شده 
        public static string password { get; set; }
        //ایدی اکانت وارد شده 
        public static int ID { get; set; }

        //برای تایید از درست انجام شدن login 
        public static int inputOK = 0;

        
    }
}
