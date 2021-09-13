using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FNWS.Controllers
{
    public class FileNetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public FileNetResponse Post([FromBody] FileNetRequest req)
        {
            FileNetResponse fnResponse = new FileNetResponse();
            fnResponse.request_Id = "{ erkan " + req.sourceFileNetID + " muratcan}";

            return fnResponse;


        }
    }

    public class FileNetResponse
    {
        public string request_Id { get; set; }
        public string request_Status { get; set; }

    }

    public class FileNetRequest
    {
        public string sourceFileNetID { get; set; }
    }
}
