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
            string strIndustry, int intCountryId, int intStateId, int intCityId, string strCompanyAddress, string strCompanyURL, string strPrivateNote,string Keyword)
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
        public JsonResult updateReserach(string strFirstName, string strLastName, string strTitleEmail, string strPersonlkdnURL, string strCompanyWebsite,
            string strCorporatePn, string strEmployee,
            string strIndustry, int intCountryId, int intStateId, int intCityId, string strCompanyAddress, string strCompanyURL, string strPrivateNote, string Keyword)
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
                }
            }
            return entity;
        }
        [HttpGet]
        public ActionResult dashboard(string keyword, int? i)
        {
            ShowDetails(keyword,i);
            Country_Bind();
            return View();
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
                countryList.Add(new SelectListItem { Text = dr["CountryName"].ToString(), Value = dr["Id"].ToString() });
            }
            ViewBag.Countrys = countryList;
        }
        public JsonResult State_Bind(string CountryId)
        {
            DataSet ds = dts.Get_State(CountryId);
            List<SelectListItem> stateList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                stateList.Add(new SelectListItem { Text = dr["stateName"].ToString(), Value = dr["Id"].ToString() });
            }
            return Json(stateList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult City_Bind(string StateId)
        {
            DataSet ds = dts.Get_City(StateId);
            List<SelectListItem> cityList = new List<SelectListItem>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                cityList.Add(new SelectListItem { Text = dr["CityName"].ToString(), Value = dr["Id"].ToString() });
            }
            return Json(cityList, JsonRequestBehavior.AllowGet);
        }
    }
}
