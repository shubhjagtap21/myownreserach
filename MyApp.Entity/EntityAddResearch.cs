using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Entity
{
    public class EntityAddResearch
    {
        public int resCount { get; set; }
        public int shareCount { get; set; }
        public string userName { get; set; }
        public string userId { get; set; }
        public int status { get; set; }
        public int shareStatus { get; set; }
        public string strResId { get; set; }
        [DisplayName("Shared By:")]
        [Required(ErrorMessage = "Please Enter First Name")]
        public string strFirstName { get; set; }
        [Required(ErrorMessage = "Please Enter Last Name")]
        public string strLastName { get; set; }
        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter valid Email")]
        public string strTitleEmail { get; set; }
        public string strPersonlkdnURL { get; set; }
        public string strCompanyWebsite { get; set; }
        [Required(ErrorMessage = "Please Enter Phone Number")]
        public string strCorporatePn { get; set; }
        public string strEmployee { get; set; }
        [Required(ErrorMessage = "Please Enter Industry")]
        public string strIndustry { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public int intCountryId { get; set; }
        [Required(ErrorMessage = "Please Enter State")]
        public int intStateId { get; set; }
        [Required(ErrorMessage = "Please Enter City")]
        public int intCityId { get; set; }
        public string strCountryName { get; set; }
        public string strStateName { get; set; }
        public string strCityName { get; set; }
        public string strCompanyAddress { get; set; }
        public string strCompanyURL { get; set; }
        public string strPrivateNote { get; set; }
        public string fileUpload { get; set; }
        public DateTime showDate { get; set;}
    }
}
