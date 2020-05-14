using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace QLKTX_API_V2.Controllers.ADMIN
{
    [RoutePrefix("api/Mail")]
    public class MailController : ApiController
    {
        public struct mail
        {
            public string from { get; set; }
            public string to { get; set; }
            public string subject { get; set; }
            public string bobdy { get; set; }
            public string sdt { get; set; }
        }
        [Route("Sendmail")]
        [HttpPost]
        public HttpResponseMessage Sendmail([FromBody]mail value)
        {
            result<object> tel = new result<object>();
            try
            {
                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("appmeiko7@gmail.com", "duytuit89!");

                MailMessage message = new MailMessage("appmeiko7@gmail.com", value.to);

                message.Subject = value.subject;
                message.Body = value.bobdy;


                mailclient.Send(message);
                tel.code = "OK";
                tel.mess = "Đã gửi thư thành công...";
            }
            catch (Exception df)
            {
                tel.code = "ERR";
                tel.mess = df.Message;
            }
            return tel.ToHttpResponseMessage();
        }
    }
}
