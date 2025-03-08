using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatAPP.DataBase.Entity
{
    class UserAcc
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string NameAcc { get; set; }

        [Required]
        [MaxLength(30)]
        public string Password { get; set; }

    }
}
