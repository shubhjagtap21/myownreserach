
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
                    Session["name"] = login.name;
                    Session["userId"] = login.userId;
                    Session["userName"] = login.strEmail;
                    if (Session["name"] != null)
                    {
                        return RedirectToAction("dashboard", "dashboard", new { Name = Session["name"].ToString(), userId = Session["userId"], userName = Session["userName"] });
                    }
                    
                }
                else
                {
                    TempData["AlertMessages"] = "Please Enter Correct Username and Password";
                    return RedirectToAction("login");
                }
                if (login.strEmail=="" && login.strPassword=="")
                {
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
