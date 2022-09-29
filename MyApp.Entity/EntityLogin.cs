using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Entity
{
    public class EntityLogin
    {
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid Email")]
        public string strEmail { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string strPassword { get; set; }

        public int userId { get; set; }
        public string name { get; set; }

    }
}
