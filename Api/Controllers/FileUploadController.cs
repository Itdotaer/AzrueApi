using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    //Enable cross domain request
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FileUploadController : ApiController
    {
        // Post FileUpload
        [HttpPost]
        public IHttpActionResult UploadFile()
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpFileCollection files = HttpContext.Current.Request.Files;
                for (var i = 0; i < files.Count; i++)
                {
                    HttpPostedFile file = files[i];

                    var timeSpan = DateTime.Now.ToString("yyyyMMddHHmmss");
                    var fpath = HttpContext.Current.Server.MapPath("Uploads\\");

                    if (!Directory.Exists(fpath))
                    {
                        Directory.CreateDirectory(fpath);
                    }

                    var fname = timeSpan + "_" + file.FileName;
                    file.SaveAs(fpath + fname);
                }

            }

            return Ok("File(s) uploaded successfully!");
        }
    }
}