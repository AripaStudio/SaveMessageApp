using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatAPP.DataBase.Entity;
using Microsoft.EntityFrameworkCore;

namespace ChatAPP.DataBase.MyDBcontext
{
    class myDbcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=.\DB\ChatappDB.db;");
        }

        public DbSet<UserAcc> UserAccs { get; set; }

        public DbSet<UserMessage> UserMessages { get; set; }

        public DbSet<UserSetting> UserSettings
        {
            get;
            set;
        }
    }
}
