using MyApp.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOwnResearch.Controllers
{
    public class ProfileController : Controller
    {
        private string ConnectionStrings = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;

        BAL_Dashboard dt = new BAL_Dashboard();
        // GET: Profile
        public ActionResult Profiles(int id)
        {
            Gender_Bind();
            var entity = getProfileById(id);
            return View(entity);
        }
        public EntitySignUp getProfileById(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionStrings);
            EntitySignUp entity = new EntitySignUp();
            SqlCommand comm = new SqlCommand("SP_GetProfile", conn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandTimeout = 120;
            comm.Parameters.AddWithValue("@userID", id);
            conn.Open();
            SqlDataAdapter Ad = new SqlDataAdapter(comm);
            DataTable dr = new DataTable();
            Ad.Fill(dr);
            if (dr != null && dr.Rows.Count > 0)
            {
                foreach (DataRow tv in dr.Rows)
                {
                    entity.userId = Convert.ToInt32(tv["userId"]);
                    entity.name = Convert.ToString(tv["name"]);
                    entity.strLastName = Convert.ToString(tv["lastName"]);
                    entity.email = Convert.ToString(tv["email"]);
                    entity.gender = Convert.ToString(tv["gender"]);
                    entity.strPhoneNumber = Convert.ToString(tv["phoneNumber"]);
                    entity.strAddress = Convert.ToString(tv["address"]);
                }
            }
            return entity;
        }
        public JsonResult updateProfile(int userId, string firstName,string lastName,string email,string gender,string phoneNumber,string address)
        {
            try
            {
                EntitySignUp entity = new EntitySignUp
                {
                    userId=userId,
                    name=firstName,
                    strLastName=lastName,
                    email=email,
                    gender=gender,
                    strPhoneNumber=phoneNumber,
                    strAddress=address
                };
                int result = dt.updateProfile(entity);
                if (result > 0)
                {
                    TempData["ProfileMessage"] = "Update Sucessful...!!!";
                }
                else
                {
                    TempData["ProfileMessage"] = "Something Went Wrong...!!!";
                }
                //dashboard(Keyword);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Json(new { result = "Redirect", url = Url.Action("dashboard", "dashboard") });
        }
        public void Gender_Bind()
        {
            DataSet ds = dt.Get_Gender();
            List<SelectListItem> genderList = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                genderList.Add(new SelectListItem { Text = dr["genderName"].ToString(), Value = dr["genderId"].ToString() });
            }
            ViewBag.genders = genderList;
        }
    }
}