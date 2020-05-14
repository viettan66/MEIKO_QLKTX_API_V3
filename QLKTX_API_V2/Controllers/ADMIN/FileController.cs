using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using MEIKO_QLKTX_API_V1.Models;
using Newtonsoft.Json;
using QLKTX_API_V2.Controllers.ADMIN;
using static QLKTX_API_V2.Controllers.ADMIN.FingerPrintData;

namespace QLKTX_API_V2.Controllers.QLKTX
{
    [RoutePrefix("api/File")]
    public class FileController : ApiController
    {
        [Route("DownloadFile")]
        [HttpGet]
        public HttpResponseMessage GetTestFile(string filename)
        {
            try
            {
                HttpResponseMessage result = null;
                var localFilePath = HttpContext.Current.Server.MapPath("~/File/" + filename);

                if (!File.Exists(localFilePath))
                {
                    result = Request.CreateResponse(HttpStatusCode.Gone);
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.OK);
                    result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
                    result.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                }

                return result;
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [Route("UploadFile")]
        [HttpPost]
        public HttpResponseMessage UploadFile()
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/File/"))) Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/File/"));
                string webRootPath = HttpContext.Current.Server.MapPath("~/File/" + postedFile.FileName);
                postedFile.SaveAs(webRootPath);
                response.Content = new StringContent(JsonConvert.SerializeObject(new
                {
                    messageBox = true
                }));
                response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                return response;
            }
            catch (Exception f)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
        [Route("DeleteFile")]
        [HttpGet]
        public HttpResponseMessage DeleteFile(string filename)
        {
            try
            {
                var response = new HttpResponseMessage(HttpStatusCode.OK);
                var localFilePath = HttpContext.Current.Server.MapPath("~/File/" + filename);

                if (!File.Exists(localFilePath))
                {
                    response.Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        messageBox = "Thất bại!"
                    }));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
                else
                {
                    File.Delete(localFilePath);
                    response.Content = new StringContent(JsonConvert.SerializeObject(new
                    {
                        messageBox = "Thành công!"
                    }));
                    response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    return response;
                }
            }
            catch
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
