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
        public string strResId { get; set; }
        [DisplayName("Shared By:")]
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strTitleEmail { get; set; }
        public string strPersonlkdnURL { get; set; }
        public string strCompanyWebsite { get; set; }
        public string strCorporatePn { get; set; }
        public string strEmployee { get; set; }
        public string strIndustry { get; set; }
        public int intCountryId { get; set; }
        public int intStateId { get; set; }
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
