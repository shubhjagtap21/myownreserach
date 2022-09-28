using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyOwnResearch.Controllers
{
    public class myResearchController : Controller
    {
        // GET: myResearch
        public ActionResult research()
        {
            return View();
        }
        //public JsonResult addInfoMyResearch()
        //{
        //    string mes = null;
        //    string path = null;
        //    try
        //    {
        //        for (int i = 0; i < Request.Files.Count; i++)
        //        {
        //            var file = Request.Files[i];

        //            var fileName = Path.GetFileName(file.FileName);

        //            path = Path.Combine(Server.MapPath("~/UploadedFiles/"), fileName);
        //            file.SaveAs(path);
        //        }
        //        EntityAddResearch entity = new EntityAddResearch
        //        {
                   
        //        };
        //        int result = dt.AddReserach(entity);
        //        if (result > 0)
        //        {
        //            mes = "Data inserted succesful";
        //        }
        //        else
        //        {
        //            Console.WriteLine("something wrong");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return Json(new { print = mes });
        //}
    }
}