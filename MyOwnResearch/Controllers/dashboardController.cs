using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc;
using MyApp.db;
using MyApp.Entity;
using Newtonsoft.Json;
using PagedList.Mvc;
using PagedList;

namespace MyOwnResearch.Controllers
{
    public class dashboardController : Controller
    {
        private string ConnectionStrings = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        BAL_Dashboard dt = new BAL_Dashboard();
        ABState dts = new ABState();

        // GET: dashboard
        [HttpPost]
        public JsonResult addInvite(string strtitle,string strresearchtype, string researchURL,string strlkdnURL, string strprivateNotes,string strPublicNotes)
        {
            string mes = null;
            string path = null;
            string path1 = null;
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    file.SaveAs(path);
                }
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);
                    path1 = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    file.SaveAs(path1);
                }
                EntityInvite entity = new EntityInvite
                {
                    strTitle=strtitle,
                    strRsrchType=strresearchtype,
                    strURL=researchURL,
                    strLkdnURL=strlkdnURL,
                    strPrivateNotes=strprivateNotes,
                    strPublicNotes=strPublicNotes,
                    fileUpload1 = path,
                    fileUpload2=path1
                };
                int result = dt.invite(entity);
                if (result > 0)
                {
                    mes = "Data inserted succesful";
                }
                else
                {
                    Console.WriteLine("something wrong");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(new { print = mes });
        }
        [HttpPost]
        public JsonResult addReserach(string strFirstName, string strLastName, string strTitleEmail, string strPersonlkdnURL, string strCompanyWebsite,
            string strCorporatePn, string strEmployee,
            string strIndustry, int intCountryId, int intStateId, int intCityId, string strCompanyAddress, string strCompanyURL, string strPrivateNote)
        {
            string mes = null;
            string path = null;
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    file.SaveAs(path);
                }
                string userId = Session["userId"].ToString();
                string userName = Session["userName"].ToString();
                EntityAddResearch entity = new EntityAddResearch
                {
                    userName=userName,
                    userId=userId,
                    strFirstName = strFirstName,
                    strLastName = strLastName,
                    strTitleEmail = strTitleEmail,
                    strPersonlkdnURL = strPersonlkdnURL,
                    strCompanyWebsite = strCompanyWebsite,
                    strCorporatePn = strCorporatePn,
                    strEmployee = strEmployee,
                    strIndustry = strIndustry,
                    intCountryId = intCountryId,
                    intStateId = intStateId,
                    intCityId = intCityId,
                    strCompanyAddress = strCompanyAddress,
                    strCompanyURL = strCompanyURL,
                    strPrivateNote = strPrivateNote,
                    fileUpload = path
                };
                
                int result = dt.AddReserach(entity);
                if (result > 0)
                {
                    mes = "Data inserted succesful";
                }
                else
                {
                    Console.WriteLine("something wrong");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(new { print = mes });
        }

        [HttpPost]
        public JsonResult updateReserach1(string resId, string firstName, string lastName, string strTitleEmail, string strPersonlkdnURL, string strCompanyWebsite,
            string strCorporatePn, string strEmployee,
            string strIndustry, int intCountryId, int intStateId, int intCityId, string strCompanyAddress, string strCompanyURL, string strPrivateNote
)
        {
            string mes = null;
            try
            {
                //for (int i = 0; i < Request.Files.Count; i++)
                //{
                //    var file = Request.Files[i];

                //    var fileName = Path.GetFileName(file.FileName);

                //    path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                //    file.SaveAs(path);
                //}
                EntityAddResearch entity = new EntityAddResearch
                {
                    strResId = resId,
                    strFirstName = firstName,
                    strLastName = lastName,
                    strTitleEmail = strTitleEmail,
                    strPersonlkdnURL = strPersonlkdnURL,
                    strCompanyWebsite = strCompanyWebsite,
                    strCorporatePn = strCorporatePn,
                    strEmployee = strEmployee,
                    strIndustry = strIndustry,
                    intCountryId = intCountryId,
                    intStateId = intStateId,
                    intCityId = intCityId,
                    strCompanyAddress = strCompanyAddress,
                    strCompanyURL = strCompanyURL,
                    strPrivateNote = strPrivateNote,
                };
                int result = dt.updateRecords(entity);
                if (result > 0)
                {
                    mes = "Data inserted succesful";
                }
                else
                {
                    Console.WriteLine("something wrong");
                }
                //dashboard(Keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            RedirectToAction("dashboard", "dashboard");
            return Json(new { print = mes });
        }
        [HttpPost]

        public JsonResult fileUpdate(string resId)
        {
            string mes = null;
            string path = null;
            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    var file = Request.Files[i];

                    var fileName = Path.GetFileName(file.FileName);

                    path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
                    file.SaveAs(path);
                }
                EntityAddResearch entity = new EntityAddResearch
                {
                    strResId=resId,
                    fileUpload=path
                };
                int result = dt.fileUpdate(entity);
                if (result > 0)
                {
                    mes = "File Updated succesfully";
                }
                else
                {
                    mes = "something went wrong";
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(new { print = mes });           
            
        }
        [HttpPost]

        public JsonResult deleterecord(string strresid,string Keyword, int? i)
        {
            string mes = null;
            int result = dt.delete(Convert.ToInt32(strresid));
            if (result > 0)
            {
                mes = "record deleted succesfully";
                ShowDetails(Keyword,i);
            }
            else
            {
                mes = "something went wrong";
            }
            return Json(new { mess = mes });
        }
        public ActionResult updateRecords(int id)
        {
            Country_Bind();
            var entity = getElementById(id);
            return View(entity);
        }
        public ActionResult viewRecords(int id)
        {
            Country_Bind();
            var entity = getElementById(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult shareStatus(int id)
        {
            int result = dt.shareStatus(id);
            if (result > 0)
            {
                TempData["shareStatus"] = "Status Updated";
            }
            else
            {
                Console.WriteLine("Something went Wrong");
            }
            return View();
        }
        public EntityAddResearch getElementById(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            EntityAddResearch entity = new EntityAddResearch();
            SqlCommand comm = new SqlCommand("SP_GetDataByIdResearch", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandTimeout = 120;
            comm.Parameters.AddWithValue("@resId", id);
            conn.Open();
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            if (dr != null && dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    entity.strResId = Convert.ToString(tv["resId"]);
                    entity.strFirstName = Convert.ToString(tv["firstName"]);
                    entity.strLastName = Convert.ToString(tv["lastName"]);
                    entity.strTitleEmail = Convert.ToString(tv["titleEmail"]);
                    entity.strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]);
                    entity.strCompanyAddress = Convert.ToString(tv["companyAddress"]);
                    entity.strCompanyWebsite = Convert.ToString(tv["companyWebsite"]);
                    entity.strCorporatePn = Convert.ToString(tv["corporatePhone"]);
                    entity.strEmployee = Convert.ToString(tv["employee"]);
                    entity.strIndustry = Convert.ToString(tv["industry"]);
                    entity.intCountryId = Convert.ToInt32(tv["countryId"].ToString());
                    entity.intStateId = Convert.ToInt32(tv["stateId"].ToString());
                    entity.intCityId = Convert.ToInt32(tv["cityId"].ToString());
                    entity.strCountryName = Convert.ToString(tv["CountryName"]);
                    entity.strStateName = Convert.ToString(tv["stateName"]);
                    entity.strCityName = Convert.ToString(tv["CityName"]);
                    entity.strCompanyURL = Convert.ToString(tv["companyURL"]);
                    entity.strPrivateNote = Convert.ToString(tv["privateNote"]);
                    entity.showDate = Convert.ToDateTime(tv["createdDate"].ToString());
                    Session["stateId"] = "";
                    Session["cityId"] = "";
                    Session["countryId"] = Convert.ToInt32(tv["countryId"].ToString());

                    Session["stateId"] = Convert.ToInt32(tv["stateId"].ToString());
                    Session["cityId"] = Convert.ToInt32(tv["cityId"].ToString());
                }
            }
            Country_Bind1(Session["countryId"].ToString());
            State_Bind(Session["countryId"].ToString());
            City_Bind(Session["stateId"].ToString());

            return entity;
        }
        [HttpGet]
        public ActionResult dashboard(string keyword, int? i, string industry,string byCountry)
        {
            try
            {
                if (Session["name"] == null && Session["userId"] == null && Session["userName"] == null)
                {
                    return RedirectToAction("login", "login", new { Name = Session["name"].ToString() });
                }
                else
                {
                    if (keyword != null)
                    {
                        ShowDetails(keyword, i);
                    }
                    else if (industry != null)
                    {
                        ShowDetailsIndustry(industry, i,byCountry);
                    }
                    else if (keyword == null || industry == null)
                    {
                        Show(i);
                    }
                    Country_Bind();
                    Industry_Bind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();

        }
        public void UserDetails(EntitySignUp entity)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_ShowSignUpDetails", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            if (dr != null && dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    entity.userId = Convert.ToInt32(tv["userId"]);
                    entity.name = Convert.ToString(tv["name"]);
                    entity.email = Convert.ToString(tv["email"]);
                }
            }
        }
        public ActionResult ShowDetailsIndustry(string industry, int? i,string byCountry)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = i.HasValue ? Convert.ToInt32(i) : 1;
            IPagedList<EntityAddResearch> ent = null;
            EntityAddResearch entity = new EntityAddResearch();

            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_GetIndustryGid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            if (industry == null)
            {
                industry = "";
            }
            comm.Parameters.AddWithValue("@resId", industry);
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            List<EntityAddResearch> lstres = new List<EntityAddResearch>();
            if (dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    lstres.Add(new EntityAddResearch
                    {
                        userId = Convert.ToString(tv["userID"]),
                        shareStatus = Convert.ToInt32(tv["shareStatus"]),
                        strResId = Convert.ToString(tv["resId"]),
                        strFirstName = Convert.ToString(tv["firstName"]),
                        strLastName = Convert.ToString(tv["lastName"]),
                        strTitleEmail = Convert.ToString(tv["titleEmail"]),
                        strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
                        strCompanyAddress = Convert.ToString(tv["companyAddress"]),
                        strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
                        strCorporatePn = Convert.ToString(tv["corporatePhone"]),
                        strEmployee = Convert.ToString(tv["employee"]),
                        strIndustry = Convert.ToString(tv["industry"]),
                        strCompanyURL = Convert.ToString(tv["companyURL"]),
                        strPrivateNote = Convert.ToString(tv["privateNote"]),
                        showDate = Convert.ToDateTime(tv["createdDate"])
                    });
                }
            }
            ViewBag.id = lstres[0].userId;
            ent = lstres.ToPagedList(pageIndex, pageSize);
            return View(ent);
        }
        public ActionResult Show(int? i)
        {

            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = i.HasValue ? Convert.ToInt32(i) : 1;
            IPagedList<EntityAddResearch> ent = null;
            EntityAddResearch entity = new EntityAddResearch();

            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_GetGrid", conn);
            comm.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            List<EntityAddResearch> lstres = new List<EntityAddResearch>();
            if (dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    lstres.Add(new EntityAddResearch
                    {
                        userId = Convert.ToString(tv["userID"]),
                        shareStatus = Convert.ToInt32(tv["shareStatus"]),
                        strResId = Convert.ToString(tv["resId"]),
                        strFirstName = Convert.ToString(tv["firstName"]),
                        strLastName = Convert.ToString(tv["lastName"]),
                        strTitleEmail = Convert.ToString(tv["titleEmail"]),
                        strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
                        strCompanyAddress = Convert.ToString(tv["companyAddress"]),
                        strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
                        strCorporatePn = Convert.ToString(tv["corporatePhone"]),
                        strEmployee = Convert.ToString(tv["employee"]),
                        strIndustry = Convert.ToString(tv["industry"]),
                        strCompanyURL = Convert.ToString(tv["companyURL"]),
                        strPrivateNote = Convert.ToString(tv["privateNote"]),
                        showDate = Convert.ToDateTime(tv["createdDate"])
                    });
                }
            }
            ViewBag.id = lstres[0].userId;
            ent = lstres.ToPagedList(pageIndex, pageSize);
            return View(ent);
        }
        public ActionResult ShowDetails(string keyword, int? i)
        {
            int pageSize = 8;
            int pageIndex = 1;
            pageIndex = i.HasValue ? Convert.ToInt32(i) : 1;
            IPagedList<EntityAddResearch> ent = null;
            EntityAddResearch entity = new EntityAddResearch();
            
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            SqlCommand comm = new SqlCommand("SP_ShowReseach", conn);
            comm.CommandType = CommandType.StoredProcedure;
            if (keyword == null)
            {
                keyword = "";
            }
            comm.Parameters.AddWithValue("@Keyword", keyword);
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            List<EntityAddResearch> lstres = new List<EntityAddResearch>();
            if (dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    lstres.Add(new EntityAddResearch
                    {
                        userId = Convert.ToString(tv["userID"]),
                        shareStatus = Convert.ToInt32(tv["shareStatus"]),
                        strResId = Convert.ToString(tv["resId"]),
                        strFirstName = Convert.ToString(tv["firstName"]),
                        strLastName = Convert.ToString(tv["lastName"]),
                        strTitleEmail = Convert.ToString(tv["titleEmail"]),
                        strPersonlkdnURL = Convert.ToString(tv["personlkdnURL"]),
                        strCompanyAddress = Convert.ToString(tv["companyAddress"]),
                        strCompanyWebsite = Convert.ToString(tv["companyWebsite"]),
                        strCorporatePn = Convert.ToString(tv["corporatePhone"]),
                        strEmployee = Convert.ToString(tv["employee"]),
                        strIndustry = Convert.ToString(tv["industry"]),
                        strCompanyURL = Convert.ToString(tv["companyURL"]),
                        strPrivateNote = Convert.ToString(tv["privateNote"]),
                        showDate = Convert.ToDateTime(tv["createdDate"])
                    });
                }
            }
            ViewBag.id= lstres[0].userId;
            ent = lstres.ToPagedList(pageIndex, pageSize);
            return View(ent);
            //return View(lstres.ToList().ToPagedList(i ?? 1,8));
        }

        [HttpPost]
        public ActionResult dashboard(HttpPostedFileBase fileUpload)
        {
            if (fileUpload.ContentLength > 0)
            {
                string imageFileName = Path.GetFileName(fileUpload.FileName);

                string folderPath = Path.Combine(Server.MapPath("~/UploadedFiles"), imageFileName);

                fileUpload.SaveAs(folderPath);
            }
            return View();
        }
        public void Country_Bind()
        {
            DataSet ds = dts.Get_Country();
            List<SelectListItem> countryList = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (Session["countryId1"] != null)
                {
                    countryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["Id"].ToString(), Selected = dr["Id"].ToString() == Session["countryId"].ToString() ? true : false });
                }
                else
                {
                    countryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["Id"].ToString() });
                }
            }
            ViewBag.Countrys = countryList;
        }

        public void Country_Bind1(string CountryId)
        {
            DataSet ds = dts.Get_Country();
            List<SelectListItem> countryList = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                countryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["Id"].ToString(), Selected = dr["Id"].ToString() == Session["countryId"].ToString() ? true : false });
            }
            ViewBag.Countrys = countryList;
        }

        public JsonResult State_Bind(string CountryId)
        {
            DataSet ds = dts.Get_State(CountryId);
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                if (Session["stateId"] != null)
                {
                    stateList.Add(new SelectListItem { Text = dr["stateName"].ToString(), Value = dr["Id"].ToString(), Selected = dr["Id"].ToString() == Session["stateId"].ToString() ? true : false });
                }
                else
                {
                    stateList.Add(new SelectListItem { Text = dr["stateName"].ToString(), Value = dr["Id"].ToString() });
                }
            }
            ViewBag.state1 = stateList;
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult City_Bind(string StateId)
        {
            DataSet ds = dts.Get_City(StateId);
            List<SelectListItem> cityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                if (Session["cityId"] != null)
                {
                    cityList.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString(), Selected = dr["Id"].ToString() == Session["cityId"].ToString() ? true : false });
                }
                else
                {
                    cityList.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString() });
                }
            }
            ViewBag.city = cityList;
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }
        public void Industry_Bind()
        {
            DataSet ds = dt.Get_Industry();
            List<SelectListItem> industryList = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                industryList.Add(new SelectListItem { Text = dr["industry"].ToString(), Value = dr["resId"].ToString() });
            }
            ViewBag.industrys = industryList;
        }
        public JsonResult Country(string resId)
        {
            DataSet ds = dts.Country(resId);
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                stateList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["resId"].ToString() });
            }
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }
    }
}
