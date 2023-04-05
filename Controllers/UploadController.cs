using Microsoft.AspNetCore.Mvc;
namespace FileUpload.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UploadFile()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                    string _FileName = Path.GetFileName(file.FileName);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), path2: _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View();
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }
    }
}