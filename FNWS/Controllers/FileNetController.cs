using FileNet.Api.Core;
using FileNet.Api.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Web.Services3.Security.Tokens;
using System.IO;

namespace FNWS.Controllers
{
    public class FileNetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileNetResponse getDocument([FromBody] FileNetRequest req)
        {
            FileNetResponse fnResponse = new FileNetResponse();

            UsernameToken token = new UsernameToken("cpeadmin", "Bbs@2019", PasswordOption.SendPlainText);
            UserContext.SetProcessSecurityToken(token);
            IConnection conn = Factory.Connection.GetConnection("http://192.168.201.163:9080/wsi/FNCEWS40MTOM/");
            IDomain domain = Factory.Domain.GetInstance(conn, null);
            IObjectStore os = Factory.ObjectStore.FetchInstance(domain, "OBST", null);

            IDocument Document = Factory.Document.FetchInstance(os, req.sourceFileNetID, null);
            Stream s = Document.AccessContentStream(0);
            byte[] data = new byte[s.Length];
            s.Read(data, 0, data.Length);
            s.Close();
            fnResponse.data = data;
            return fnResponse;

        }
    }

    public class FileNetResponse
    {
        public string request_Id { get; set; }
        public byte[] data { get; set; }

    }

    public class FileNetRequest
    {
        public string sourceFileNetID { get; set; }
    }
}
