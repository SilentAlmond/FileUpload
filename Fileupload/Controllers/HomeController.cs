using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Fileupload.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Fileupload.UploadedFiles;

namespace Fileupload.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {

            {
                if (file == null)
                {
                    ModelState.AddModelError("InvalidInput", "Please select a file");
                    return View();
                }
                else
                {
                    var filename = Path.GetFileName(file.GetFileName());
                    var path = Path.Combine(Server.MapPath("~/UploadedFiles"), filename);
                    file.SaveAs(path);
                    return RedirectToAction("Thankyou");
                }

            }
        }
    }
}

