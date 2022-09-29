using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyApp.Entity
{
    public class EntitySignUp
    {
        [Required]
        public int userId { get; set; }
        [Required(ErrorMessage = "Please Enter Name")]
        [RegularExpression("^([a-zA-Z .&'-]+)$", ErrorMessage = "Enter Name in proper format")]
        public string name { get; set; }
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid Email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string password { get; set; }
        [Required(ErrorMessage = "Please Enter Confirm Password")]
        [Compare("password", ErrorMessage = "Password and Confirm Password does not matched")]
        public string cPassword { get; set; }
        public string strLastName { get; set; }
        public string gender { get; set; }
        public string strPhoneNumber { get; set; }
        public string strAddress { get; set; }
    }
    public class forgotModel
    {
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                            @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                            @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                            ErrorMessage = "Email is not valid")]
        public string forEmail { get; set; }
    }
    public class verifyMail
    {
        public string verifyEmail { get; set; }
    }
}
