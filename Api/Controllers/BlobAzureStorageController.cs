using System.Web.Http.Cors;

namespace Api.Controllers
{
    using System;
    using System.Web;
    using System.Web.Http;
    using System.Configuration;
    using Api.Core.AzureCore;
    using API.Common.Configs;

    //Enable cross domain request
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class BlobAzureStorageController : ApiController
    {

        [HttpPost]
        public IHttpActionResult UploadBlob()
        {
            using (var proxy = new DefaultAzureProxy(BlobPortalConfig.AzureStorageConnectionString, BlobPortalConfig.AzureStorageAccount))
            {
                try
                {
                    var file = HttpContext.Current.Request.Files[0];
                    var extName = (file.FileName).Split('.')[1];
                    var timeStamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss") + (new Random()).Next(1, 999999);

                    var returnUrl = proxy.SaveBlob(file.InputStream, "blobs", timeStamp + "." +　extName);

                    return Json(new { result = "success", returnUrl = returnUrl });
                }
                catch (Exception exc)
                {
                    throw new Exception("Update task exception", exc);
                }
            }
        }
    }

}
