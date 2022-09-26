
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Web.Mvc;
using MyApp.Entity;
using MyApp.db;
using System.Web;
using System.IO;
using System.Configuration;

namespace LoginControllers
{
    public class LoginController : Controller
    {
        ABState dt = new ABState();

        [HttpGet]
        public ActionResult signUp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signUp(EntitySignUp model)
        {
            try
            {
               
                int result = dt.insertSignup(model);
                if (result>0)
                {
                    TempData["AlertMessage"] = "Registration Sucessful...!!!";
                    return RedirectToAction("login");
                }
                else
                {
                    TempData["AlertMessage"] = "Email Already Registered...!";
                }
                return View();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("signUp");
            }
        }
        [HttpPost]
        public ActionResult verifyEmail(string email)
        {
            int result = dt.VerifyEmailId(email);
            if (result > 0)
            {
                TempData["verify"] = "Verification Successful";
                return RedirectToAction("login");
            }
            else
            {
                Console.WriteLine("Something went Wrong");
                
            }
            return View("verifyEmail");
        }
        public ActionResult addCategories()
        {   
            return View();
        }
        public ActionResult categories()
        {
            return View();
        }
        [HttpPost]
        public JsonResult forgotPass(forgotModel model)
        {
            int result=dt.forPassword(model);
            string mes = null;
            if (result>0)
            {
                mes = "Forgot Password Succesfully";
            }
            return Json(new { pri = mes});
        }
        
        public ActionResult leads()
        {
            return View();
        }
        public ActionResult leadsList()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult dashboard(string keyword)
        //{
        //    ShowDetails(keyword);
        //    Country_Bind();
        //    return View();
        //}

        //public ActionResult ShowDetails(string keyword)
        //{
        //    SqlCommand comm = new SqlCommand("SP_ShowReseach", conn);
        //    comm.CommandType = CommandType.StoredProcedure;
        //    if (keyword==null)
        //    {
        //        keyword="";
        //    }
        //    comm.Parameters.AddWithValue("@Keyword", keyword);
        //    SqlDataAdapter Ad = new SqlDataAdapter(comm);
        //    DataTable dr = new DataTable();
        //    Ad.Fill(dr);
        //    List<EntityAddResearch> lstres = new List<EntityAddResearch>();
        //    if (dr.Rows.Count > 0)
        //    {
        //        foreach (DataRow tv in dr.Rows)
        //        {
        //            lstres.Add(new EntityAddResearch
        //            {
        //                strResId = Convert.ToString(tv["resId"]),
        //                strFirstName = Convert.ToString(tv["firstName"]),
        //                strLastName = Convert.ToString(tv["lastName"]),
        //                strTitleEmail = Convert.ToString(tv["titleEmail"]),
        //                strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
        //                strCompanyAddress = Convert.ToString(tv["companyAddress"]),
        //                strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
        //                strCorporatePn = Convert.ToString(tv["corporatePhone"]),
        //                strEmployee = Convert.ToString(tv["employee"]),
        //                strIndustry = Convert.ToString(tv["industry"]),
        //                strCompanyURL = Convert.ToString(tv["companyURL"]),
        //                strPrivateNote = Convert.ToString(tv["privateNote"]),
        //                showDate = Convert.ToDateTime(tv["createdDate"])
        //            });
        //        }
        //    }
            
        //    return View(lstres);
        //}

        //[HttpPost]
        //public ActionResult dashboard(HttpPostedFileBase fileUpload)
        //{
        //    if (fileUpload.ContentLength > 0)
        //    {
        //        string imageFileName = Path.GetFileName(fileUpload.FileName);

        //        string folderPath = Path.Combine(Server.MapPath("~/UploadedFiles"), imageFileName);

        //        fileUpload.SaveAs(folderPath);
        //    }
        //    return View();
        //}
        //public void Country_Bind()
        //{
        //    DataSet ds = dt.Get_Country();
        //    List<SelectListItem> countryList = new List<SelectListItem>();

        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        countryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["Id"].ToString() });
        //    }
        //    ViewBag.Countrys = countryList;
        //}
        //public JsonResult State_Bind(string CountryId)
        //{
        //    DataSet ds = dt.Get_State(CountryId);
        //    List<SelectListItem> stateList = new List<SelectListItem>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        stateList.Add(new SelectListItem { Text = dr["stateName"].ToString(), Value = dr["Id"].ToString() });
        //    }
        //    return Json(stateList, JsonRequestBehavior.AllowGet);
        //}
        //public JsonResult City_Bind(string StateId)
        //{
        //    DataSet ds = dt.Get_City(StateId);
        //    List<SelectListItem> cityList = new List<SelectListItem>();
        //    foreach (DataRow dr in ds.Tables[0].Rows)
        //    {
        //        cityList.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString() });
        //    }
        //    return Json(cityList, JsonRequestBehavior.AllowGet);
        //}
        [HttpGet]
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(EntityLogin login)
        {
            try
            {

                int Result = dt.Login(login);
                if (Result>0)
                {
                    TempData["AlertLogin"] = "Login Succesfully";
                    return RedirectToAction("dashboard","dashboard");
                }
                else
                {
                    TempData["AlertMessages"] = "Please Enter Correct Username and Password";
                    return RedirectToAction("login");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            return View();
        }
        public ActionResult research()
        {
            return View();
        }
    }
}
