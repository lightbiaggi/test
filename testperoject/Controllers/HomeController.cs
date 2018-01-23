using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using testperoject.Models;

namespace testperoject.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult UploadFile()
        {
            HttpPostedFileBase loadedFile = Request.Files["MyFile"];
            bool isUploaded = false;
            string message = "File upload failed";

            if (loadedFile != null && Request.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/Uploads");
                    try
                    {
                    var path = Path.Combine(pathForSaving, loadedFile.FileName);
                    loadedFile.SaveAs(path);
                        isUploaded = true;

                    // load xml file

                    var document = new Document(path);
                    }
                    catch (Exception ex)
                    {
                        message = string.Format("File upload failed: {0}", ex.Message);
                    }
                
            }
            return Json(new { isUploaded = isUploaded, message = message }, "text/html");
        }

    }
}