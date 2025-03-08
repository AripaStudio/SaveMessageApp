using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAPP.DataBase.Entity
{
    class UserSetting
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(7)]
        public string CodeHEX { get; set; }
    }
}
