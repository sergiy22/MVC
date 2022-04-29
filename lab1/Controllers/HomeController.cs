using System;
using System.Collections.Generic;
using lab1.Models;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using File = lab1.Models.File;


namespace lab1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index ()
        {
            ViewBag.Message = "My first MVC";
            return View();
        }

        public JsonResult SimpleJson()
        {
            UserData obj = new UserData() { UserName = "Vasia", Email = "vasia777@email.com", Phone = "380679833048" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        public class UserData
        {
            public string UserName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
        }
        public ActionResult Storage()
        {
            //Fetch all files in the Folder (Directory).
            string[] filePaths = Directory.GetFiles(Server.MapPath("~/Files/"));

            //Copy File names to Model collection.
            List<File> files = new List<File>();
            foreach (string filePath in filePaths)
            {
                files.Add(new File { FileName = Path.GetFileName(filePath) });
            }

            return View(files);
        }

        public FileResult DownloadFile(string fileName)
        {
            //Build the File Path.
            string path = Server.MapPath("~/Files/") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "My contact page.";
            return View();
        }
    }
}