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
        public virtual ActionResult UploadFile(HttpPostedFileBase file)
        {
            string message = "File upload failed";

            if (file != null && Request.ContentLength != 0)
            {
                string pathForSaving = Server.MapPath("~/Uploads");
                var resultsModel = new Results();
                try
                {
                    var path = Path.Combine(pathForSaving, file.FileName);
                    file.SaveAs(path);

                    // load xml file

                    var document = new Document(path);

                    foreach (var c in document.Clients)
                    {
                        if (!DataAdapter.HasClient(c))
                        {
                            DataAdapter.AddClient(c);
                            resultsModel.AddedClients.Add(c);
                        }
                        else
                        {
                            DataAdapter.UpdateClient(c);
                            resultsModel.UpdatedClients.Add(c);
                        }
                    }
                }
                catch (Exception ex)
                {
                    message = string.Format("File upload failed: {0}", ex.Message);
                    return View("Error");
                }
                return View("Results", resultsModel);
            }
            return View();
        }

    }
}